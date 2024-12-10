using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebLab.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly IUnitOfWork _UnitOfWork;

		public CartController(IUnitOfWork unitOfWork)
		{
			_UnitOfWork = unitOfWork;
		}

		[HttpPost("addToCart")]
		public IActionResult AddToCart([FromBody] AddToCartDTO dto)
		{
			if (dto.UserId <= 0 || dto.BookId <= 0)
			{
				return NotFound("Không tồn tại giá trị hợp lệ.");
			}

			var book = _UnitOfWork.Books.GetById(dto.BookId);
			if (book == null)
			{
				return NotFound("Không tìm thấy sách với ID này.");
			}

			// Kiểm tra xem user đã có giỏ hàng chưa
			var cart = _UnitOfWork.Carts.Find(c => c.UserId == dto.UserId).FirstOrDefault();
			if (cart == null)
			{
				cart = new Cart
				{
					UserId = dto.UserId,
					CreatedAt = DateTime.UtcNow
				};
				_UnitOfWork.Carts.Add(cart);
				_UnitOfWork.Complete();
			}

			// Kiểm tra xem sách đã có trong giỏ hàng chưa
			var cartDetail = _UnitOfWork.CartDetail.Find(cd => cd.CartId == cart.Id && cd.BookId == dto.BookId).FirstOrDefault();
			if (cartDetail != null)
			{
				cartDetail.Quantity += dto.Quantity;
				_UnitOfWork.CartDetail.Update(cartDetail);
			}
			else
			{
				cartDetail = new CartDetail
				{
					CartId = cart.Id,
					BookId = dto.BookId,
					Quantity = dto.Quantity,
					Price = book.Price
				};
				_UnitOfWork.CartDetail.Add(cartDetail);
			}

			// Lưu thay đổi
			_UnitOfWork.Complete();

			return Ok(new
			{
				Message = "Thêm vào giỏ hàng thành công.",
				CartDetail = new
				{
					cartDetail.Id,
					cartDetail.CartId,
					cartDetail.BookId,
					cartDetail.Quantity,
					cartDetail.Price
				}
			});
		}

		[HttpGet("getCartDetails")]
		public IActionResult GetCartDetails(int userId)
		{
			// Kiểm tra xem user đã có giỏ hàng chưa
			var cart = _UnitOfWork.Carts.Find(c => c.UserId == userId).FirstOrDefault();
			if (cart == null)
			{
				return NotFound("Giỏ hàng trống hoặc không tồn tại");
			}

			// Lấy chi tiết giỏ hàng
			var cartDetails = _UnitOfWork.CartDetail
				.Find(cd => cd.CartId == cart.Id)
				.Select(cd => new
				{
					cd.Id,
					cd.CartId,
					cd.BookId,
					cd.Quantity,
					cd.Price,
				}).ToList();

			if (!cartDetails.Any())
			{
				return Ok(new
				{
					Message = "Giỏ hàng trống",
					TotalPrice = 0,
					Items = cartDetails
				});
			}

			// Tính tổng giá tiền
			var totalPrice = cartDetails.Sum(cd => cd.Quantity * cd.Price);

			return Ok(new
			{
				Message = "Lấy thông tin giỏ hàng thành công",
				TotalPrice = totalPrice,
				Items = cartDetails
			});
		}


	}
}

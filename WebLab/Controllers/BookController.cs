using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebLab.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IUnitOfWork _UnitOfWork;

		public BookController(IUnitOfWork unitOfWork)
		{
			_UnitOfWork = unitOfWork;
		}

		[HttpGet("status")]
		public IActionResult GetLoginStatus()
		{
			var userId = HttpContext.Session.GetString("UserId");
			if (string.IsNullOrEmpty(userId))
			{
				return Unauthorized(new { Message = "User not logged in." });
			}

			return Ok(new { UserId = userId });
		}


		[HttpGet("{id}")]
		public IActionResult GetBookById(int id)
		{
			//var name = HttpContext.Session.GetString("UserId");
			//if (string.IsNullOrEmpty(name))
			//{
			//	return BadRequest("Chua Dang Nhap");
			//}
			var book = _UnitOfWork.Books.GetById(id);
			if (book == null)
			{
				return NotFound("Wrong ID");
			}
			return Ok(book);
		}

		[HttpPost("createBook")]
		public IActionResult CreateBook(BookDTO bookDTO)
		{
			//var name = HttpContext.Session.GetString("UserId");
			//if (string.IsNullOrEmpty(name))
			//{
			//	return BadRequest("Chua Dang Nhap");
			//}
			var book = new Book
			{
				Title = bookDTO.Title,
				Description = bookDTO.Description,
				Price = bookDTO.Price,
				DiscountPrice = bookDTO.DiscountPrice,
				Author = bookDTO.Author,
				PublishDate = bookDTO.PublishDate,
			};
			_UnitOfWork.Books.Add(book);
			_UnitOfWork.Complete();
			return Ok(book);

		}

		[HttpGet("all")]
		public IActionResult GetAllBooks()
		{
			//var userId = HttpContext.Session.GetString("UserId");
			//if (string.IsNullOrEmpty(userId))
			//{
			//	return BadRequest("Chưa Đăng Nhập");
			//}

			//var books = _UnitOfWork.Books.GetAll();
			var booksWithCatalogues = _UnitOfWork.Books.GetBooksWithFullInfoAndCatalogueNames();

			return Ok(booksWithCatalogues);
			//return Ok(books);
		}

		[HttpPut("update/{id}")]
		public IActionResult UpdateBook(int id, BookDTO bookDTO)
		{
			//var userId = HttpContext.Session.GetString("UserId");
			//if (string.IsNullOrEmpty(userId))
			//{
			//	return BadRequest("Chưa Đăng Nhập");
			//}

			var book = _UnitOfWork.Books.GetById(id);
			if (book == null)
			{
				return NotFound("Không tìm thấy sách với ID này");
			}

			// Cập nhật thông tin sách
			book.Title = bookDTO.Title;
			book.Description = bookDTO.Description;
			book.Price = bookDTO.Price;
			book.DiscountPrice = bookDTO.DiscountPrice;
			book.Author = bookDTO.Author;
			book.PublishDate = bookDTO.PublishDate;

			_UnitOfWork.Books.Update(book); 
			_UnitOfWork.Complete();
			return Ok(book);
		}

		[HttpDelete("delete/{id}")]
		public IActionResult DeleteBook(int id)
		{
			//var userId = HttpContext.Session.GetString("UserId");
			//if (string.IsNullOrEmpty(userId))
			//{
			//	return BadRequest("Chưa Đăng Nhập");
			//}

			var book = _UnitOfWork.Books.GetById(id);
			if (book == null)
			{
				return NotFound("Không tìm thấy sách với ID này");
			}

			_UnitOfWork.Books.Remove(book);
			_UnitOfWork.Complete();
			return Ok(new { Message = "Xóa sách thành công", BookId = id });
		}

	}
}

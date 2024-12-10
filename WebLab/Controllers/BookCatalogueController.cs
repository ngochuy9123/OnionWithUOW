

using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebLab.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookCatalogueController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public BookCatalogueController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpPost("addBookToCatalogue")]
		public IActionResult AddBookToCatalogue([FromBody] BookCatalogueDTO dto)
		{
			var book = _unitOfWork.Books.GetById(dto.BookId);
			var catalogue = _unitOfWork.Catalogues.GetById(dto.CatalogueId);

			if (book == null || catalogue == null)
			{
				return NotFound("Book hoặc Catalogue không tồn tại");
			}

			var bookCatalogue = new BookCatalogue
			{
				BookId = dto.BookId,
				CatalogueId = dto.CatalogueId
			};

			_unitOfWork.BookCatalogue.Add(bookCatalogue);
			_unitOfWork.Complete();

			return Ok(bookCatalogue);
		}

		//[HttpPut("editBookCatalogue/{id}")]
		//public IActionResult EditBookCatalogue(int id, [FromBody] BookCatalogueDTO dto)
		//{
		//	var bookCatalogue = _unitOfWork.BookCatalogue.GetById(id);

		//	if (bookCatalogue == null)
		//	{
		//		return NotFound("Không tìm thấy BookCatalogue");
		//	}

		//	bookCatalogue.BookId = dto.BookId;
		//	bookCatalogue.CatalogueId = dto.CatalogueId;

		//	_unitOfWork.BookCatalogue.Update(bookCatalogue);
		//	_unitOfWork.Complete();

		//	return Ok(bookCatalogue);
		//}
		//[HttpDelete("removeBookFromCatalogue/{id}")]
		//public IActionResult RemoveBookFromCatalogue(int id)
		//{
		//	var bookCatalogue = _unitOfWork.BookCatalogue.GetById(id);

		//	if (bookCatalogue == null)
		//	{
		//		return NotFound("Không tìm thấy BookCatalogue");
		//	}

		//	_unitOfWork.BookCatalogue.Remove(bookCatalogue);
		//	_unitOfWork.Complete();

		//	return Ok("Đã xóa thành công");
		//}
		//Get book list by catalogue
		// Get list catalogue by book
		// edit
		// remove

	}
}

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebLab.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalogueController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public CatalogueController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/Catalogue
		[HttpGet]
		public IActionResult GetAllCatalogues()
		{
			var catalogues = _unitOfWork.Catalogues.GetAll();
			return Ok(catalogues);
		}

		// GET: api/Catalogue/{id}
		[HttpGet("{id}")]
		public IActionResult GetCatalogueById(int id)
		{
			var catalogue = _unitOfWork.Catalogues.GetById(id);
			if (catalogue == null)
			{
				return NotFound("Catalogue không tồn tại.");
			}
			return Ok(catalogue);
		}

		// POST: api/Catalogue
		[HttpPost]
		public IActionResult CreateCatalogue([FromBody] Catalogue catalogue)
		{
			if (catalogue == null || string.IsNullOrEmpty(catalogue.Name))
			{
				return BadRequest("Thông tin không hợp lệ.");
			}

			_unitOfWork.Catalogues.Add(catalogue);
			_unitOfWork.Complete();
			return Ok(catalogue);
		}

		// PUT: api/Catalogue/{id}
		[HttpPut("{id}")]
		public IActionResult UpdateCatalogue(int id, [FromBody] Catalogue catalogue)
		{
			var existingCatalogue = _unitOfWork.Catalogues.GetById(id);
			if (existingCatalogue == null)
			{
				return NotFound("Catalogue không tồn tại.");
			}

			existingCatalogue.Name = catalogue.Name;
			_unitOfWork.Catalogues.Update(existingCatalogue);
			_unitOfWork.Complete();

			return Ok(existingCatalogue);
		}

		// DELETE: api/Catalogue/{id}
		[HttpDelete("{id}")]
		public IActionResult DeleteCatalogue(int id)
		{
			var catalogue = _unitOfWork.Catalogues.GetById(id);
			if (catalogue == null)
			{
				return NotFound("Catalogue không tồn tại.");
			}

			_unitOfWork.Catalogues.Remove(catalogue);
			_unitOfWork.Complete();

			return Ok("Catalogue đã bị xóa thành công.");
		}
	}
}

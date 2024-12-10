using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebLab.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUnitOfWork _UnitOfWork;

		public UserController(IUnitOfWork unitOfWork)
		{
			_UnitOfWork = unitOfWork;
		}
		[HttpPost("signup")]
		public IActionResult SignUpUser(UserDTO userDTO)
		{
			var User = new User
			{
				Name = userDTO.Name,
				Email =userDTO.Email,
				Password = userDTO.Password,
				Address = userDTO.Address,
				Phone = userDTO.Phone,
			};
			_UnitOfWork.Users.Add(User);
			_UnitOfWork.Complete();
			return Ok();
		}

		[HttpPost("signin")]
		public IActionResult SignInUser([FromBody] LoginDTO loginDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = _UnitOfWork.Users.Find(u => u.Email == loginDTO.Email).FirstOrDefault();
			if (user == null || user.Password != loginDTO.Password)
			{
				return BadRequest("Invalid email or password");
			}

			HttpContext.Session.SetString("UserId", user.UserId.ToString());
			return Ok(new
			{
				Message = "Sign-in successful!",
				userId = user.UserId
			});
		}

		[HttpPost("logout")]
		public IActionResult LogOutUser()
		{
			HttpContext.Session.Remove("UserId");

			return Ok(new { Message = "Logged out successfully!" });
		}

	}
}

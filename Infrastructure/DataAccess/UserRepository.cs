using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(AppDBContext context) : base(context)
		{
		}
		public bool SignIn(string email, string password)
		{
			var user = _dbContext.Users.FirstOrDefaultAsync(u =>  u.Email == email && u.Password == password);
			if (user == null)
			{
				return false;
			}
			return true;
		}
	}
}

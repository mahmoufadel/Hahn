
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.Identity.Model;

namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
	public class UserRepository : Repository<ApplicationUser>, IUserRepository
	{
		public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
		{

		}
		public async Task<List<ApplicationUser>> GetAll()
		{
			var q = this.Query().Include(a=>a.Address);
			
			var res = await q.ToListAsync();
			return res;
		}
		public async Task<ApplicationUser> Get(string Username)
		{
			var q = this.Query().Include(a => a.Address);

			var user = await q.FirstOrDefaultAsync(u => u.UserName == Username);
			return user;
		}



	}

}


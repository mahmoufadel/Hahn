using Hahn.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.July2021.Domain
{
	public interface IUserRepository : IRepository<ApplicationUser>
	{
		Task<List<ApplicationUser>> GetAll();
		Task<ApplicationUser> Get(string Username);



	}
}

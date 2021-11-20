using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain
{
	public interface IAssetRepository : IRepository<Asset>
	{
		Task<Asset> Get(Guid Id);
		Task<List<Asset>> GetAll();
		Task BulkInsertAsync(List<Asset> inventories);		
	}
}

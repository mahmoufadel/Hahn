
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Hahn.ApplicatonProcess.July2021.Domain;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
	public class AssetRepository : IAssetRepository
	{
        private readonly IConfiguration _configuration;

        public AssetRepository(IConfiguration configuration) 
		{
            _configuration = configuration;

        }

        public Task BulkInsertAsync(List<Asset> inventories)
        {
            throw new NotImplementedException();
        }

        public Task Create(Asset entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Asset> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Asset> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Asset>> GetAll()
        {
            var assetData = new AssetData();
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["AssetAPI"];
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    assetData = JsonConvert.DeserializeObject<AssetData>(apiResponse);
                }
            }

            return assetData.Data;
        }

        public IQueryable<Asset> Query()
        {
            throw new NotImplementedException();
        }

        public void Update(Asset entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }

}


using Hahn.ApplicatonProcess.July2021.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            

        }

        public async Task<List<Asset>> GetAll()
        {
            var assetData = new AssetData();
            var httpClient = _httpClientFactory.CreateClient("AssetService");

            using (var response = await httpClient.GetAsync(""))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                assetData = JsonConvert.DeserializeObject<AssetData>(apiResponse);
            }
            return assetData.Data;
        }
    }
}

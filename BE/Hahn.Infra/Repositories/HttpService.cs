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
        private readonly IConfiguration _configuration;
        string _url;
        public HttpService(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["AssetAPI"];

        }
        public async Task<List<Asset>> GetAll()
        {
            var assetData = new AssetData();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(_url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    assetData = JsonConvert.DeserializeObject<AssetData>(apiResponse);
                }
            }

            return assetData.Data;
        }
    }
}

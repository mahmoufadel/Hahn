using Hahn.ApplicatonProcess.July2021.Data.Repositories;
using Hahn.ApplicatonProcess.July2021.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.XTest.Mock
{
    public class MockHttpService: IHttpService
    {
        public async Task<List<Asset>> GetAll()
        {
            return MockObjects.assets;
        }
     }
}

using Hahn.ApplicatonProcess.July2021.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
    public interface IHttpService
    {
        Task<List<Asset>> GetAll();
    }
}
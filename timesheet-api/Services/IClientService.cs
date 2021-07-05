using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> Get();
        Task<Client> Get(int id);
        Task<Client> Create(Client client);
        Task Update(Client client);
        Task Delete(int id);
    }
}

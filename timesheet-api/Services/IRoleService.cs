using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> Get();
        Task<Role> Get(int id);
        Task<Role> Create(Role role);
        Task Update(Role role);
        Task Delete(int id);
    }
}

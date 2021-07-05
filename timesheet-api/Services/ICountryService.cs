using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> Get();
        Task<Country> Get(int id);
        Task<Country> Create(Country country);
        Task Update(Country country);
        Task Delete(int id);
    }
}

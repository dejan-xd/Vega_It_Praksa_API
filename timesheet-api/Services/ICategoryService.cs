using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> Get(int id);
        Task<Category> Create(Category category);
        Task Update(Category category);
        Task Delete(int id);
    }
}

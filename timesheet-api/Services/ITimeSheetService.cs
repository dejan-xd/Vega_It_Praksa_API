using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.Services
{
    public interface ITimeSheetService
    {
        Task<IEnumerable<TimeSheet>> Get();
        Task<TimeSheet> Get(int id);
        Task<TimeSheet> Create(TimeSheet timeSheet);
        Task Update(TimeSheet timeSheet);
        Task Delete(int id);
    }
}

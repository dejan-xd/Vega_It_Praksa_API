using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VegaITPraksa.Data;
using VegaITPraksa.Models;
using VegaITPraksa.Services;

namespace VegaITPraksa.Repository
{
    public class TimeSheetRepository : ITimeSheetService
    {

        private readonly DataContext _db;

        public TimeSheetRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<TimeSheet> Create(TimeSheet timeSheet)
        {
            _db.TimeSheets.Add(timeSheet);
            await _db.SaveChangesAsync();

            return timeSheet;
        }

        public async Task Delete(int id)
        {
            var timeSheetToDelete = await _db.TimeSheets.FindAsync(id);
            _db.TimeSheets.Remove(timeSheetToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TimeSheet>> Get()
        {
            //return await _db.TimeSheets.Include(i => i.TeamMembers).ToListAsync();
            return await _db.TimeSheets.ToListAsync();
        }

        public async Task<TimeSheet> Get(int id)
        {
            return await _db.TimeSheets.FindAsync(id);
        }

        public async Task Update(TimeSheet timeSheet)
        {
            _db.Entry(timeSheet).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}

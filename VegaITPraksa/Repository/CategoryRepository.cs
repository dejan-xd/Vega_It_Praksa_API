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
    public class CategoryRepository : ICategoryService
    {
        private readonly DataContext _db;

        public CategoryRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Category> Create(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return category;
        }

        public async Task Delete(int id)
        {
            var categoryToDelete = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(categoryToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Get()
        {
            //return await _db.Categories.Include(i => i.TimeSheet).ToListAsync();
            return await _db.Categories.OrderBy(i => i.CategoryName).ToListAsync();

        }

        public async Task<Category> Get(int id)
        {
            //return await _db.Categories.Include(i => i.TimeSheet).FirstOrDefaultAsync(i => i.CategoryId == id);
            return await _db.Categories.FindAsync(id);

        }

        public async Task Update(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}

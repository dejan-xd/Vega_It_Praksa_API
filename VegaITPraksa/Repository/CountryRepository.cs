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
    public class CountryRepository : ICountryService
    {

        private readonly DataContext _db;

        public CountryRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Country> Create(Country country)
        {
            _db.Countries.Add(country);
            await _db.SaveChangesAsync();

            return country;
        }

        public async Task Delete(int id)
        {
            var countryToDelete = await _db.Countries.FindAsync(id);
            _db.Countries.Remove(countryToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> Get()
        {
            return await _db.Countries.OrderBy(i => i.CountryName).ToListAsync();
        }

        public async Task<Country> Get(int id)
        {
            return await _db.Countries.FindAsync(id);
        }

        public async Task Update(Country country)
        {
            _db.Entry(country).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}

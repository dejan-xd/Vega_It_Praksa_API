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
    public class ClientRepository : IClientService
    {

        private readonly DataContext _db;

        public ClientRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Client> Create(Client client)
        {
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();

            return client;
        }

        public async Task Delete(int id)
        {
            var clientToDelete = await _db.Clients.FindAsync(id);
            _db.Clients.Remove(clientToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _db.Clients.OrderBy(i => i.ClientName).Include(i => i.ClientCountry).ToListAsync();
            //return await _db.Clients.Include(i => i.Projects).ToListAsync();
        }

        public async Task<Client> Get(int id)
        {
            return await _db.Clients.Include(i => i.ClientCountry).FirstOrDefaultAsync(i => i.ClientId == id);
            //return await _db.Clients.FindAsync(id);
        }

        public async Task Update(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}

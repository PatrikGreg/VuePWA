using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using cr_api_service.DbModels;
using cr_api_service.Models;
using Microsoft.EntityFrameworkCore;

namespace cr_api_service.Data
{
    public class BoatsRepository : IBoatsRepository
    {
        private readonly ObjectContext _context = null;

        public BoatsRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(Boat Boat)
        {
            await _context.Boats.InsertOneAsync(Boat);
        }

        public async Task<IEnumerable<Boat>> Get()
        {
            return await _context.Boats.Find(x => true).ToListAsync();
        }

        public async Task<Boat> Get(string id)
        {
            var boat = Builders<Boat>.Filter.Eq("Id", id);
            return await _context.Boats.Find(boat).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Boats.DeleteOneAsync(Builders<Boat>.Filter.Eq("Id", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Boats.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Boat boat)
        {
            await _context.Boats.ReplaceOneAsync(x => x.Id == id, boat);
            return "";
        }
    }
}

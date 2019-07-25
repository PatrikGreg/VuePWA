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
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly ObjectContext _context = null;

        public ReviewsRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(Review Review)
        {
            await _context.Reviews.InsertOneAsync(Review);
        }

        public async Task<IEnumerable<Review>> Get()
        {
            return await _context.Reviews.Find(x => true).ToListAsync();
        }

        public async Task<Review> Get(string id)
        {
            var review = Builders<Review>.Filter.Eq("Id", id);
            return await _context.Reviews.Find(review).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Reviews.DeleteOneAsync(Builders<Review>.Filter.Eq("Id", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Reviews.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Review review)
        {
            await _context.Reviews.ReplaceOneAsync(x => x.Id == id, review);
            return "";
        }
    }
}

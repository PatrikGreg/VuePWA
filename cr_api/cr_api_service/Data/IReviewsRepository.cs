using System.Collections.Generic;
using System.Threading.Tasks;
using cr_api_service.Models;
using Microsoft.AspNetCore.Cors;
using MongoDB.Driver;


namespace cr_api_service.Data
{
    public interface IReviewsRepository
    {
        Task<IEnumerable<Review>> Get();
        Task<Review> Get(string id);
        Task Add(Review Review);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
        Task<string> Update(string id, Review review);
    }
}

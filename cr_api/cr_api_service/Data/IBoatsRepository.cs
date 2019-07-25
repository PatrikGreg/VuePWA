using System.Collections.Generic;
using System.Threading.Tasks;
using cr_api_service.Models;
using Microsoft.AspNetCore.Cors;
using MongoDB.Driver;


namespace cr_api_service.Data
{
    public interface IBoatsRepository
    {
        Task<IEnumerable<Boat>> Get();
        Task<Boat> Get(string id);
        Task Add(Boat Boat);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
        Task<string> Update(string id, Boat boat);
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cr_api_service.Data;
using cr_api_service.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cr_api_service.Controllers
{
    //[Produces("application/json")]
    [Route("api/Boats")]
    public class BoatsController : Controller
    {
        private readonly IBoatsRepository _boatRepository;

        public BoatsController(IBoatsRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return this.GetBoat();
        }
        private async Task<string> GetBoat()
        {
            var boats = await _boatRepository.Get();
            return JsonConvert.SerializeObject(boats);
        }
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GetBoatById(id);
        }
        private async Task<string> GetBoatById(string id)
        {
            var boats = await _boatRepository.Get(id) ?? new Boat();
            return JsonConvert.SerializeObject(boats);
        }

        [HttpPost] 
        public async Task<string> Post([FromBody] Boat boat)
        {

            if (boat != null)
            {

                await _boatRepository.Add(boat);
            }

            return "";
        }

        [HttpPut("{id}")] 
        public async Task<string> Put(string id, [FromBody] Boat boat)
        {
            return await _boatRepository.Update(id, boat);
        }

        [HttpDelete("{id}")] 
        public async Task<string> Delete(string id)
        {
            await _boatRepository.Remove(id);
            return "";
        }

    }

}

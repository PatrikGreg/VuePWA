using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cr_api_service.Data;
using cr_api_service.Models;
using Newtonsoft.Json;
using System.Net.Mail;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cr_api_service.Controllers
{
    //[Produces("application/json")]
    [Route("api/Reviews")]
    public class ReviewsController : Controller
    {
        private readonly IReviewsRepository _reviewRepository;

        public ReviewsController(IReviewsRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return this.GetReview();
        }
        private async Task<string> GetReview()
        {
            var reviews = await _reviewRepository.Get();
            return JsonConvert.SerializeObject(reviews);
        }
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GetReviewById(id);
        }
        private async Task<string> GetReviewById(string id)
        {
            var reviews = await _reviewRepository.Get(id) ?? new Review();
            return JsonConvert.SerializeObject(reviews);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Review review)
        {

            if (review != null)
            {

                await _reviewRepository.Add(review);
                await Task.Factory.StartNew(() => SendConfirmation(review));
            }

            return JsonConvert.SerializeObject(review);
        }
        private void SendConfirmation(Review review)
        {
            float prosjek=(float)((review.Overall + review.BoatCondition + review.CheckInOut) / 3);
            string prosjekString;

            if (prosjek >= 4.5) { prosjekString = "Odlična ocjena :D"; }
            else if (prosjek >= 3.5 && prosjek < 4.5) { prosjekString = "Vrlo dobra ocjena :)"; }
            else if (prosjek >= 2.5 && prosjek < 3.5) { prosjekString = "Dobra ocjena :|"; }
            else if (prosjek >= 1.5 && prosjek < 2.5) { prosjekString = "Loša ocjena :/"; }
            else { prosjekString = "Vrlo loša ocjena :("; }

            MailMessage mailMessage = new MailMessage("noreply@sec-reviews", "patrik.gregovic@sailingeurope.com");
            mailMessage.Subject = "Novi Check-out Review! " + prosjekString;
            mailMessage.Body = (
                "Zaprimljen je novi check-out review iz baze u Rogaču putem aplikacije. "+prosjekString+"\n\n" +
                "Ime i prezime: " + review.FirstName + " "+ review.LastName+ "\n" +
                "Email: " + review.Email + "\n" +
                "Tip broda: " + review.BoatType + "\n" +
                "Check-in datum: " + review.StartDate + "\n" +
                "Check-out datum: " + review.EndDate + "\n" +
                "Review:\n" + review.TextArea + "\n" +
                "\nOcijene (1-5 zvjezdica) \n"+
                "Stanje broda: " + review.BoatCondition + "\n" +
                "Check-in/out: " + review.CheckInOut + "\n" +
                "Overall: " + review.Overall + "\n" +
                "----------------------------------------\n"+
                "Prosjek: "+ prosjek
                );

            SmtpClient smtpClient = new SmtpClient("85.94.72.41", 25);
            smtpClient.Send(mailMessage);
        }

        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] Review review)
        {
            return await _reviewRepository.Update(id, review);
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            await _reviewRepository.Remove(id);
            return "";
        }

    }

}

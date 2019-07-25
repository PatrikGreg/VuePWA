using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cr_api_service.Models;

namespace cr_api_service.DbModels
{
    public class ObjectContext
    {
        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _database = null;
        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.iConfigurationRoot;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Review> Reviews
        {
            get
            {
                return _database.GetCollection<Review>("secReviews");
            }
        }
        public IMongoCollection<Boat> Boats
        {
            get
            {
                return _database.GetCollection<Boat>("boatTypes");
            }
        }
    }
}

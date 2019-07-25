using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cr_api_service.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BoatType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TextArea { get; set; }
        public byte BoatCondition { get; set; }
        public byte CheckInOut { get; set; }
        public byte Overall { get; set; }
    }
}

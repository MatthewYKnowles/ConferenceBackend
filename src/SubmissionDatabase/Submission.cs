using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SubmissionDatabase
{
    public class Submission
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Bio { set; get; }
        public string SubmissionTitle { get; set; }
        public string SubmissionAbstract { get; set; }
        public string Room { get; set; }
        public int StartTimeInHours { get; set; }
        public int StartTimeInMinutes { get; set; }
        public int EndTimeInHours { get; set; }
        public int EndTimeInMinutes { get; set; }
    }
}

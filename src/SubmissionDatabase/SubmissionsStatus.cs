using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SubmissionDatabase
{
    public class SubmissionStatus
    {
        public SubmissionStatus(string submissionStatus)
        {
            Status = submissionStatus;
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SubmissionDatabase
{
    public class SchedulePostedStatus
    {
        public SchedulePostedStatus(string submissionStatus)
        {
            Status = submissionStatus;
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Status { get; set; }
    }
}

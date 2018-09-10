using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SubmissionDatabase
{
    public interface ISubmissionToDatabase
    {
        Submission InsertSubmission(Submission submission);
        List<Submission> GetAllSubmissons();
        Submission GetSubmission(string submissionId);
        SubmissionStatus GetSubmissionStatus();
        void SetSubmissionStatus(SubmissionStatus newStatus);
        void updateSubmission(string id, Submission submission);
        void deleteSubmission(string id);
        SchedulePostedStatus GetSchedulePostedStatus();
        void SetSchedulePostedStatus(SchedulePostedStatus newStatus);
    }

    public class SubmissionToDatabase : ISubmissionToDatabase
    {
        private readonly IMongoCollection<Submission> _submissions;
        private readonly IMongoCollection<SubmissionStatus> _submissionsStatus;
        private readonly IMongoCollection<SchedulePostedStatus> _schedulePostedStatus;
        private IMongoDatabase _database;

        public SubmissionToDatabase(IMongoClient client)
        {
            _database = client.GetDatabase("conferencedb");
            _submissions = client.GetDatabase("conferencedb").GetCollection<Submission>("submissions");
            _submissionsStatus = client.GetDatabase("conferencedb").GetCollection<SubmissionStatus>("submissionsStatus");
            _schedulePostedStatus = client.GetDatabase("conferencedb").GetCollection<SchedulePostedStatus>("schedulePostedStatus");
        }

        public Submission InsertSubmission(Submission submission)
        {
            var submissionWithId = submission;
            submissionWithId.Id = ObjectId.GenerateNewId();
           _submissions.InsertOne(submissionWithId);
            return submissionWithId;
        }

        public List<Submission> GetAllSubmissons()
        {
            return _submissions.Find(_ => true).ToList();
        }

        public Submission GetSubmission(string submissionId)
        {
            return _submissions.Find(document => document.Id.ToString() == submissionId).FirstOrDefault();
        }

        public SubmissionStatus GetSubmissionStatus()
        {
            return new SubmissionStatus("open");
            return _submissionsStatus.FindAsync(_ => true).Result.FirstOrDefault();
        }

        public void SetSubmissionStatus(SubmissionStatus newStatus)
        {
            _submissionsStatus.DeleteMany(_ => true);
            _submissionsStatus.InsertOne(newStatus);
        }

        public void updateSubmission(string id, Submission submission)
        {
            var filter = Builders<Submission>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = _submissions.ReplaceOneAsync(filter, submission);
        }

        public void deleteSubmission(string id)
        {
            var filter = Builders<Submission>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = _submissions.DeleteOneAsync(filter);
        }

        public SchedulePostedStatus GetSchedulePostedStatus()
        {
            return new SchedulePostedStatus("posted");
            //SchedulePostedStatus schedulePostedStatus = _schedulePostedStatus.FindAsync(_ => true).Result.FirstOrDefault();
            //return schedulePostedStatus;
        }

        public void SetSchedulePostedStatus(SchedulePostedStatus newStatus)
        {
            _schedulePostedStatus.DeleteMany(_ => true);
            _schedulePostedStatus.InsertOne(newStatus);
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SubmissionDatabase
{
    public interface ISubmissionToDatabase
    {
        void InsertSubmission(Submission submission);
        Task<List<Submission>> GetAllSubmissons();
        Submission GetSubmission(string submissionId);
        SubmissionStatus GetSubmissionStatus();
        void SetSubmissionStatus(SubmissionStatus newStatus);
    }

    public class SubmissionToDatabase : ISubmissionToDatabase
    {
        private readonly IMongoCollection<Submission> _submissions;
        private readonly IMongoCollection<SubmissionStatus> _submissionsStatus;
        private IMongoDatabase _database;

        public SubmissionToDatabase(IMongoClient client)
        {
            _database = client.GetDatabase("conferencedb");
            _submissions = client.GetDatabase("conferencedb").GetCollection<Submission>("submissions");
            _submissionsStatus = client.GetDatabase("conferencedb").GetCollection<SubmissionStatus>("submissionsStatus");
        }

        public void InsertSubmission(Submission submission)
        {
            _submissions.InsertOne(submission);
        }

        public async Task<List<Submission>> GetAllSubmissons()
        {
            return await(await _submissions.FindAsync(_ => true)).ToListAsync();
        }

        public Submission GetSubmission(string submissionId)
        {
            return _submissions.Find(document => document.Id == submissionId).FirstOrDefault();
        }

        public SubmissionStatus GetSubmissionStatus()
        {
            if (CollectionDoesNotExist())
            {
                _submissionsStatus.InsertOne(new SubmissionStatus("open"));
            }
            SubmissionStatus submissionsStatus = _submissionsStatus.FindAsync(_ => true).Result.First();
            return submissionsStatus;
        }

        private bool CollectionDoesNotExist()
        {
            var filter = new BsonDocument("name", "submissionsStatus");
            var collection = _database.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            return collection.Result.Current == null;
        }

        public void SetSubmissionStatus(SubmissionStatus newStatus)
        {
            _submissionsStatus.DeleteOne(_ => true);
            _submissionsStatus.InsertOne(newStatus);
        }
    }


}

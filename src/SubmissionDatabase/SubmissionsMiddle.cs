using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubmissionDatabase
{
    public interface ISubmissionsMiddle
    {
        List<Submission> GetAllSubmissons(bool sorted);
    }

    public class SubmissionsMiddle : ISubmissionsMiddle
    {
        private readonly ISubmissionToDatabase _submissionToDatabase;

        public SubmissionsMiddle(ISubmissionToDatabase submissionToDatabase)
        {
            _submissionToDatabase = submissionToDatabase;
        }
        public List<Submission> GetAllSubmissons(bool sorted)
        {
            if (sorted)
            {
                return new List<Submission>(_submissionToDatabase
                    .GetAllSubmissons()
                    .OrderBy(submission => submission.StartTimeInMinutes)
                    .OrderBy(submission => submission.StartTimeInHours));

            }
            return _submissionToDatabase.GetAllSubmissons();
        }
    }
}

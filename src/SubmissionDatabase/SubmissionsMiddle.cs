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
                List<Submission> Submissions = _submissionToDatabase.GetAllSubmissons();
                Submissions = new List<Submission>(Submissions.OrderBy(submission => submission.StartTimeInMinutes));
                return new List<Submission>(Submissions.OrderBy(submission => submission.StartTimeInHours));

            }
            return _submissionToDatabase.GetAllSubmissons();
        }
    }
}

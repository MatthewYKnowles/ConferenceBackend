using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SubmissionDatabase;

namespace ConferenceOrganizerBackend.Controllers
{
    [Route("api/[controller]")]
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionToDatabase _submissionToDatabase;
        private readonly ISubmissionsMiddle _submissionsMiddle;

        public SubmissionsController(ISubmissionToDatabase submissionToDatabase, ISubmissionsMiddle submissionsMiddle)
        {
            _submissionToDatabase = submissionToDatabase;
            _submissionsMiddle = submissionsMiddle;
        }

        [HttpGet]
        public List<Submission> Get([FromQuery] bool sorted)
        {
            return _submissionsMiddle.GetAllSubmissons(sorted);
        }

        [HttpGet("{id}")]
        public Submission Get(string id)
        {
            return _submissionToDatabase.GetSubmission(id);
        }

        [HttpPost]
        public void Post([FromBody]Submission submission)
        {
            _submissionToDatabase.InsertSubmission(submission);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Submission submission)
        {
            _submissionToDatabase.updateSubmission(id, submission);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _submissionToDatabase.deleteSubmission(id);
        }
    }
}

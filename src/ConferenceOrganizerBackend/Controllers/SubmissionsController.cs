using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SubmissionDatabase;

namespace ConferenceOrganizerBackend.Controllers
{
    [Route("api/[controller]")]
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionToDatabase _submissionToDatabase;

        public SubmissionsController(ISubmissionToDatabase submissionToDatabase)
        {
            _submissionToDatabase = submissionToDatabase;
        }

        public List<Submission> Get()
        {
            return _submissionToDatabase.GetAllSubmissons().Result;
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
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

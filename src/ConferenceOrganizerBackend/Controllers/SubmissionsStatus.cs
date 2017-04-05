using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SubmissionDatabase;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceOrganizerBackend.Controllers
{
    [Route("api/[controller]")]
    public class SubmissionsStatus : Controller
    {
        private readonly ISubmissionToDatabase _submissionToDatabase;

        public SubmissionsStatus(ISubmissionToDatabase submissionToDatabase)
        {
            _submissionToDatabase = submissionToDatabase;
        }

        // GET: api/values
        [HttpGet]
        public SubmissionStatus Get()
        {
            return _submissionToDatabase.GetSubmissionStatus();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public SubmissionStatus Get(string newStatus)
        {
            return _submissionToDatabase.GetSubmissionStatus();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string newStatus)
        {
            _submissionToDatabase.SetSubmissionStatus(newStatus);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SubmissionDatabase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceOrganizerBackend.Controllers
{
    [Route("api/[controller]")]
    public class SchedulePostedController : Controller
    {
        private readonly ISubmissionToDatabase _submissionToDatabase;

        public SchedulePostedController(ISubmissionToDatabase submissionToDatabase)
        {
            _submissionToDatabase = submissionToDatabase;
        }


        // GET: api/values
        [HttpGet]
        public SchedulePostedStatus Get()
        {
            return _submissionToDatabase.GetSchedulePostedStatus();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public SchedulePostedStatus Get(string newStatus)
        {
            return _submissionToDatabase.GetSchedulePostedStatus();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]SchedulePostedStatus newStatus)
        {
            _submissionToDatabase.SetSchedulePostedStatus(newStatus);
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

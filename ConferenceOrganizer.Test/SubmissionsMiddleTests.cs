using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SubmissionDatabase;

namespace ConferenceOrganizer.Test
{
    [TestClass]
    public class SubmissionsMiddleTests
    {
        [TestMethod]
        public void TestWithNoSort()
        {
            var submissions = new List<Submission>
            {
                new Submission
                {
                    StartTimeInHours = 11,
                    StartTimeInMinutes = 15
                },
                new Submission
                {
                    StartTimeInHours = 10,
                    StartTimeInMinutes = 30
                }
            };
            var mockSubmissionToDatabase = new Mock<ISubmissionToDatabase>();
            mockSubmissionToDatabase.Setup(x => x.GetAllSubmissons()).Returns(() => submissions);

            var submissionToMiddle = new SubmissionsMiddle(mockSubmissionToDatabase.Object);

            var returnedSubmissions = submissionToMiddle.GetAllSubmissons(false);

            Assert.AreEqual(returnedSubmissions, submissions);
        }

        [TestMethod]
        public void TestWithSorting()
        {
            var submissions = new List<Submission>
            {
                new Submission
                {
                    StartTimeInHours = 11,
                    StartTimeInMinutes = 15
                },
                new Submission
                {
                    StartTimeInHours = 10,
                    StartTimeInMinutes = 30
                }
            };
            var mockSubmissionToDatabase = new Mock<ISubmissionToDatabase>();
            mockSubmissionToDatabase.Setup(x => x.GetAllSubmissons()).Returns(() => submissions);
            var submissionToMiddle = new SubmissionsMiddle(mockSubmissionToDatabase.Object);

            var returnedSubmissions = submissionToMiddle.GetAllSubmissons(true);
            
            Assert.AreEqual(returnedSubmissions[0].StartTimeInHours, 10);
        }

        [TestMethod]
        public void TestWithSortingByMinute()
        {
            Submission SubmissionOne = new Submission();
            SubmissionOne.StartTimeInHours = 11;
            SubmissionOne.StartTimeInMinutes = 30;
            Submission SubmissionTwo = new Submission();
            SubmissionTwo.StartTimeInHours = 11;
            SubmissionTwo.StartTimeInMinutes = 15;
            List<Submission> Submissions = new List<Submission>();
            Submissions.Add(SubmissionOne);
            Submissions.Add(SubmissionTwo);
            Mock<ISubmissionToDatabase> MockSubmissionToDatabase = new Mock<ISubmissionToDatabase>();
            MockSubmissionToDatabase.Setup(x => x.GetAllSubmissons()).Returns(() => Submissions);
            SubmissionsMiddle submissionToMiddle = new SubmissionsMiddle(MockSubmissionToDatabase.Object);

            List<Submission> sortedSubmissions = new List<Submission>();
            sortedSubmissions.Add(SubmissionTwo);
            sortedSubmissions.Add(SubmissionOne);
            List<Submission> returnedSubmissions = submissionToMiddle.GetAllSubmissons(true);


            Assert.AreEqual(returnedSubmissions[0].StartTimeInMinutes, 15);
        }
    }
}

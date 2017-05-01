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
            Submission SubmissionOne = new Submission();
            SubmissionOne.StartTimeInHours = 11;
            SubmissionOne.StartTimeInMinutes = 15;
            Submission SubmissionTwo = new Submission();
            SubmissionTwo.StartTimeInHours = 10;
            SubmissionTwo.StartTimeInMinutes = 30;
            List<Submission> Submissions = new List<Submission>();
            Submissions.Add(SubmissionOne);
            Submissions.Add(SubmissionTwo);
            Mock<ISubmissionToDatabase> MockSubmissionToDatabase = new Mock<ISubmissionToDatabase>();
            MockSubmissionToDatabase.Setup(x => x.GetAllSubmissons()).Returns(() => Submissions);

            SubmissionsMiddle submissionToMiddle = new SubmissionsMiddle(MockSubmissionToDatabase.Object);

            List<Submission> returnedSubmissions = submissionToMiddle.GetAllSubmissons(false);

            Assert.AreEqual(returnedSubmissions, Submissions);
        }

        [TestMethod]
        public void TestWithSorting()
        {
            Submission SubmissionOne = new Submission();
            SubmissionOne.StartTimeInHours = 11;
            SubmissionOne.StartTimeInMinutes = 15;
            Submission SubmissionTwo = new Submission();
            SubmissionTwo.StartTimeInHours = 10;
            SubmissionTwo.StartTimeInMinutes = 30;
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

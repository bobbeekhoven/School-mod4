using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            // Create Datasource
            GradesPrototype.Data.DataSource.CreateData();
        }

        [TestMethod]
        public void TestValidGrade()
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "1/1/2012", "Math", "A-", "Very good");
            Assert.AreEqual(grade.AssessmentDate, "1/1/2012");
            Assert.AreEqual(grade.SubjectName, "Math");
            Assert.AreEqual(grade.Assessment, "A-");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBadDate()
        {
            // Attempt to create a grade with a date in the future
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "1/1/2023", "Math", "A-", "Veru good");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDateNotRecocnized()
        {
            // Attempt to create a grade with an unregocnized date
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "13/13/2012", "Math", "A-", "Very good");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBadAssessment()
        {
            // Attempt to create a grade with an assessement outside the range A+ to E-
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "1/1/2012", "Math", "F-", "Terrible");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBadSubject()
        {
            // Attempt to create a grade with an unrecognized subject
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "1/1/2012", "French", "B-", "OK");
        }
    }
}

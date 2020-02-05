using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using bhinterview;

namespace UnitTest
{
    
    [TestClass]
    public class ApplicantTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception),
    "Last name must be longer than one character.")]
        public void ApplicantLastNameException()
        {
            
            Applicant a = new Applicant("Trevor","");
        }

        [TestMethod]
        public void ApplicantConstructors()
        {

            Applicant a = new Applicant("Trevor", "Foley");

            Applicant b = new Applicant();

            b.FirstName = "Trevor";
            b.LastName = "Foley";

            Assert.AreEqual(b, a);
        }


        [TestMethod]
        public void ApplicantCount()
        {

            Applicant a = new Applicant("Trevor", "Foley");

            int previousInstanceCount = a.instanceCount;

            Applicant b = new Applicant();

            b.FirstName = "Trevor";
            b.LastName = "Foley";

            Assert.AreEqual(previousInstanceCount + 1, a.instanceCount);
            Assert.AreEqual(previousInstanceCount + 1, b.instanceCount);
        
        }

    }
}

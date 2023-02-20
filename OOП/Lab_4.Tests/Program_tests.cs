using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_7;
using Lab_7.Module;
using System.Collections.Generic;

namespace Program_tests
{
    [TestClass]
    public class Program_tests
    {
        List<CV> myCvs = new List<CV>(); // визначили list,  type - CV
        CV testCV = new CV();

        [TestMethod]
        public void Test_job()
        {
            // arrange
            Job status = (Job)1;
            var expected = status;
            // act
            //List<CV> actual = Program.InputEl(myCvs);
            var actual = Job.SoftwareDeveloper;
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}


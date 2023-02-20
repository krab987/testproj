using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_7.Module;

namespace CV_tests
{
    [TestClass]
    public class TestExpf
    {
        CV testCV = new CV();
        
        [TestMethod]
        public void days()
        {
            // arrange
            ExpFormat f = ExpFormat.days;
            testCV.Experience = 1.8;

            double expected = testCV.Experience * 365;
            // act
            double actual = testCV.FullStr(f);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void months()
        {
            // arrange
            ExpFormat f = ExpFormat.months;
            testCV.Experience = 1.8;

            double expected = testCV.Experience * 12;
            // act
            double actual = testCV.FullStr(f);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void years()
        {
            // arrange
            ExpFormat f = ExpFormat.years;
            testCV.Experience = 1.8;

            double expected = testCV.Experience;
            // act
            double actual = testCV.FullStr(f);
            // assert
            Assert.AreEqual(expected, actual);
        }  
    }
    [TestClass]
    public class TestAge
    {
        CV testCV = new CV();

        [TestMethod]
        public void CheckAge_returnFalse()
        {
            // arrange
            testCV.Age = 99;
            // act
            bool actual = CV.CheckAge(testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void CheckAge_returnTrue()
        {
            // arrange
            testCV.Age = 40;
            // act
            bool actual = CV.CheckAge(testCV);
            // assert
            Assert.IsTrue(actual);
        }
    }
    [TestClass]
    public class TestWTFormat
    {
        CV testCV = new CV();
        [TestMethod]
        public void LastName_Fn()
        {
            // arrange
            WtFormat w = WtFormat.LastName_Fn;
            testCV.LastName = "Bebra";
            testCV.FirstName = "Vera";

            string expected = "Bebra V.";
            // act
            string actual = testCV.FullStr(w);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FirstName_LastName()
        {
            // arrange
            WtFormat w = WtFormat.FirstName_LastName;
            testCV.LastName = "Bebra";
            testCV.FirstName = "Vera";

            string expected = "Vera Bebra";
            // act
            string actual = testCV.FullStr(w);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LastName_FirstName()
        {
            // arrange
            WtFormat w = WtFormat.LastName_FirstName;
            testCV.LastName = "Bebra";
            testCV.FirstName = "Vera";

            string expected = "Bebra Vera";
            // act
            string actual = testCV.FullStr(w);
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class Test_Parse_TryParse
    {
        CV testCV = new CV();
        [TestMethod]
        public void TestParse_true()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,91,0987654321,8";

            CV expected = new CV("Bober", "Havrilo", "Bebr65", 91, 0987654321, 8);
            int statusIndex = 3;
            Job status = (Job)statusIndex;
            expected.SetJobs(status);
            // act
            CV actual = CV.Parse(str);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestTryParse_true()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,91,0987654321,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void FormatJob_False()
        {
            // arrange
            string str = "polishBebra,Bober,Havrilo,Bebr65,91,0987654321,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void JobMinus_False()
        {
            // arrange
            string str = "-5,Bober,Havrilo,Bebr65,91,0987654321,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void JobMore_False()
        {
            // arrange
            string str = "999,Bober,Havrilo,Bebr65,91,0987654321,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void AgeMinus_False()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,-1,0987654321,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void AgeMore150_False()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,160,0987654321,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TelephoneMinus_False()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,88,-9,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void FormatTelephone_False()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,88,Mmmmm,8";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void ExpMinus_False()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,88,0987654321,-9";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void ExpMore90_False()
        {
            // arrange
            string str = "3,Bober,Havrilo,Bebr65,88,0987654321,100";
            // act
            bool actual = CV.TryParse(str, out testCV);
            // assert
            Assert.IsFalse(actual);
        }
    }
    [TestClass]
    public class TestToString
    {
        CV testCV = new CV();

        [TestMethod]
        public void OverrideToString()
        {
            // arrange
            testCV = CV.Parse("3,Bober,Havrilo,Bebr65,91,0987654321,8");
            string expected = "3,Bober,Havrilo,Bebr65,91,987654321,8";
            // act
            string actual = testCV.ToString();
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}



//[TestMethod]
//public void TestOfTesting()
//{
//    // Arrange
//    int a = 10;
//    int b = 30;

//    //int days = 365;
//    double expected = 40;
//    // Act
//    double actual = testCV.Plus(a, b);
//    // Assert
//    Assert.AreEqual(expected, actual);
//}
using Lab_9.Module.Enums;
using Lab_9.Module.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_9.Module.Papers;
using Lab_9.Module.Interfaces;

namespace TestOffice
{
    [TestClass]
    public class TestsForOffice
    {
        Office testOffice = new Office("testOffice");
        Team testTeam = new Team("teamBacon", "Vlad", "Ignatenko", 19);

        [TestMethod]
        public void TestSetLevelCoping_low()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 8;

            // expected
            LevelsCoping expected = LevelsCoping.low;
            // act
            LevelsCoping actual = testTeam.SetLevelCoping();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSetLevelCoping_normal()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 19;

            // expected
            LevelsCoping expected = LevelsCoping.normal;
            // act
            LevelsCoping actual = testTeam.SetLevelCoping();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSetLevelCoping_high()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 25;

            // expected
            LevelsCoping expected = LevelsCoping.high;
            // act
            LevelsCoping actual = testTeam.SetLevelCoping();
            // assert
            Assert.AreEqual(expected, actual);
        }
        

        [TestMethod]
        public void SetSalaryTeamlead_low()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 17;
            // expected
            int expected = 7000;
            // act
            int actual = testTeam.SetSalaryTeamlead();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetSalaryTeamlead_normal()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 19;
            // expected
            int expected = 10000;
            // act
            int actual = testTeam.SetSalaryTeamlead();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetSalaryTeamlead_high()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 25;
            // expected
            int expected = 13000;
            // act
            int actual = testTeam.SetSalaryTeamlead();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetSalaryTeam_low()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 8; //7000 
            testTeam.AddWorker("test", "test", Ranks.senior); //7500
            testTeam.AddWorker("test", "test", Ranks.junior); //3500
            testTeam.AddWorker("test", "test", Ranks.junior);//3500
            // expected
            int expected = 21500;
            // act
            int actual = testTeam.SetSalaryTeam();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetSalaryTeam_normal()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 19;  //10000
            testTeam.AddWorker("test", "test", Ranks.middle); //6000
            testTeam.AddWorker("test", "test", Ranks.middle); //6000
            testTeam.AddWorker("test", "test", Ranks.junior);//3500
            // expected
            int expected = 25500;
            // act
            int actual = testTeam.SetSalaryTeam();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetSalaryTeam_high()
        {
            // arrange
            testTeam.FinishedProjectsTeam = 25;  //10000
            testTeam.AddWorker("test", "test", Ranks.senior); //7500
            testTeam.AddWorker("test", "test", Ranks.senior); //7500
            testTeam.AddWorker("test", "test", Ranks.senior);//7500
            // expected
            int expected = 35500;
            // act
            int actual = testTeam.SetSalaryTeam();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SumFinishedProjects()
        {
            // arrange
            testOffice.AddTeam(new Team("teamBacon", "Vlad", "Ignatenko", 19));
            testOffice.AddTeam(new Team("teamBacon", "Vlad", "Ignatenko", 20));
            testOffice.AddTeam(new Team("teamBacon", "Vlad", "Ignatenko", 65));
            testOffice.AddTeam(new Team("teamBacon", "Vlad", "Ignatenko", 19));
            testOffice.MyTeams[0].FinishedProjectsTeam = 12;
            testOffice.MyTeams[1].FinishedProjectsTeam = 10;
            testOffice.MyTeams[2].FinishedProjectsTeam = 5;
            testOffice.MyTeams[3].FinishedProjectsTeam = 1;
            // expected
            int expected = 28;
            // act
            int actual = testOffice.SumFinishedProjects();
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}


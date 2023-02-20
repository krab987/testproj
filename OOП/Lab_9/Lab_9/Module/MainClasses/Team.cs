using Lab_9.Module.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.Module.MainClasses
{
    public class Team
    {
        int idForTeamLead = 00000;
        string name;
        int salaryTeam;
        int countProjectsToTeam;
        int finishedProjectsTeam;
        LevelsCoping levelCoping;

        Teamlead teamlead;
        List<Worker> myWorkers;

        public Team() { }
        public Team(string name, string fnameTeamlead, string lnameTeamlead, int countProjectsToTeam)
        {
            idForTeamLead++;
            teamlead = new Teamlead(idForTeamLead, fnameTeamlead, lnameTeamlead);

            this.name = name;
            this.countProjectsToTeam = countProjectsToTeam;

            finishedProjectsTeam = 0;

            levelCoping = LevelsCoping.normal;
            myWorkers = new List<Worker>();
        }

        public void AddWorker(string fn, string ln, Ranks rank)
        {
            Worker temp = new Worker(fn, ln, rank);
            myWorkers.Add(temp);
        }


        public int SetSalaryTeam()
        {
            int res = teamlead.Salary = SetSalaryTeamlead(); ;

            foreach (Worker worker in myWorkers)
            {
                res += worker.Salary;
            }
            return res;
        }
        public int SetSalaryTeamlead()
        {
            levelCoping = SetLevelCoping();

            int salary = 10000;
            if (levelCoping == LevelsCoping.high)
                salary += 3000;
            if (levelCoping == LevelsCoping.low)
                salary -= 3000;

            return salary;
        }
        public LevelsCoping SetLevelCoping()
        {
            if (countProjectsToTeam < finishedProjectsTeam)
                return LevelsCoping.high;
            if (countProjectsToTeam > finishedProjectsTeam)
                return LevelsCoping.low;
            else
                return LevelsCoping.normal;
        }

        public void SortWorkers()
        {
            myWorkers.Sort();
        }

        public override string ToString()
        {
            salaryTeam = SetSalaryTeam();
            //myWorkers.Sort();

            string res = "";
            res += teamlead.FirstName + " " + teamlead.LastName + "'s team: " + name + "\n";
            foreach (Worker pers in myWorkers)
            {
                res += pers.ToString() + "\n";
            }
            res += $"Level coping: {levelCoping} \n";
            res += $"Team earned: {salaryTeam}$ \n";

            return res;
        }




        public List<Worker> MyWorkers { get { return myWorkers; } set { myWorkers = value; } }
        public LevelsCoping LevelCoping { get { return levelCoping; } set { levelCoping = value; } }
        public int CountProjectsToTeam { get { return countProjectsToTeam; } set { countProjectsToTeam = value; } }
        public int FinishedProjectsTeam { get { return finishedProjectsTeam; } set { finishedProjectsTeam = value; } }
        public string Name 
        {
           get { return name; }
           set
            {
                if (!(string.IsNullOrEmpty(value)))
                    name = value;
                else
                    throw new Exception("Error: Name can`t be null or empty!");
            }
        }
        public int SalaryTeam { get { return salaryTeam; } set { salaryTeam = value; } }
    }
}


//public void SetSalaryTeamlead(int salary)
//{
//    levelCoping = SetLevelCoping();

//    double tempSalary = salary;
//    if (levelCoping == LevelsCoping.high)
//        tempSalary = tempSalary + tempSalary * 0.20;
//    if (levelCoping == LevelsCoping.low)
//        tempSalary = tempSalary - tempSalary * 0.25;

//    teamlead.Salary = (int)tempSalary;
//}

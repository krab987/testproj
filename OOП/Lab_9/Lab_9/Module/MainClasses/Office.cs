using Lab_9.Module.Interfaces;
using Lab_9.Module.Papers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.Module.MainClasses
{
    public class Office : IPrintable
    {
        string name;
        int finishedProjectsOffice;
        int countProjectsToTeam;
        List<Team> myTeams;
        List<CampParticipant> campers;
        public Office() { }
        public Office(string name)
        {
            this.name = name;
            myTeams = new List<Team>(); // визначили list,  type - Team
            campers = new List<CampParticipant>(); // визначили list,  type - CampParticipant
        }
        public void AddTeam(Team current)
        {
            myTeams.Add(current);
        }
        public void AddCamper(CampParticipant current)
        {
            campers.Add(current);
        }

        public int SumFinishedProjects()
        {
            int res = 0;
            foreach (var item in myTeams)
            {
                res += item.FinishedProjectsTeam;
            }
            return res;
        }

        public void PrintToDisplay()
        {
            while (true)
            {
                try
                {
                    string res = "------" + name + "------" + "\n";
                    foreach (Team t in myTeams)
                    {
                        res += t.ToString() + "\n";
                    }
                    finishedProjectsOffice = SumFinishedProjects();
                    res += $"Office finished {finishedProjectsOffice.ToString()} projects";

                    res += $"\n \nCamp:\n";
                    foreach (var el in campers)
                    {
                        res += el.ToString() + "\n";
                    }
                    Console.WriteLine(res);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public List<Team> MyTeams { get { return myTeams; } set { myTeams = value; } }
        public List<CampParticipant> Campers { get { return campers; } set { campers = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int FinishedProjectsOffice { get { return finishedProjectsOffice; } set { finishedProjectsOffice = SumFinishedProjects(); } }
        public int CountProjectsToTeam { get { return countProjectsToTeam; } set { countProjectsToTeam = value; } }
    }
}

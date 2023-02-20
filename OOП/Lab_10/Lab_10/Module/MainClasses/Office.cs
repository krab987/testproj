using Lab_10.Module.Interfaces;
using Lab_10.Module.Papers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Module.MainClasses
{
    public class Office : IPrintable
    {
        string name;
        int finishedProjectsOffice = 0;
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

        public void SumFinishedProjects()
        {
            foreach (var item in myTeams)
            {
                finishedProjectsOffice += item.FinishedProjectsTeam;
            }
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
        public int FinishedProjectsOffice { get { return finishedProjectsOffice; } set { finishedProjectsOffice = value; } }
        public int CountProjectsToTeam { get { return countProjectsToTeam; } set { countProjectsToTeam = value; } }
    }
}

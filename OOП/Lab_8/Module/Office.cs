using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Module
{
    public class Office : IPrintable
    {
        string name;
        int finishedProjectsOffice;
        int countProjectsToTeam;
        List<Team> myTeams = new List<Team>(); // визначили list,  type - Team
        public Office() { }
        public Office(string name) 
        {
            this.name = name;
            
        }
        public void AddTeam(string nameTeam, string fnameTeamlead, string lnameTeamlead)
        {
            Team current = new Team(nameTeam, fnameTeamlead, lnameTeamlead);
            myTeams.Add(current);
        }

        public int SumFinishedProjects(int finishedProjectsTeam1, int finishedProjectsTeam2, int finishedProjectsTeam3, int finishedProjectsTeam4)
        {
            throw new NotImplementedException();
        }

        string Name { get { return name; } set { name = value; } }
        int FinishedProjectsOffice { get { return finishedProjectsOffice; } set { finishedProjectsOffice = value; } }
        int CountProjectsToTeam { get { return countProjectsToTeam; } set { countProjectsToTeam = value; } }
    }
}

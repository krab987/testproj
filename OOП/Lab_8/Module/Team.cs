using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Module
{
    public  class Team
    {
        int idForTeamLead = 00000;
        string name;
        int salaryTeam;
        int countProjectsToTeam;
        int finishedProjectsTeam;
        LevelsCoping levelCoping;

        Teamlead teamlead;
        public List <Worker> myWorkers = new List <Worker>();

        public Team() { }
        public Team(string name, string fnameTeamlead, string lnameTeamlead)
        {
            idForTeamLead++;
            Teamlead teamlead = new Teamlead(idForTeamLead, fnameTeamlead, lnameTeamlead);
            this.name = name;
            salaryTeam = 0;

        }

        //LevelsCoping SetLevelCoping(countProjectsToTeam, finishedProjectsTeam)
        //{

        //}
        //int SetSalaryTeamLead(LevelsCoping level)
        //{

        //}


        public LevelsCoping LevelCoping { get { return levelCoping; } set { levelCoping = value; } }
        public int CountProjectsToTeam { get { return countProjectsToTeam; } set { countProjectsToTeam = value; } }
        public int FinishedProjectsTeam { get { return finishedProjectsTeam; } set { finishedProjectsTeam = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int SalaryTeam { get { return salaryTeam; } set { salaryTeam = value; } }

        public int SetSalaryTeamlead(LevelsCoping thLevel)
        {
            throw new NotImplementedException();
        }

        public LevelsCoping SetLevelCoping(int want, int real)
        {
            throw new NotImplementedException();
        }
    }
}

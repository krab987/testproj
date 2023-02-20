using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Module
{
    public class Worker : IWorker
    {
        Ranks rank;

        public Worker() { } 
        public Worker(string Firstname, string Lastname, Ranks rank) 
        { 
            this.FirstName = FirstName; 
            this.LastName = LastName;
            this.rank = rank;

        }

        public Ranks Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Telephone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Salary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

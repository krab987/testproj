using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lab_9.Module.Enums;
using Lab_9.Module.Interfaces;
using Lab_9.Module.Papers;

namespace Lab_9.Module.MainClasses
{
    public class Worker : IWorker, IComparable<Worker>
    {
        Ranks rank;
        string firstName;
        string lastName;
        int age;
        int salary;

        public Worker() { }
        public Worker(string firstName, string lastName, Ranks rank)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.rank = rank;

            if (rank == Ranks.junior) salary = 3500;
            if (rank == Ranks.middle) salary = 6000;
            if (rank == Ranks.senior) salary = 7500;
        }

        public int CompareTo(Worker? other)
        {
            if (other is null)
                throw new ArgumentException("Incorrect input");
            return LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            string res = firstName + " " + lastName + ", " + rank;
            return res;
            //return $"{firstName} {lastName} {rank} \n";
        }


        public Ranks Rank { get { return rank; } set { rank = value; } }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    firstName = value;
                else
                    throw new Exception("Error: firstName can`t be null or empty!");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!(string.IsNullOrEmpty(value)))
                    lastName = value;
                else
                    throw new Exception("Error: lastName can`t be null or empty!");
            }
        }
        public int Age 
        {
            get { return age; }
            set
            {
                if (!(value < 0 || value > 150))
                    age = value;
                else
                    throw new Exception("Error: Age can't be negative or >150 value!");
            }
        }
        public int Telephone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Salary
        {
            get => salary;
            set
            {
                salary = value;
            }
        }
    }
}

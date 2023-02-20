using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_10.Module.Interfaces;

namespace Lab_10.Module.MainClasses
{
    public class Teamlead : IWorker
    {
        int id;
        string firstName;
        string lastName;
        int age;
        int salary;

        public Teamlead() { }
        public Teamlead(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        int Id { get { return id; } set { id = value; } }
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
        public int Salary { get => salary; set => salary = value; }
    }
}

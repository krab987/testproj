using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Module
{
    public class Teamlead : IWorker
    {
        int id;
        string firstName;
        string lastName;
        int age;
        int salary;

        public Teamlead() { }
        public Teamlead(int id,string Fistname, string Lastname)
        {
            this.id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        int Id { get { return id; } set { id = value; } }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = "H"; }
        public int Age { get => age; set => age = value; }
        public int Telephone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Salary { get => salary; set => salary = value; }
    }
}

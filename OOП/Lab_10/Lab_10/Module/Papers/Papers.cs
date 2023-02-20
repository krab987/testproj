using Lab_10.Module.Enums;
using Lab_10.Module.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab_10.Module.Papers
{
    public abstract class Papers : CampParticipant
    {
        string adress;
        short age;
        WorkingCapacity capacity;

        public Papers(string firstName, string lastName, string adress, short age) : base(firstName, lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.adress = adress;
            this.age = age;
            capacity = SetWorkingCapacity(age);
        }

        public virtual WorkingCapacity SetWorkingCapacity(int age)
        {
            WorkingCapacity res = WorkingCapacity.ok;

            if (age >= 65)
                res = WorkingCapacity.tooOld;
            else if (age >= 18 && age < 65)
                res = WorkingCapacity.ok;
            else if (age < 18)
                res = WorkingCapacity.tooYoung;

            return res;
        }

        public string Adress
        {
            get { return adress; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    adress = value;
                else
                    throw new Exception("Error: Adress can`t be null or empty!");
            }
        }
        public short Age
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
        public WorkingCapacity Capacity { get { return capacity; } set { capacity = value; } }
    }
}

using Lab_9.Module.Enums;
using Lab_9.Module.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.Module.Papers
{
    public class CV : Papers
    {
        int experience;
        string about;

        //public CV(){ }

        public CV(string firstName, string lastName, string adress, short age, string about, int exp) : base(firstName, lastName, adress, age)
        {
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            Age = age;
            Capacity = SetWorkingCapacity(age);

            experience = exp;
            About = about;
        }
        public override WorkingCapacity SetWorkingCapacity(int age)
        {
            WorkingCapacity res = WorkingCapacity.ok;

            if (age >= 50)
                res = WorkingCapacity.tooOld;
            else if (age >= 18 && age < 50)
                res = WorkingCapacity.ok;
            else if (age < 18)
                res = WorkingCapacity.tooYoung;

            return res;
        }


        public override string ToString()
        {
            return $"First name:{FirstName}\n Last name: {LastName}\n Adress: {Adress}\n Age: {Age.ToString()} \n Working capasity: {Capacity}\n Experience: {experience} years\n About: {About}";
        }

        public string About
        {
            get { return about; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    about = value;
                else
                    throw new Exception("Error: firstName can`t be null or empty!");
            }
        }
        public int Experience { get { return experience; } set { experience = value; } }    

    }
    
}

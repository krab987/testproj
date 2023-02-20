using Lab_9.Module.Papers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_9.Module.MainClasses
{
    public class CampParticipant
    {
        string firstName;
        string lastName;

        LaborBook laborBook;
        CV cv;

        public CampParticipant(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            laborBook = null;
            cv = null;
        }

        public void FillLabourBook(string adress, short age)
        {

            laborBook = new(firstName, lastName, adress, age);
        }
        public void AddElToLabour(int exp, string company)
        {
            laborBook.AddToLabourBook(exp, company);
        }
        public void FillCV(string adress, short age, string about)
        {
            int experience = laborBook.CountExp();
            cv = new CV(firstName, lastName, adress, age, about, experience);
        }


        public override string ToString()
        {
            string res = "";
            if(laborBook != null)
            {
                res += $"LabourBook: \n{laborBook.ToString()}CV:\n {cv.ToString()}\n";
            }
            else
            {
                res += firstName + " " + lastName + " !please fill documents";
            }
            return res;
        }

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

    }
}

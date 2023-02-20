using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class CV
    {
        private Job jobs;
        private string firstName;
        private string lastName;    
        private string address;
        private short age;
        private int telephone;
        private int experience;
        public WtFormat wt = WtFormat.LastName_Fn;

        public void SetJobs(Job jobs) // метод для встановлення значення private jobs
        {
            this.jobs = jobs;
        }
        public Job GetJobs() // метод для зчитування значення private jobs
        {
            return jobs;
        }
        public string FullName
        {
            get { return FullNameStr(wt); }

        }
        public string FullNameStr(WtFormat w)
        {
            string rez = "";
            switch (w)
            {
                case WtFormat.FirstName_LastName:
                    rez += firstName + " " + lastName;
                    break;

                case WtFormat.LastName_Fn:
                    rez += lastName + " " + firstName[0] + '.';
                    break;
                case WtFormat.LastName_FirstName:
                    rez += lastName + " " + firstName;
                    break;
            }
            return rez;
        }
        public void FormatSearch(int wtIndex)
        {
            wt = (WtFormat)wtIndex;
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

        public void SetAdress(string adress) // метод для встановлення значення private adress
        {
            //перевірка: ім'я не може бути пустим рядком
            if (!string.IsNullOrEmpty(adress))
            {
                this.address = adress;
            }
            else
                throw new Exception("Error: Adress can`t be null or empty!");
        }
        public string GetAdress() // метод для зчитування значення private adress
        {
            return address;
        }

        public void SetAge(short age) // метод для встановлення значення private age
        {
            //перевірка: не можна встановити від'ємний возраст або більше 150
            if (!(age < 0 || age > 150))
                this.age = age;
            else
                throw new Exception("Error: Age can't be negative or >150 value!");
        }
        public short GetAge() 
        {
            return age;
        }
        public void SetTelephone(int telephone) 
        {
            if (!(age < 0))
                this.telephone = telephone;
            else
                throw new Exception("Error: telephone can't be negative value!");
        }
        public int GetTelephone()
        {
            return telephone;
        }
        public void SetExperience(int experience)
        {
            if (!(age < 0))
                this.experience = experience;
            else
                throw new Exception("Error: experience can't be negative value!");
        }
        public int GetExperience()
        {
            return experience;
        }
        public string Get_info()
        {
            return ($"Proffesion = {GetJobs()}\n FullName = {FullName}\n " +
                $"Adress = {GetAdress()}\n Age = {GetAge()}\n " + $"Telephone = {GetTelephone()}\n " +
                $"Experience = {GetExperience()}\n");
        }
    }
}






//public void SetName(string name) // метод для встановлення значення private name
//{
//    //перевірка: ім'я не може бути пустим рядком
//    if (!string.IsNullOrEmpty(name))
//    {
//        this.name = name;
//    }
//    else
//        Console.WriteLine("Error: Name can't be null or empty value!");
//}
//public string GetName() // метод для зчитування значення private name
//{
//    return name;
//}

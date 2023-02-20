using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class CV
    {
        private Job jobs;
        private string firstName;
        private string lastName;
        private string address;
        private short age;
        private int telephone;
        private double experience;

        public WtFormat wt = WtFormat.LastName_Fn;
        public ExpFormat expF = ExpFormat.years;
        public CV(): this("")
        {
            this.firstName = "";
        }
        public CV(string firstName) : this(firstName, "")
        {
            this.firstName = firstName;
        }
        public CV(string firstName, string lastName) : this(firstName, lastName, "")
        {
            this.firstName = firstName;
            this.lastName = lastName;    
        }
        public CV(string firstName, string lastName, string address) : this(firstName, lastName, address, 0)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;  
        }
        public CV(string firstName, string lastName, string address, short age, int telephone=0, double experience = 0)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.age = age; 
            this.telephone = telephone;
            this.experience = experience;
        }

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
            get { return FullStr(wt); }

        }
        public double FullStr(ExpFormat exp)
        {
            double rez = 0;
            switch (exp)
            {
                case ExpFormat.years:
                    rez = experience ;
                    break;
                case ExpFormat.months:
                    rez = experience * 12;
                    break;
                case ExpFormat.days:
                    rez = experience * 365;
                    break;
            }
            return rez;
        }
        public string FullStr(WtFormat w)
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
        public void FormatSearchWt(int wtIndex)
        {
            wt = (WtFormat)wtIndex;
        }
        public void FormatSearchExp(int Index)
        {
            expF = (ExpFormat)Index;
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
        public string Adress
        {
            get { return address; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    address = value;
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
        public int Telephone
        {
            get { return telephone; }
            set 
            {
                if (value > 0)
                {
                    telephone = value;
                }
                else
                    throw new Exception("Error: telephone can't be negative value!");
            }
        }
        public double Experience
        {
            get { return FullStr(expF); }
            set
            {
                if (value > 0 && value < 90)
                {
                    experience = value;
                }
                else
                    throw new Exception("Error: experience can't be negative value or > 90!");
            }
        }

        public string Get_info()
        {
            return ($"Proffesion = {GetJobs()}\n FullName = {FullName}\n " +
                $"Adress = {Adress}\n Age = {Age}\n " + $"Telephone = {Telephone}\n " +
                $"Experience = about {Experience}\n");
        }

        //        this.age = age;
        //    else
        //        throw new Exception("Error: Age can't be negative or >150 value!");

        //public void SetAdress(string adress) // метод для встановлення значення private adress
        //{
        //    //перевірка: ім'я не може бути пустим рядком
        //    if (!string.IsNullOrEmpty(adress))
        //    {
        //        this.address = adress;
        //    }
        //    else
        //        throw new Exception("Error: Adress can`t be null or empty!");
        //}
        //public string GetAdress() // метод для зчитування значення private adress
        //{
        //    return address;
        //}

        //public void SetAge(short age) // метод для встановлення значення private age
        //{
        //    //перевірка: не можна встановити від'ємний возраст або більше 150
        //    if (!(age < 0 || age > 150))
        //        this.age = age;
        //    else
        //        throw new Exception("Error: Age can't be negative or >150 value!");
        //}
        //public short GetAge() 
        //{
        //    return age;
        //}
        //public void SetTelephone(int telephone) 
        //{
        //    if (!(age < 0))
        //        this.telephone = telephone;
        //    else
        //        throw new Exception("Error: telephone can't be negative value!");
        //}
        //public int GetTelephone()
        //{
        //    return telephone;
        //}
        //public void SetExperience(int experience)
        //{
        //    if (!(age < 0))
        //        this.experience = experience;
        //    else
        //        throw new Exception("Error: experience can't be negative value!");
        //}
        //public int GetExperience()
        //{
        //    return experience;
        //}
        //public string Get_info()
        //{
        //    return ($"Proffesion = {GetJobs()}\n FullName = {FullName}\n " +
        //        $"Adress = {GetAdress()}\n Age = {GetAge()}\n " + $"Telephone = {GetTelephone()}\n " +
        //        $"Experience = {GetExperience()}\n");
        //}
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

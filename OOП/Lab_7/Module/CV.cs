using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab_7.Module
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

        public static int counter;
        public static int retirementAge = 65;

        public WtFormat wt = WtFormat.LastName_Fn;
        public ExpFormat expF = ExpFormat.years;

        public CV() : this("")
        {
            counter++;
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
        public CV(string firstName, string lastName, string address, short age, int telephone = 0, double experience = 0)
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

        public double FullStr(ExpFormat exp)
        {
            double rez = 0;
            switch (exp)
            {
                case ExpFormat.years:
                    rez = experience;
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
        public static bool CheckAge(CV cv)
        {
            bool res = true;
            if (cv.Age >= retirementAge)
            {
                res = false;
                counter--;
            }

            return res;
        }

        [JsonPropertyName("Job")]
        public Job Job
        {
            get { return jobs; }
        }
        public static int Counter => counter;
        [JsonPropertyName("First Name")]
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
        [JsonPropertyName("Last Name")]
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
        [JsonPropertyName("Adress")]
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
        [JsonPropertyName("Age")]
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
        [JsonPropertyName("Telephone")]
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
        [JsonPropertyName("Experience")]
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
        [JsonIgnore]
        public string FullName
        {
            get { return FullStr(wt); }

        }
        [JsonIgnore]
        public ExpFormat ExpF
        {
            get
            {
                return ExpF;
            }
            set { ExpF = value; }
        }

        public static CV Parse(string s)
        {
            CV cv = new CV();
            counter--;
            string[] lines = s.Split(new char[] { ',' });

            int indLines = -1;
            int statusIndex = Convert.ToInt32(lines[++indLines]);
            Job status = (Job)statusIndex;
            cv.SetJobs(status);
            if (statusIndex > (int)Job.Analyst || statusIndex < 0)
                throw new Exception("There isnt this prof");

            cv.FirstName = lines[++indLines];
            cv.LastName = lines[++indLines];
            cv.Adress = lines[++indLines];
            cv.Age = Convert.ToInt16(lines[++indLines]);
            cv.Telephone = Convert.ToInt32(lines[++indLines]);
            cv.Experience = Convert.ToDouble(lines[++indLines]);

            if (lines.Length != 7)
                throw new Exception("not enough arguments (it must be 7)");

            return cv;
        }
        public static bool TryParse(string s, out CV cv)
        {
            cv = null;
            bool valid = false;

            try
            {
                cv = Parse(s);
                valid = true;

                if (s == null)
                    throw new Exception("It cant be null");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error  : " + ex.Message);
            }
            if (!valid)
                counter--;

            return valid;
        }

        public override string ToString()
        {
            return ($"{(int)(GetJobs())},{FirstName},{LastName},{Adress},{Age},{Telephone},{Experience}");
        }
        public string Get_info()
        {
            return ($"Proffesion = {GetJobs()}\n FullName = {FullName}\n " +
                $"Adress = {Adress}\n Age = {Age}\n " + $"Telephone = {Telephone}\n " +
                $"Experience = about {Experience}\n");
        }

        public override bool Equals(object obj)
        {
            bool res = true;
            var cv = obj as CV;

            if (cv == null)
                res = false;
            if (cv.GetJobs() != GetJobs())
                res = false;
            if (cv.FullName != FullName)
                res = false;
            if (cv.Adress != Adress)
                res = false;
            if (cv.Age != Age)
                res = false;
            if (cv.Telephone != Telephone)
                res = false;
            if (cv.Experience != Experience)
                res = false;

            return res;
        }
    }
}


//public int Plus(int x, int y)
//{
//    int res = x + y;
//    return res;
//}



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

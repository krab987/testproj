using Lab_6;
using Lab_6.Module;
public class Program 
{
    static void Main(string[] args)
    {
        CV cv = new CV(34);
        cv.Age = null;
        List<CV> myCvs = new List<CV>(); // визначили list,  type - CV
        while (true)
        {
            switch (InputMenu())
            {
                case 0:
                    InputEl(myCvs);
                    break;
                case 1:
                    InputFastEl(myCvs);
                    break;
                case 2:
                    Print(myCvs);
                    break;
                case 3:
                    FindEl(myCvs);
                    break;
                case 4:
                    DelEl(myCvs);
                    break;
                case 5:
                    Behaviour(myCvs);
                    break;
                case 6:
                    StaticBehaviour(myCvs);
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
        } // MENU
    }

    public static int InputMenu()
    {
        int menuIndex = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Menu.: ");
                for (int i = 0; i <= (int)Menu.Exit; i++)
                {
                    Console.WriteLine(i + " - " + (Menu)i);
                }
                menuIndex = Convert.ToInt32(Console.ReadLine());
                if (menuIndex > (int)Menu.Exit)
                    throw new Exception("It`s out of range");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return menuIndex;
    }

    public static List<CV> InputEl(List<CV> myCvs)
    {
        CV current = new CV();

        while (true)
        {
            try
            {

                Console.WriteLine("Choose your proffesion.: ");
                for (int i = 0; i <= (int)Job.Analyst; i++)
                {
                    Console.WriteLine(i + " - " + (Job)i);
                }
                int statusindex = Convert.ToInt32(Console.ReadLine());
                Job status = (Job)statusindex;
                current.SetJobs(status);
                if (statusindex > (int)Job.Analyst || statusindex < 0)
                    throw new Exception("Choose from this");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.WriteLine("Write your Firstname");
                string firstname = Console.ReadLine();
                current.FirstName = firstname;
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.WriteLine("Write your Lastname");
                current.LastName = Console.ReadLine();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.WriteLine("Write your address");
                current.Adress = Console.ReadLine();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.WriteLine("Write your age");
                current.Age = (Convert.ToInt16(Console.ReadLine()));
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.WriteLine("Write your telephone");
                current.Telephone = (Convert.ToInt32(Console.ReadLine()));
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
        while (true)
        {
            try
            {
                Console.WriteLine("Write your experience in years (double)");
                current.Experience = (Convert.ToDouble(Console.ReadLine()));
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        myCvs.Add(current);
        return myCvs;
    }
    public static void InputFastEl(List<CV> myCvs)
    {
        CV current = new CV();

        Console.WriteLine("Input All info separated by commas");
        string strCommas = Console.ReadLine();
        //current = CV.Parse(strCommas);
        bool result = CV.TryParse(strCommas, out current);
        if (result)
            myCvs.Add(current);
    }
    public static void FindEl(List<CV> myCvs)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("0 - find by index, 1 - by LastName");
                int searchF = int.Parse(Console.ReadLine());
                if (searchF > 1 || searchF < 0)
                    throw new Exception("must be 0 or 1");
                switch (searchF)
                {
                    case 0:
                        Console.WriteLine("Write index");
                        int indexfind = int.Parse(Console.ReadLine());
                        Console.WriteLine($"{myCvs[indexfind].Get_info()}");
                        break;
                    case 1:
                        Console.WriteLine("Write LastName");
                        string s = Console.ReadLine();
                        CV? result = myCvs.Find(p => p.LastName == s);
                        if (result != null)
                            Console.WriteLine(result.Get_info());
                        //CV result = myCvs.Find(p => p.LastName == s);
                        //if (myCvs.Exists(p => p.LastName == s))
                        //    Console.WriteLine(result.Get_info());
                        break;
                }
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
    public static void DelEl(List<CV> myCvs)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("0 - find by index, 1 - by LastName, 2 - remove all");
                int searchF = int.Parse(Console.ReadLine());
                if (searchF > 2 || searchF < 0)
                    throw new Exception("must be 0 or 1 or 2");
                switch (searchF)
                {
                    case 0:
                        Console.WriteLine("Write index");
                        int indexfind = int.Parse(Console.ReadLine());
                        myCvs.RemoveAt(indexfind);
                        break;
                    case 1:
                        Console.WriteLine("Write LastName");
                        string s = Console.ReadLine();
                        myCvs.RemoveAll(p => p.LastName == s);
                        break;
                    case 2:
                        myCvs.Clear();
                        break;
                }
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
    public static void Behaviour(List<CV> myCvs)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Write your index: ");          //index to work with
                int indFormat = Convert.ToInt32(Console.ReadLine());
                if (indFormat >= myCvs.Count || indFormat < 0)
                    throw new Exception("I can`t find it");

                Console.WriteLine("Choose format of your name: ");   //Choose format of your name
                for (int i = 0; i <= (int)WtFormat.LastName_Fn; i++)
                {
                    Console.WriteLine(i + " - " + (WtFormat)i);
                }
                int formatIndex = Convert.ToInt32(Console.ReadLine());
                if (formatIndex > (int)WtFormat.LastName_Fn)
                    throw new Exception("I can`t find it");
                myCvs[indFormat].FormatSearchWt(formatIndex);

                Console.WriteLine("Choose format of your experience: ");   //Choose format of your experience
                for (int i = 0; i <= (int)ExpFormat.days; i++)
                {
                    Console.WriteLine(i + " - " + (ExpFormat)i);
                }
                int formatIndexExp = Convert.ToInt32(Console.ReadLine());
                if (formatIndexExp > (int)ExpFormat.days)
                    throw new Exception("I can`t find it");
                myCvs[indFormat].FormatSearchExp(formatIndexExp);
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
    public static void StaticBehaviour(List<CV> myCvs)
    {
        foreach (CV bober in myCvs)
        {
            if (!(CV.CheckAge(bober)))
            {
                Console.WriteLine($"{bober.FullName} mast be retired. His/her CV is deleted");
                myCvs.Remove(bober);
            }

        }
    }

    private static void Print(List<CV> myCvs)
    {
        for (int i = 0; i < myCvs.Count; i++)
        {
            Console.WriteLine($"Index =  {i} \n {myCvs[i].Get_info()} ");
        }
        Console.WriteLine($"Count of all CVs : {Convert.ToString(CV.Counter)}");
    }
}



//0,fn,ln,ad,50,0987654321,2
//0,ebbra,kdfdg,kdf,80,08765,6
//0,ebbra,ling,dsfdg,86,6,7
//0,Grisha,Bebrovich,Vol,50,0987654321,4
//4,Andrei,Antonovich,ghtp4,86,09876432,9
//3,Bober,Havrilo,Bebr65,91,0987654321,8
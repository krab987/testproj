using Lab_4;
using Lab_4.Module;


int count_el = InputCountEl();
int current = 0;

CV[] myCvs = new CV[count_el]; // визначили масив з кількістю резюме

while (true)
{
    switch (InputMenu())
    {
        case 0:
            current = InputEl(count_el, current, myCvs);
            break;
        case 1:
            current = InputFast(count_el, current, myCvs);
            break;
        case 2:
            Print();
            break;
        case 3:
            FindEl(current, myCvs);
            break;
        case 4:
            DeleteEl(current, myCvs);
            break;
        case 5:
            Behaviour(myCvs);
            break;
        case 6:
            StaticBehaviour(current, myCvs);
            break;
        case 7:
            Environment.Exit(0);
            break;
    }
} // MENU

int InputCountEl()
{
    int count_el = 1;
    while (true)
    {
        try
        {
            Console.WriteLine("How much objects do you want to save?");
            count_el = Convert.ToInt32(Console.ReadLine());

            if (count_el <= 0)
            {
                throw new Exception("It can`t be <= 0");
            }
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");

        }
    }  //input count_el

    return count_el;
}
int InputMenu()
{
    int menuIndex = 0;
    Console.WriteLine("Menu.: ");
    for (int i = 0; i <= (int)Menu.Exit; i++)
    {
        Console.WriteLine(i + " - " + (Menu)i);
    }

    try
    {
        menuIndex = Convert.ToInt32(Console.ReadLine());
        if (menuIndex > (int)Menu.Exit)
            throw new Exception("It`s out of range");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Format Exception");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }

    return menuIndex;
}

int InputEl(int count_el, int current, CV[] myCvs)
{
    if (current < count_el)
    {
        myCvs[current] = new CV();
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
                myCvs[current].SetJobs(status);
                if (statusindex <= (int)Job.Analyst)
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
                Console.WriteLine("Write your Firstname");
                string firstname = Console.ReadLine();
                myCvs[current].FirstName = firstname;
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
                myCvs[current].LastName = Console.ReadLine();
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
                myCvs[current].Adress = Console.ReadLine();
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
                myCvs[current].Age = (Convert.ToInt16(Console.ReadLine()));
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
                myCvs[current].Telephone = (Convert.ToInt32(Console.ReadLine()));
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
                myCvs[current].Experience = (Convert.ToDouble(Console.ReadLine()));
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        current++;
    }
    else
    {
        Console.WriteLine("Max count is reached");
    }

    return current;
}
int InputFast(int count_el, int current, CV[] myCvs)
{
    if (current < count_el)
    {
        myCvs[current] = new CV();
        Console.WriteLine("Input All info separated by commas");
        string strCommas = Console.ReadLine();
        //myCvs[current] = CV.Parse(strCommas);
        bool result = CV.TryParse(strCommas, out myCvs[current]);

        if (result == true)
        {
            current++;
        }

    }
    else
    {
        Console.WriteLine("Max count is reached");
    }

    return current;
}
void FindEl(int current, CV[] myCvs)
{
    string? s = "";
    int digit = 0;
    int nondigit = 0;

    Console.WriteLine("Do u want to find:");
    for (int i = 0; i <= (int)WtFormat.LastName_Fn; i++)
    {
        Console.WriteLine(i + " - " + (WtFormat)i);
    }

    int fullOr = Convert.ToInt32(Console.ReadLine());
    //myCvs[current].FullNameStr(WtFormat.LastName_FirstName); //

    while (true)
    {
        try
        {

            Console.WriteLine("Write index OR name");
            s = Console.ReadLine();

            foreach (char ch in s)
            {
                if (char.IsDigit(ch))
                {
                    digit++;
                }
                else
                {
                    nondigit++;
                }
            }
            if (digit > 0 && nondigit == 0)
            {
                int indexfind = Convert.ToInt32(s);
                Console.WriteLine($"Index = {myCvs[indexfind].Get_info()}");
            }
            if (nondigit > 0 && digit == 0)
            {
                FindName(s);
            }
            else
            {
                Console.WriteLine("Zero results");
            }

            break;
        }
        catch (Exception)
        {
            Console.WriteLine("Exception");

        }
    }
}
void DeleteEl(int current, CV[] myCvs)
{
    string sDel = "";
    int digitDel = 0;
    int nondigitDel = 0;

    while (true)
    {
        try
        {
            Console.WriteLine("Write index OR name, you want to delete");

            sDel = Console.ReadLine();

            foreach (char ch in sDel)
            {
                if (char.IsDigit(ch))
                {
                    digitDel++;
                }
                else
                {
                    nondigitDel++;
                }
            }
            if (digitDel > 0 && nondigitDel == 0)
            {
                int indexDel = Convert.ToInt32(Console.ReadLine());
                Del_info(indexDel);
            }
            else if (nondigitDel > 0 && digitDel == 0)
            {
                DelName(sDel);
            }
            else
            {
                Console.WriteLine("Nothing to delete");
            }

            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception" + ex.Message);
        }
    }
}
void Behaviour(CV[] myCvs)
{
    int indFormat = 0;

    while (true)
    {
        try
        {
            Console.WriteLine("Write your index: ");          //index to work with
            indFormat = Convert.ToInt32(Console.ReadLine());
            if (indFormat >= current || indFormat < 0)
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
void StaticBehaviour(int current, CV[] myCvs)
{
    for (int i = 0; i < current-1; i++)
    {
        if (!(CV.CheckAge(myCvs[i])))
        {
            Console.WriteLine($"{myCvs[i].FullName} mast be retired. His/her CV is deleted");
            Del_info(i);
        }
    }
}

void Del_info(int del)
{
    if (del == current - 1)
        current--;
    else
    {
        for (int i = del; i < current; i++)
        {
            myCvs[i] = myCvs[i + 1];
        }
        current--;
    }
}
void DelName(string name)
{
    for (int i = 0; i < current; i++)
    {
        if (myCvs[i].FirstName == name)
        {
            Del_info(i);
        }
    }
}
void FindName(string name)
{
    for (int i = 0; i < current; i++)
    {
        if (myCvs[i].FirstName == name)
        {
            Console.WriteLine($"Index =  {i} {myCvs[i].Get_info()}");
        }
    }
}


void Print()
{
    for (int i = 0; i < current; i++)
    {
        Console.WriteLine($"Index =  {i} \n {myCvs[i].Get_info()} ");
    }
    Console.WriteLine($"Count of all CVs : {Convert.ToString(CV.Counter)}");
}








//0,fn,ln,ad,50,0987654321,2
//0,ebbra,kdfdg,kdf,80,08765,6
//0,ebbra,ling,dsfdg,86,6,7
//0,Grisha,Bebrovich,Vol,50,0987654321,4
//4,Andrei,Antonovich,ghtp4,86,09876432,9
//3,Bober,Havrilo,Bebr65,91,0987654321,8
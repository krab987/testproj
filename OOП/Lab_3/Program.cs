using Lab_3;

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
            Print();
            break;
        case 2:
            FindEl(current, myCvs);
            break;
        case 3:
            DeleteEl(current, myCvs);
            break;
        case 4:
            Behaviour(myCvs);
            break;
        case 5:
            Environment.Exit(0);
            break;
    }
} // MENU

static int InputCountEl()
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

        catch (OverflowException)
        {
            Console.WriteLine("Exception");

        }
        catch (FormatException)
        {
            Console.WriteLine("Exception");

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
void FindEl(int current, CV[] myCvs)
{
    string s = "";
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
                Console.WriteLine($"Index =  {indexfind} {myCvs[indexfind].Get_info()}");
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
        catch (Exception)
        {

            Console.WriteLine("Exception");
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
            Console.WriteLine("Write your index: ");
            indFormat = Convert.ToInt32(Console.ReadLine());
            if (indFormat >= current || indFormat < 0)
                throw new Exception("I can`t find it");

            Console.WriteLine("Choose format of your name: ");
            for (int i = 0; i <= (int)WtFormat.LastName_Fn; i++)
            {
                Console.WriteLine(i + " - " + (WtFormat)i);
            }
            int formatIndex = Convert.ToInt32(Console.ReadLine());
            if (formatIndex > (int)WtFormat.LastName_Fn)
                throw new Exception("I can`t find it");
            myCvs[indFormat].FormatSearchWt(formatIndex);

            Console.WriteLine("Choose format of your experience: ");
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
        catch (FormatException)
        {
            Console.WriteLine("Error: Format");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
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
}
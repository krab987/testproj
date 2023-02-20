using Lab_1;

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

}
int count = 0;

CV[] myCvs = new CV[count_el]; // визначили масив з кількістю резюме

int menuIndex = 0;
do
{
    Console.WriteLine("Menu.: ");
    for (int i = 0; i <= (int)Menu.Exit; i++)
    {
        Console.WriteLine(i + " - " + (Menu)i);
    }

    menuIndex = Convert.ToInt32(Console.ReadLine());
    switch (menuIndex)
    {
        case 0:

            if (count <= count_el)
            {
                while (true)
                {

                    try
                    {
                        myCvs[count] = new CV();

                        Console.WriteLine("Choose your proffesion.: ");
                        for (int i = 0; i <= (int)Job.Analyst; i++)
                        {
                            Console.WriteLine(i + " - " + (Job) i);
                        }

                        int statusindex = Convert.ToInt32(Console.ReadLine());
                        Job status = (Job)statusindex;
                        myCvs[count].jobs = status;
                        Console.WriteLine("Write your name");
                        myCvs[count].name = Console.ReadLine();
                        Console.WriteLine("Write your address");
                        myCvs[count].address = Console.ReadLine();
                        Console.WriteLine("Write your age");
                        myCvs[count].age = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Write your telephone");
                        myCvs[count].telephone = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write your experience");
                        myCvs[count].experience = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write your email");
                        myCvs[count].email = Console.ReadLine();
                        Console.WriteLine("Write something about yourself");
                        myCvs[count].other = Console.ReadLine();

                        count++;
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("FormatException");
                    }
                    catch (OutOfMemoryException ex)
                    {
                        Console.WriteLine("OutOfMemoryException");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("ArgumentOutOfRangeException");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception");
                    }
                }
            }
            else
            {
                Console.WriteLine("Max count is reached");
            }
            break;
        case 1:
            Print();
            break;
        case 2:
            string s = "";
            int digit = 0;
            int nondigit = 0;

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
                        Print_info(indexfind);
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
            break;
        case 3:

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
            break;
        case 4:
            Environment.Exit(0);
            break;
    }

} while (menuIndex != 4);

void Del_info(int del)
{
    if (del == count - 1)
        count--;
    else
    {
        for (int i = del; i < count; i++)
        {
            myCvs[i] = myCvs[i + 1];
        }
    }
}
void DelName(string name)
{
    for (int i = 0; i < count; i++)
    {
        if (myCvs[i].name == name)
        {
            Del_info(i);
        }
    }
}

void FindName(string name)
{
    for (int i = 0; i < count; i++)
    {
        if (myCvs[i].name == name)
        {
            Print_info(i);
        }
    }
}

void Print()
{
    for (int i = 0; i < count; i++)
    {
        Print_info(i);
    }
}
void Print_info(int index)
{
    Console.WriteLine($"Index = {index}\n Proffesion = {myCvs[index].jobs}\n Name = {myCvs[index].name}\n " + 
        $"Adress = {myCvs[index].address}\n Age = {myCvs[index].age}\n " + $"Telephone = {myCvs[index].telephone}\n " +
        $"Experience = {myCvs[index].experience}\n Email = {myCvs[index].email}\n " + $"Other = {myCvs[index].other}\n");
}

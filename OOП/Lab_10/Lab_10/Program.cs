using System.Collections.Generic;
using System;
using Lab_10;
using Lab_10.Module.MainClasses;
using Lab_10.Module.Enums;
using Lab_10.Module.Papers;

//deligate void Action();
//deligate bool Predicate<T..>(T value);
//delegate int Func<T, T..> (string value)
//
//Action action;
//Predicate<int> predicate
//Func<string, int> func     return last - int value

public class Program
{
    static void Main(string[] args)
    {
        Office myOffice = new Office("BoberCompuhter");

        Predicate<Office> pred = InputTeams;
        pred += InputWorkers;

        Action action = myOffice.SumFinishedProjects;
        action += myOffice.PrintToDisplay;

        while (true)
        {
            switch (InputMenu())
            {
                case 0:
                    if (!pred(myOffice))
                        Console.WriteLine("Try again");
                    break;
                case 1:
                    FinishProjects(myOffice);
                    break;
                case 2:
                    InputCamperz(myOffice);
                    break;
                case 3:
                    FillDocuments(myOffice);
                    break;
                case 4:
                    SortElInTeams(myOffice);
                    break;
                case 5:
                    action.Invoke();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        } // MENU
    }



    static void SortElInTeams(Office myOffice)
    {
        foreach (var el in myOffice.MyTeams)
        {
            el.SortWorkers();
        }
        Console.WriteLine("Workers is sorted");
    }

    static void FillDocuments(Office myOffice)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Part1 - LabourBook");
                Console.WriteLine("CampParticipants");
                int indCamp = 0;
                foreach (var el in myOffice.Campers)
                {
                    Console.WriteLine($"{indCamp} - {el.FirstName} {el.LastName}");
                    indCamp++;
                }

                Console.WriteLine("Type CampParticipant id");
                int indCampCur = Convert.ToInt32(Console.ReadLine());
                if (indCampCur < 0)
                    throw new Exception("It cant be < 0");
                if (indCampCur > indCamp-1)
                    throw new Exception("It cant be > " + Convert.ToString(indCamp - 1));

                Console.WriteLine("Type adress and age though space");
                string[] temp = Console.ReadLine().Split(' ');
                string adress = temp[0]; short age = Convert.ToInt16(temp[1]);
                myOffice.Campers[indCampCur].FillLabourBook(adress, age);

                Console.WriteLine("Type experience and company, you want to add");
                while (true)
                {
                    try
                    {
                        temp = Console.ReadLine().Split(' ');

                        if (temp[0] == "s") break; //exit

                        myOffice.Campers[indCampCur].AddElToLabour(Convert.ToInt32(temp[0]), temp[1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                }
                Console.WriteLine("Part2 - CV");
                Console.WriteLine("Type something about you");
                myOffice.Campers[indCampCur].FillCV(adress, age, Console.ReadLine());
                break;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
    static void InputCamperz(Office myOffice)
    {
        string[] temp;

        Console.WriteLine("Input CampParticipants  (stop - 's')");
        Console.WriteLine("Fname, Lname through a space");

        while (true)
        {
            try
            {
                temp = Console.ReadLine().Split(' ');

                if (temp[0] == "s") //exit
                    break;

                CampParticipant current = new CampParticipant(temp[0], temp[1]);
                myOffice.AddCamper(current);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void FinishProjects(Office myOffice)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Teams");
                for (int i = 0; i < 4; i++)
                    Console.WriteLine($"{i} - {myOffice.MyTeams[i].Name}");

                Console.WriteLine("Type Team id");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Input finished projects to add");
                int compProjects = Convert.ToInt32(Console.ReadLine());

                myOffice.MyTeams[index].FinishedProjectsTeam += compProjects;
                break;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        
    }
    static bool InputWorkers(Office myOffice)
    {
        string[] temp;
        int indTeam = 0;
        Ranks rank;

        Console.WriteLine("Input Workers (next team - type 'n', stop - 's')");
        Console.WriteLine("Fname, Lname, index of rank");
        Console.WriteLine("Ranks.: ");
        for (int i = 0; i <= (int)Ranks.senior; i++)
        {
            Console.WriteLine(i + " - " + (Ranks)i);
        }

        try
        {
            Console.WriteLine("Input workers to Team " + myOffice.MyTeams[indTeam].Name);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        while (true)
        {
            try
            {
                temp = Console.ReadLine().Split(' ');

                if (temp[0] == "s")
                    break;
                if (temp[0] == "n")
                {
                    indTeam++;
                    Console.WriteLine("Input workers to Team " + myOffice.MyTeams[indTeam].Name);
                }
                else
                {
                    int rankIndex = Convert.ToInt32(temp[2]);
                    if (rankIndex > (int)Ranks.senior || rankIndex < 0)
                    {
                        throw new Exception("Input correct rank");
                    }
                    else
                    {
                        rank = (Ranks)rankIndex;
                    }
                    myOffice.MyTeams[indTeam].AddWorker(temp[0], temp[1], rank);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        return true;
    }
    static bool InputTeams(Office myOffice)
    {
        Console.WriteLine("Input TeamName, Fname teamlead, Lname teamlead, Projects to team, through a space (mew team - enter)");

        int countTeams = 0;
        string[] temp;

        myOffice.MyTeams.Clear();
        while (countTeams < 4)
        {
            try
            {
                temp = Console.ReadLine().Split(' ');
                Team current = new Team(temp[0], temp[1], temp[2], Convert.ToInt32(temp[3]));
                myOffice.AddTeam(current);
                countTeams++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return true;
    }


    static int InputMenu()
    {
        int menuIndex = -1;

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
                if (menuIndex > (int)Menu.Exit || menuIndex < 0)
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
}






//0
//teamBacon Vlad Ignatenko 19
//teamBalance Ban Melioda 25
//teamLada Anasteisha Reloh 32
//teamCon Bodya Ladur 29
//Kare Doda 1
//Vlad Pepu 0
//Benr Goj 2
//More i 1
//n
//Bobr Nara 0
//VBalik Nervsii 1
//Natasha Venskii 1
//Proj Jaba 2
//s


//Team teamBacon = new Team("teamBacon", "Vlad", "Ignatenko", 19, 50000);
//Team teamBalance = new Team("teamBalance", "Ban", "Melioda", 25, 54000);
//Team teamBaloon = new Team("teamBaloon", "Simba", "Farah", 31, 60000);
//Team teamBanana = new Team("teamBanana", "Sasha", "Nanig", 15, 46000);

//teamBacon.AddWorker("b", "b", Ranks.senior);
//teamBacon.AddWorker("b", "b", Ranks.senior);
//teamBacon.AddWorker("b", "b", Ranks.senior);
//teamBacon.AddWorker("b", "b", Ranks.senior);

//teamBaloon.AddWorker("b", "b", Ranks.senior);
//teamBaloon.AddWorker("b", "b", Ranks.senior);
//teamBaloon.AddWorker("b", "b", Ranks.senior);
//teamBaloon.AddWorker("b", "b", Ranks.senior);

//myOffice.AddTeam(teamBacon);
//myOffice.AddTeam(teamBalance);
//myOffice.AddTeam(teamBaloon);
//myOffice.AddTeam(teamBanana);

//Console.WriteLine(myOffice.ToString());
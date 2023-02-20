using Lab_8.Module;
using System.Collections.Generic;
using System;
using System.IO;
using System.Security.Principal;
using System.Text.Json;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Worker> myWorkers = new List<Worker>(); // визначили list,  type - Worker


        Office myOffice = new Office("BoberCompuhter");
        myOffice.AddTeam("teamBacon", "Andrew", "Ignatenko");
        myOffice.AddTeam("teamBanana", "Sasha","Nanig");
        myOffice.AddTeam("teamBaloon", "Simba", "Farah");
        myOffice.AddTeam("teamBalance", "Ban", "Melioda");


        //office1.

    }

}
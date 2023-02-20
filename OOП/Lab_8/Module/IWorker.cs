using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Module
{
    public interface IWorker
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        int Telephone { get; set; }
        int Salary { get; set; }

        //public int Experience { get; set; }


    }
}

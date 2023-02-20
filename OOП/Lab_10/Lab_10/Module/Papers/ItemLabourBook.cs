using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Module.Papers
{
    public class ItemLabourBook
    {
        int exp;
        string company;

        public ItemLabourBook(int exp, string company)
        {
            this.exp = exp;
            this.company = company;
        }
        public override string ToString()
        {
            return $"{exp.ToString()} years in {company} company";
        }

        public int Exp { get { return exp; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.Module.Papers
{
    public class LaborBook : Papers
    {
        List<ItemLabourBook> myExps;
        public LaborBook(string firstName, string lastName, string adress, short age) : base(firstName, lastName, adress, age)
        {
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            Age = age;

            myExps = new List<ItemLabourBook>();
        }

        public void AddToLabourBook(int exp, string comp)
        {
            ItemLabourBook temp = new ItemLabourBook(exp, comp);
            myExps.Add(temp);
        }
        public int CountExp()
        {
            int res = 0;
            foreach (ItemLabourBook item in myExps)
            {
                res += item.Exp;
            }

            return res;
        }

        public override string ToString()
        {
            string res = "";

            foreach (var el in myExps)
            {
                res += el.ToString() + "\n";
            }

            return res;
        }

    }                                                                                                                                                                  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer Cust1 = new Customer("John Snow", 039995555, 146);
            Customer Cust2 = new Customer("Melissa Bay", 034888333, 123);
            Console.WriteLine(Cust1);
            Console.WriteLine(Cust2);
            
        }
    }
}

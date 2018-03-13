using Material_Mapping.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeBuyers initializeBuyers = new InitializeBuyers();
            List<Buyer> buyers = initializeBuyers.Initialize();

            Console.Write("HI");

            Console.ReadKey();
        }
    }
}

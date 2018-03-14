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
            Buyers buyer = new Buyers();
            List<Buyer> buyers = buyer.InitializeBuyers();
            uint materialUnits;
            Console.WriteLine(System.Configuration.ConfigurationManager.AppSettings["unitsMaterialMsg"]);
            while (true)
            {
                if (!uint.TryParse(Console.ReadLine(), out materialUnits))
                {
                    Console.WriteLine(System.Configuration.ConfigurationManager.AppSettings["repeatUnitsMaterialMsg"]);
                }
                else
                {
                    break;
                }
            }
            buyer.ComputeBuyers(buyers, materialUnits);
            Console.ReadKey();
        }
    }
}

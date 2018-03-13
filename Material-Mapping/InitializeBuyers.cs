using Material_Mapping.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Mapping
{
    public class InitializeBuyers
    {
        public List<Buyer> Initialize()
        {
            List<Buyer> buyers = new List<Buyer>();
            string[] lines = System.IO.File.ReadAllLines(@"data\file.csv");
            foreach (string line in lines)
            {
                var values = line.Split(';');

                Buyer newBuyer = new Buyer(values[0], int.Parse(values[1]), Double.Parse(values[2]));
                buyers.Add(newBuyer);
            }
            List<Buyer> sorterBuyers = buyers.OrderByDescending(o => o.PricePerUnit).ToList();
            return sorterBuyers;
        }
    }
}
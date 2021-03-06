﻿using Material_Mapping.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Mapping
{
    public class Buyers
    {
        public List<Buyer> InitializeBuyers()
        {
            List<Buyer> buyers = new List<Buyer>();
            string[] lines = System.IO.File.ReadAllLines(@System.Configuration.ConfigurationManager.AppSettings["buyersFilePath"]);
            foreach (string line in lines)
            {
                var values = line.Split(char.Parse(System.Configuration.ConfigurationManager.AppSettings["csvFileSeprator"]));
                if (int.Parse(values[1]) > 0 && Double.Parse(values[2]) > 0)
                {
                    Buyer newBuyer = new Buyer(values[0], int.Parse(values[1]), Double.Parse(values[2]));
                    buyers.Add(newBuyer);
                }
                else
                {
                    Console.WriteLine(values[0] + " " + System.Configuration.ConfigurationManager.AppSettings["skipMsg"] + "\n");
                }
                
            }
            List<Buyer> sortedBuyers = buyers.OrderByDescending(o => o.PricePerUnit).ToList();
            return sortedBuyers;
        }

        public void ComputeBuyers(List<Buyer> buyers, int materialUnits)
        {
            Console.WriteLine("\n\n" + System.Configuration.ConfigurationManager.AppSettings["tableHeader1"] 
                + "\t" + System.Configuration.ConfigurationManager.AppSettings["tableHeader2"]);
            Double totalProfit = new Double();
            foreach (Buyer buyer in buyers)
            {
                if (materialUnits > 0)
                {
                    if (materialUnits - buyer.MaterialAmount >= 0)
                    {
                        Console.WriteLine(buyer.Name + "\t" + buyer.MaterialAmount);
                        totalProfit = totalProfit + buyer.Price;
                    }
                    else
                    {
                        Console.WriteLine(buyer.Name + "\t" + materialUnits);
                    }
                    materialUnits = materialUnits - buyer.MaterialAmount;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(System.Configuration.ConfigurationManager.AppSettings["totalProMsg"] + totalProfit);
            if (materialUnits > 0)
            {
                Console.WriteLine("\n" + System.Configuration.ConfigurationManager.AppSettings["matRemainMsg"] + materialUnits);
            }
        }
    }
}
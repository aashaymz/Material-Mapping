using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Mapping.models
{
    public class Buyer
    {
        private Double pricePerUnit;

        public String Name { get; set; }

        public Double MaterialAmount { get; set; }

        public Double Price { get; set; }

        public Double PricePerUnit {
            get
            {
                return pricePerUnit;
            }
            set
            {
                pricePerUnit = Price / (Double)Price;
            }
        }
    }
}

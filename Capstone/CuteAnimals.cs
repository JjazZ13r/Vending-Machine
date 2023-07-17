using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
     public abstract class CuteAnimal : ISpeakable
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Variety { get; set; }
        public string Code { get; }
        public int AmountSold { get; set; } = 0;


        public Dictionary<string, decimal> Pricing = new Dictionary<string, decimal>();
        public List<CuteAnimal> Animals = new List<CuteAnimal>();


        public virtual string MakeSound()
        {
            return "ZZZzzzZzZZ";
        }

        public CuteAnimal(string code, string variety, decimal price, string productName)
        {
            this.Code = code;
            this.Variety = variety;
            this.Price = price;
            this.ProductName = productName;
        }


    }
}

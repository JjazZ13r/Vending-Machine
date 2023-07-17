using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Pony : CuteAnimal, ISpeakable
    {




        public override string MakeSound()
        {
            return "Neigh, Neigh, Yay!";
        }

        public Pony(string code, string variety, decimal price, string productName) : base(code, variety, price, productName)
        {

        }
    }
}

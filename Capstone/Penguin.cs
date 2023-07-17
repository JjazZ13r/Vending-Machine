using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Penguin : CuteAnimal, ISpeakable
    {







        public override string MakeSound()
        {
            return "Squawk, Squawk, Whee!";
        }

        public Penguin(string code, string variety, decimal price, string productName) : base(code, variety, price, productName)
        {

        }
    }
}

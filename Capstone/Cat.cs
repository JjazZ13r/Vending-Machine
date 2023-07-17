using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Cat : CuteAnimal, ISpeakable
    {







        public override string MakeSound()
        {
            return "Meow, Meow, Meow!";
        }

        public Cat(string code, string variety, decimal price, string productName) : base(code, variety, price, productName)
        {

        }

    }
}

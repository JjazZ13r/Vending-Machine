using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Duck : CuteAnimal, ISpeakable
    {

        






        public override string MakeSound()
        {
            return "Quack, Quack, Splash!";
        }

        public Duck(string code, string variety, decimal price, string productName) : base (code,variety,price,productName)
        {
            
        }
    }
}

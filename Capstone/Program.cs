using System;
using System.Security.Cryptography.X509Certificates;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine Start = new VendingMachine();
            Start.Interaction();
            
        }
    }
}

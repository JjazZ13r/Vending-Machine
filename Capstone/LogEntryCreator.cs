using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public static class LogEntryCreator
    {


        public static string FeedMoneyLog(decimal deposit,decimal balance)
        {
            return  $"FEED MONEY: ${deposit} ${balance}";
        }

        public static string DispenseProductLog(string variety, string code, decimal price, decimal balance)
        {
            return $"{variety} {code} ${price} ${balance}";
        }

        public static string ReturnMoneyLog(decimal change, decimal balance)
        {
            return $"GIVE CHANGE: ${change} ${balance}";
        }


    }
}

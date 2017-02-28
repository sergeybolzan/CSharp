using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    namespace AccountNS
    {
        class Account
        {
            public int Number { get; set; }
            public string Password { get; set; }
            public int Balance { get; set; }
            public Account(int balance)
            {
                Random rnd = new Random();
                Number = rnd.Next(10000000, 100000000);
                Password = rnd.Next(1000, 10000).ToString();
                Balance = balance;
            }
        }
    }
}


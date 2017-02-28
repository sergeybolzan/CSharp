using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.BankNS;
using Bankomat.ClientNS;
using Bankomat.AccountNS;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите свое имя: ");
            Client client = new Client();
            client.Name = Console.ReadLine();
            Account account = new Account(1000);
            Bank bank = new Bank(account, client);
            bank.Print();
            try
            {
                bank.InsertCard();
                bank.Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
    
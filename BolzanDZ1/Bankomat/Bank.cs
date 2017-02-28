using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.AccountNS;
using Bankomat.ClientNS;

namespace Bankomat
{
    namespace BankNS
    {
        class Bank
        {
            private Account account;
            private Client client;
            public Bank(Account account, Client client)
            {
                this.account = account;
                this.client = client;
            }
            public void Print()
            {
                Console.WriteLine("Имя клиента: {0}, номер карточки: {1}, пароль: {2}, баланс: {3} руб.", client.Name, account.Number, account.Password, account.Balance);
            }
            public void InsertCard()
            {
                Console.WriteLine("Для работы со счетом введите пароль карточки: ");
                for (int i = 3; i > 0; i--)
                {
                    if (Console.ReadLine() == account.Password) return;
                    else if (i > 1) Console.WriteLine("Неверный пароль!\nВведите пароль еще раз, осталось попыток: {0}", i - 1);
                    else throw new Exception("Попытки исчерпаны!");
                }
            }
            public void Menu()
            {
                while (true)
                {
                    Console.WriteLine("\nДля вывода баланса на экран введите 1\nДля пополнения счета введите 2\nЧтобы снять деньги со счета введите 3\nДля выхода введите 4");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Баланс = {0} руб.", account.Balance);
                            Console.WriteLine("Чтобы вернуться в меню введите 1\nДля выхода введите 2");
                            SubMenu();
                            break;
                        case "2":
                            Console.Write("Введите сумму для пополнения: ");
                            int sum;
                            while (true)
                            {
                                if (Int32.TryParse(Console.ReadLine(), out sum)) break;
                                else Console.WriteLine("Неверный ввод!");
                            }
                            account.Balance += sum;
                            Console.WriteLine("Баланс пополнен на {0} руб. Баланс = {1} руб.\nЧтобы вернуться в меню введите 1\nДля выхода введите 2", sum, account.Balance);
                            SubMenu();
                            break;
                        case "3":
                            Console.Write("Введите сумму для снятия: ");
                            while (true)
                            {
                                if (Int32.TryParse(Console.ReadLine(), out sum)) break;
                                else Console.WriteLine("Неверный ввод!");
                            }
                            if (sum <= account.Balance)
                            {
                                account.Balance -= sum;
                                Console.WriteLine("Со счета снято {0} руб. Баланс = {1} руб.\nЧтобы вернуться в меню введите 1\nДля выхода введите 2", sum, account.Balance);
                                SubMenu();
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно средств!");
                            }
                            break;
                        case "4":
                            throw new Exception("Заберите карточку!");
                        default:
                            Console.WriteLine("Неверный ввод!");
                            break;
                    }
                }
            }
            private void SubMenu()
            {
                while (true)
                {
                    string variant = Console.ReadLine();
                    if (variant == "1") break;
                    else if (variant == "2") throw new Exception("Заберите карточку!");
                    else Console.WriteLine("Неверный ввод!");
                }
            }
        }
    }
}

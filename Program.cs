using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AplikacijaIgrice
{

    class Program
    {
        static Random random = new Random();

        static int RandomUOpsegu(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        static void SvemirskiOkrsaj()
        {
            // Почетно стање
            int energijaStita = 100;
            int brojRaketa = 3;
            int brojNeprijatelja = 0;

            // Ток игре
            for (int sektor = 1; sektor <= 5; sektor++)
            {
                // 1. Прикажи тренутно стање
                Console.WriteLine($"Сектор: {sektor}/5");
                Console.WriteLine($"Енергија штита: {energijaStita}");
                Console.WriteLine($"Ракете: {brojRaketa}");

                // 2. Генерисати насумични догађај
                double dogadjaj = random.NextDouble();

                if (dogadjaj <= 0.8)
                {
                    // 80% шанса за појаву непријатељског брода
                    int hpNeprijatelja = 50;
                    Console.WriteLine("Непријатељски брод се појавио!");
                    Console.WriteLine($"HP непријатеља: {hpNeprijatelja}");

                    while (hpNeprijatelja > 0 && energijaStita > 0)
                    {
                        Console.WriteLine("Изаберите акцију: (a) Ласерски напад, (b) Ракета, (c) Покушај бекства ");
                        string akcija = Console.ReadLine();

                        if (akcija == "a")
                        {
                            // Ласерски напад
                            if (random.NextDouble() <= 0.8)
                            {
                                // Погодак непријатељског брода
                                int steta = RandomUOpsegu(10, 20);
                                hpNeprijatelja -= steta;
                                Console.WriteLine($"Погодак! HP непријатеља: {hpNeprijatelja}");
                            }
                            else
                            {
                                // Промашај непријатељског брода
                                Console.WriteLine("Промашај!");
                            }
                        }
                        else if (akcija == "b")
                        {
                            // Ракета
                            if (brojRaketa > 0)
                            {
                                // Испалити ракету
                                brojRaketa--;
                                if (random.NextDouble() <= 0.9)
                                {
                                    // Ракета погодила брод
                                    int steta = RandomUOpsegu(30, 40);
                                    hpNeprijatelja -= steta;
                                    Console.WriteLine($"Погодак! HP непријатеља: {hpNeprijatelja}");
                                }
                                else
                                {
                                    // Промашај
                                    Console.WriteLine("Промашај!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Немате више ракета!");
                            }
                        }
                        else if (akcija == "c")
                        {
                            // Покушај бекства
                            if (random.NextDouble() <= 0.5)
                            {
                                Console.WriteLine("Успешно бекство!");
                                break;
                            }
                        }

                        // Ако је непријатељ уништен, приказати поруку о победи
                        if (hpNeprijatelja <= 0)
                        {
                            Console.WriteLine("Победа! Непријатељски брод је уништен");
                            brojNeprijatelja++;
                            break;
                        }
                        else
                        {
                            // Непријатељ узвраћа ударац
                            if (random.NextDouble() <= 0.7)
                            {
                                // Непријатељ нас је погодио
                                int steta = RandomUOpsegu(10, 15);
                                energijaStita -= steta;
                                Console.WriteLine($"Непријатељ нас је погодио, наш HP: {energijaStita}");
                            }
                            else
                            {
                                Console.WriteLine("Непријатељ је промашио");
                            }
                        }

                        // Провера да ли имамо енергије за наставак игре
                        if (energijaStita <= 0)
                        {
                            Console.WriteLine("Ваш свемирски брод је уништен, игра је завршена!");
                            break;
                        }
                    }
                }
                else
                {
                    // 20% шанса за миран пролазак
                    Console.WriteLine("Миран пролазак кроз сектор");
                }

                // Провера да ли имамо енергије за наставак игре
                if (energijaStita <= 0)
                {
                    Console.WriteLine("Ваш свемирски брод је уништен, игра је завршена!");
                    break;
                }
            }

            if (energijaStita > 0)
            {
                Console.WriteLine($"Честитамо! Победили сте у свемирском окршају и уништили {brojNeprijatelja} бродова");
            }
            else
            {
                Console.WriteLine("Нажалост, изгубили сте игру.");
            }
        }

        static void Main(string[] args)
        {
            //Cirilicna slova - podesiti Console.OutputEncoding 
            Console.OutputEncoding = Encoding.UTF8;
            SvemirskiOkrsaj();
            Console.ReadLine();
        }
    }

}

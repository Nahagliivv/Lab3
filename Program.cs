using System;
using System.Threading;

namespace Lab3
{
    public partial class Driver
    {
        //Разное всякое
    }
    public class Program
    {
        static bool check = false;
        static Bus[] mas2 = null;
        public static void Main()
        {
            string a;
            while (true)
            {
                while (true){
                    Console.WriteLine("Выберите нужный вам пункт меню:");
                    Console.WriteLine("1 - создать автобусы");
                    Console.WriteLine("2 - вывести автобусы(writeline)");
                    Console.WriteLine("3 - вывести список автобусов для заданного номера маршрута");
                    Console.WriteLine("4 - вывести список автобусов, которые эксплуатируются больше заданного срока");
                    Console.WriteLine("5 - очистить консоль");
                    Console.WriteLine("6 - конструкторы");
                    Console.WriteLine("7 - вывод возраста выбранного автобуса");
                    Console.WriteLine("8 - вывод информации о классе");
                    Console.WriteLine("9 - пример работы out");
                    Console.WriteLine("10 - Вывод автобусов(ToString)");
                    Console.WriteLine("11 - анонимный тип");
                    Console.WriteLine("12 - вызов закрытого конструктора");
                    Console.WriteLine("0 - для выхода");
                    a = Console.ReadLine();
                    if (a == "1")
                    {
                        check = true;
                        break;
                    }
                    if (a == "2" && check == false || a == "3" && check == false || a == "4" && check == false || a == "7" && check == false || a == "10" && check == false)
                    {
                        Console.Clear();
                        Console.WriteLine($"_____________________________________________");
                        Console.WriteLine("Автобусов в базе данных нет!");
                        Console.WriteLine($"_____________________________________________");
                    } else { break; }
                }
                switch (a)
                {
                    case "1":
                        mas2 = Bus.CreateABuses(ref check);
                        continue;
                    case "2":
                        Bus.Output(ref mas2);
                        continue;
                    case "3":
                        Bus.ListBusRoutNumber(ref mas2);
                        continue;
                    case "4":
                        Bus.ListBusYear(ref mas2);
                        continue;
                    case "5":
                        Console.Clear();
                        continue;
                    case "6":
                        Construct();
                        continue;
                    case "7":
                        Bus.BusYear(mas2);
                        continue;
                    case "8":
                        Bus.Info();
                        continue;
                    case "9":
                        int numb = 0;
                        Bus.Primer(out numb);
                        Console.WriteLine(numb);
                        continue;
                    case "10":
                        Bus.OutputWithToString(mas2);
                        continue;
                    case "11":
                        Anonimous();
                        continue;
                    case "12":
                        SchoolBus.OutputPrivate();
                        continue;
                    case "0": break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка ввода, такого пункта в меню нет");
                        continue;
                }
                break;
            }
            
        }
        static void Construct() //пример конструкторов
        {
            Bus bus1 = new Bus("Силин В.", "MaMyMaBb", 1234, "вертолёт(игрушечнiй)", 1999, 69228);
            Bus bus2 = new Bus();
            Console.WriteLine($"Автобус bus1");
            Console.WriteLine($"Имя и инициалы водителя: {bus1.Drivername}");
            Console.WriteLine($"Номер автобуса: {bus1.BusNumber}");
            Console.WriteLine($"Номер маршрута: {bus1.RoutNumber}");
            Console.WriteLine($"Марка автобуса: {bus1.BrandBus}");
            Console.WriteLine($"Год начала эксплуатации: {bus1.YearOfStartUse}");
            Console.WriteLine($"Пробег: {bus1.Mileage}");
            Console.WriteLine($"_____________________________________________");
            Console.WriteLine($"Автобус bus2");
            Console.WriteLine($"Имя и инициалы водителя: {bus2.Drivername}");
            Console.WriteLine($"Номер автобуса: {bus2.BusNumber}");
            Console.WriteLine($"Номер маршрута: {bus2.RoutNumber}");
            Console.WriteLine($"Марка автобуса: {bus2.BrandBus}");
            Console.WriteLine($"Год начала эксплуатации: {bus2.YearOfStartUse}");
            Console.WriteLine($"Пробег: {bus2.Mileage}");
            Console.WriteLine($"_____________________________________________");
        }
        static void Anonimous()
        {
            var anonimous = new {firstname =  "Анон",age =  777,secondname =  "Я аноним" };
            Console.WriteLine($"_____________________________________________");
            Console.WriteLine($"Данный тип: {anonimous.GetType()}");
            Console.WriteLine($"_____________________________________________");
        }
    }
}


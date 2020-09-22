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
        //static Bus[] Unarguments() //Функция для создания экземпляров в массиве
        //{
        //    string a;
        //    int count;
        //    while (true)
        //    {
        //        while (true)
        //        {
        //            Console.WriteLine("Введите количество автобусов(0 для отмены):");
        //            a = Console.ReadLine();
        //            try
        //            {
        //                count = Convert.ToInt32(a);
        //                break;
        //            }
        //            catch (SystemException)
        //            {
        //                Console.WriteLine("Некорректно введено кол-во автобусов");
        //                continue;
        //            }

        //        }
        //        if (count < 0)
        //        {
        //            Console.WriteLine("Некорректно введено кол-во автобусов");
        //            continue;
        //        }
        //        else break;
        //    }
        //    Bus[] mas = new Bus[count];
        //    for (int i = 0; i < count; i++)
        //    {
        //        mas[i] = new Bus();
        //        Console.WriteLine($"Автобус номер {i + 1}");
        //        Console.WriteLine("Введите фамилию и инициалы водителя:");
        //        mas[i].Drivername = Console.ReadLine();
        //        Console.WriteLine("Введите номер автобуса(8 знаков)");
        //        mas[i].BusNumber = Console.ReadLine();
        //        if (mas[i].BusNumber.Length != 8)
        //        {
        //            while (mas[i].BusNumber.Length != 8)
        //            {
        //                Console.WriteLine("Некорректно введён номер автобуса");
        //                Console.WriteLine("Введите номер автобуса(8 знаков):");
        //                mas[i].BusNumber = Console.ReadLine();

        //            }
        //        }
        //        while (true)
        //        {
        //            Console.WriteLine("Введите номер маршрута(максимум -- 6-значное число):");
        //            a = Console.ReadLine();
        //            if (a.Length > 6 || string.IsNullOrWhiteSpace(a))
        //            {
        //                Console.WriteLine("Номер маршрута введён неверно");
        //                continue;
        //            }
        //            try
        //            {
        //                mas[i].RoutNumber = Convert.ToUInt32(a);
        //                break;
        //            }
        //            catch (SystemException)
        //            {
        //                Console.WriteLine("Номер маршрута введён неверно");
        //            }
        //        }
        //        Console.WriteLine("Введите марку автобуса:");
        //        mas[i].BrandBus = Console.ReadLine();
        //        while (true)
        //        {
        //            Console.WriteLine("Введите год начала эксплуатации(4 числа):");
        //            a = Console.ReadLine();
        //            if (a.Length != 4)
        //            {
        //                Console.WriteLine("Год начала эксплуатации введён неверно");
        //                continue;
        //            }
        //            try
        //            {
        //                mas[i].YearOfStartUse = Convert.ToUInt32(a);
        //                break;
        //            }
        //            catch (SystemException)
        //            {
        //                Console.WriteLine("Год начала эксплуатации");
        //            }
        //        }
        //        while (true)
        //        {
        //            Console.WriteLine("Введите пробег автобуса в километрах:");
        //            a = Console.ReadLine();
        //            try
        //            {
        //                mas[i].Mileage = Convert.ToDouble(a);
        //                break;
        //            }
        //            catch (SystemException)
        //            {
        //                Console.WriteLine("Пробег введён неверно");
        //            }
        //        }
        //    }
        //    Console.Clear();
        //    return mas;
        //}

        //static void Output(Bus[] mas) //функция для вывода каждого экзмемпляра
        //{
        //    for (int i = 0; mas.Length > i; i++)
        //    {
        //        Console.WriteLine($"Автобус номер {i + 1}");
        //        Console.WriteLine($"Имя и инициалы водителя: {mas[i].Drivername}");
        //        Console.WriteLine($"Номер автобуса: {mas[i].BusNumber}");
        //        Console.WriteLine($"Номер маршрута: {mas[i].RoutNumber}");
        //        Console.WriteLine($"Марка автобуса: {mas[i].BrandBus}");
        //        Console.WriteLine($"Год начала эксплуатации: {mas[i].YearOfStartUse}");
        //        Console.WriteLine($"Пробег: {mas[i].Mileage}");
        //        Console.WriteLine($"_____________________________________________");
        //    }
        //    Bus.CountOfBuses = mas.Length;
        //    Console.WriteLine($"Всего автобусов:{Bus.CountOfBuses}");  
        //}
        //static void ListBusRoutNumber(Bus[] mas) //функция для вывода автобусов по номеру маршрута
        //{
        //    uint b;
        //    byte count = 0;
        //    while (true)
        //    {
        //        Console.WriteLine("Введите номер маршрута, по которому вы хотите найти автобусы: ");
        //        string a = Console.ReadLine();
        //        try
        //        {
        //            b = Convert.ToUInt32(a);
        //            break;
        //        }
        //        catch (SystemException)
        //        {
        //            Console.WriteLine("Значение введено некорректно");
        //        }
        //    }
        //    for (int i = 0; mas.Length > i; i++)
        //    {
        //        if (mas[i].RoutNumber == b)
        //        {
        //            Console.WriteLine($"Автобус номер {i + 1}");
        //            count++;
        //        }
        //    }
        //    if (count == 0)
        //    {
        //        Console.WriteLine($"Автобусов с таким номером маршрута нет!");
        //    }

        //}
        //static void ListBusYear(Bus[] mas) //функция вывода автобусов, которые используются дольше заданного срока
        //{

        //    uint b;
        //    byte count = 0;
        //    while (true)
        //    {
        //        Console.WriteLine("Введите количество лет. Автобусы, которые используются больше заданного срока будут выведены на экран");
        //        string a = Console.ReadLine();
        //        if (Convert.ToUInt32(a) > 100 || Convert.ToUInt32(a) < 0)
        //        {
        //            Console.WriteLine("Некорректное кол-во лет");
        //            continue;
        //        }
        //        try
        //        {
        //            b = Convert.ToUInt32(a);
        //            break;
        //        }
        //        catch (SystemException)
        //        {
        //            Console.WriteLine("Некорректное кол-во лет");
        //            continue;
        //        }
        //    }
        //    for (int i = 0; mas.Length > i; i++)
        //    {
        //        int year = 2020;
        //        if (b < (year - mas[i].YearOfStartUse))
        //        {
        //            Console.WriteLine($"Автобус номер {i + 1}");
        //            count++;
        //        }
        //    }
        //    if (count == 0)
        //    {
        //        Console.WriteLine("Подходящих автобусов нет...");
        //    }

        //} 

        //static void BusYear(Bus[] mas)//функция вывода возраста автобуса по его номеру
        //{
        //    while (true)
        //    {
        //        byte year;
        //        while (true)
        //        {
        //            Console.WriteLine("Введите номер автобуса(0 - для возвращения обратно):");
        //            string a = Console.ReadLine();

        //            if (a == "0")
        //            {
        //                Main();
        //            }
        //            try
        //            {
        //                year = Convert.ToByte(a);
        //                break;
        //            }
        //            catch (SystemException)
        //            {
        //                Console.WriteLine("Номер введён некорректно");
        //                continue;
        //            }
        //        }
        //        if (year > Convert.ToByte(mas.Length) || year < 0)
        //        {
        //            Console.WriteLine("Такого номера автобуса нетттт...");
        //            continue;
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Возраст автобуса номер {year}: {2020 - mas[year - 1].YearOfStartUse}");
        //            break;
        //        }
        //    }
        //}
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


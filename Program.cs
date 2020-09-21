using System;
using System.Threading;

namespace Lab3
{
    class Program
    {
        static bool check = false;
        static Bus[] mas2 = null;
        static void Main()
        {
            Console.WriteLine("Выберите нужный вам пункт меню:");
            Console.WriteLine("1 - создать автобусы");
            Console.WriteLine("2 - вывести автобусы");
            Console.WriteLine("3 - вывести список автобусов для заданного номера маршрута");
            Console.WriteLine("4 - вывести список автобусов, которые эксплуатируются больше заданного срока");
            Console.WriteLine("5 - очистить консоль");
            Console.WriteLine("6 - конструкторы");
            Console.WriteLine("7 - вывод возраста автобуса\n8 - чисто по приколу");
            Console.WriteLine("0 - для выхода");
            string a = Console.ReadLine();
            if (a == "1")
            {
                check = true;
            }
            if (a == "2" && check == false || a == "3" && check == false || a == "4" && check == false || a == "7" && check == false)
            {
                Console.Clear();
                Console.WriteLine("Автобусов в базе данных нет!");
                Main();
            }
            switch (a)
            {
                case "1":
                    mas2 = Unarguments();
                    Main();
                    break;
                case "2":
                    Output(mas2);
                    Main();
                    break;
                case "3":
                    ListBusRoutNumber(mas2);
                    Main();
                    break;
                case "4":
                    ListBusYear(mas2);
                    Main();
                    break;
                case "5":
                    Console.Clear();
                    Main();
                    break;
                case "6":
                    Construct();
                    Main();
                    break;
                case "7":
                    BusYear(mas2);
                    Main();
                    break;
                case "8":
                    Bus.Info();
                    Main();
                    break;
                case "0":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода, такого пункта в меню нет");
                    Main();
                    break;
            }
        }
        static Bus[] Unarguments()
        {
            string a;
            int count;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Введите количество автобусов(0 для отмены):");
                    a = Console.ReadLine();
                    try
                    {
                        count = Convert.ToInt32(a);
                        break;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Некорректно введено кол-во автобусов");
                        continue;
                    }

                }
                if (count < 0)
                {
                    Console.WriteLine("Некорректно введено кол-во автобусов");
                    continue;
                }
                else break;
            }
            Bus[] mas = new Bus[count];
            for (int i = 0; i < count; i++)
            {
                mas[i] = new Bus();
                Console.WriteLine($"Автобус номер {i + 1}");
                Console.WriteLine("Введите фамилию и инициалы водителя:");
                mas[i].Drivername = Console.ReadLine();
                Console.WriteLine("Введите номер автобуса(8 знаков)");
                mas[i].BusNumber = Console.ReadLine();
                if (mas[i].BusNumber.Length != 8)
                {
                    while (mas[i].BusNumber.Length != 8)
                    {
                        Console.WriteLine("Некорректно введён номер автобуса");
                        Console.WriteLine("Введите номер автобуса(8 знаков):");
                        mas[i].BusNumber = Console.ReadLine();

                    }
                }
                while (true)
                {
                    Console.WriteLine("Введите номер маршрута(максимум -- 6-значное число):");
                    a = Console.ReadLine();
                    if (a.Length > 6 || string.IsNullOrWhiteSpace(a))
                    {
                        Console.WriteLine("Номер маршрута введён неверно");
                        continue;
                    }
                    try
                    {
                        mas[i].RoutNumber = Convert.ToUInt32(a);
                        break;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Номер маршрута введён неверно");
                    }
                }
                Console.WriteLine("Введите марку автобуса:");
                mas[i].BrandBus = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Введите год начала эксплуатации(4 числа):");
                    a = Console.ReadLine();
                    if (a.Length != 4)
                    {
                        Console.WriteLine("Год начала эксплуатации введён неверно");
                        continue;
                    }
                    try
                    {
                        mas[i].YearOfStartUse = Convert.ToUInt32(a);
                        break;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Год начала эксплуатации");
                    }
                }
                while (true)
                {
                    Console.WriteLine("Введите пробег автобуса в километрах:");
                    a = Console.ReadLine();
                    try
                    {
                        mas[i].Mileage = Convert.ToDouble(a);
                        break;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Пробег введён неверно");
                    }
                }
            }
            Console.Clear();
            return mas;
        }
        static void Output(Bus[] mas)
        {
            for (int i = 0; mas.Length > i; i++)
            {
                Console.WriteLine($"Автобус номер {i + 1}");
                Console.WriteLine($"Имя и инициалы водителя: {mas[i].Drivername}");
                Console.WriteLine($"Номер автобуса: {mas[i].BusNumber}");
                Console.WriteLine($"Номер маршрута: {mas[i].RoutNumber}");
                Console.WriteLine($"Марка автобуса: {mas[i].BrandBus}");
                Console.WriteLine($"Год начала эксплуатации: {mas[i].YearOfStartUse}");
                Console.WriteLine($"Пробег: {mas[i].Mileage}");
                Console.WriteLine($"_____________________________________________");
            }
            Bus.CountOfBuses = mas.Length;
            Console.WriteLine($"Всего автобусов:{Bus.CountOfBuses}");  
        }
        static void ListBusRoutNumber(Bus[] mas)
        {
            uint b;
            byte count = 0;
            while (true)
            {
                Console.WriteLine("Введите номер маршрута, по которому вы хотите найти автобусы: ");
                string a = Console.ReadLine();
                try
                {
                    b = Convert.ToUInt32(a);
                    break;
                }
                catch (SystemException)
                {
                    Console.WriteLine("Значение введено некорректно");
                }
            }
            for (int i = 0; mas.Length > i; i++)
            {
                if (mas[i].RoutNumber == b)
                {
                    Console.WriteLine($"Автобус номер {i + 1}");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"Автобусов с таким номером маршрута нет!");
            }

        }
        static void ListBusYear(Bus[] mas)
        {

            uint b;
            byte count = 0;
            while (true)
            {
                Console.WriteLine("Введите количество лет. Автобусы, которые используются больше заданного срока будут выведены на экран");
                string a = Console.ReadLine();
                if (Convert.ToUInt32(a) > 100 || Convert.ToUInt32(a) < 0)
                {
                    Console.WriteLine("Некорректное кол-во лет");
                    continue;
                }
                try
                {
                    b = Convert.ToUInt32(a);
                    break;
                }
                catch (SystemException)
                {
                    Console.WriteLine("Некорректное кол-во лет");
                    continue;
                }
            }
            for (int i = 0; mas.Length > i; i++)
            {
                int year = 2020;
                if (b < (year - mas[i].YearOfStartUse))
                {
                    Console.WriteLine($"Автобус номер {i + 1}");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Подходящих автобусов нет...");
            }

        }
        static void Construct()
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
        static void BusYear(Bus[] mas)
        {
            while (true)
            {
                byte year;
                while (true)
                {
                    Console.WriteLine("Введите номер автобуса(0 - для возвращения обратно):");
                    string a = Console.ReadLine();

                    if (a == "0")
                    {
                        Main();
                    }
                    try
                    {
                        year = Convert.ToByte(a);
                        break;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Номер введён некорректно");
                        continue;
                    }
                }
                if (year > Convert.ToByte(mas.Length) || year < 0)
                {
                    Console.WriteLine("Такого номера автобуса нетттт...");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Возраст автобуса номер {year}: {2020 - mas[year - 1].YearOfStartUse}");
                    break;
                }
            }
        }
    }
}


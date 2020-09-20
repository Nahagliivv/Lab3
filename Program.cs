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
            Console.WriteLine("0 - для выхода");
            string a = Console.ReadLine();
            if (a == "1")
            {
                check = true;
            }
            if (a == "2" && check == false || a == "3" && check ==false || a == "4" && check == false)
            {
                Console.Clear();
                Console.WriteLine("Автобусов в базе данных нет!");
                Main();
            }
            switch (a)
            {
                case "1":
                    mas2 = unarguments();
                    Main();
                    break;
                case "2":
                    output(mas2);
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
                    construct();
                    Main();
                    break;
                case "7":
                    construct();
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
        static Bus[] unarguments()
        {
            string a;
            Console.WriteLine("Введите количество автобусов:");
            int count = Convert.ToInt32(Console.ReadLine());
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
            re:
                Console.WriteLine("Введите номер маршрута(максимум -- 6-значное число):");
                a = Console.ReadLine();
                if (a.Length > 6 || string.IsNullOrWhiteSpace(a))
                {
                    Console.WriteLine("Номер маршрута введён неверно");
                    goto re;
                }
                try
                {
                    mas[i].RoutNumber = Convert.ToUInt32(a);
                }
                catch (SystemException)
                {
                    Console.WriteLine("Номер маршрута введён неверно");
                    goto re;
                }
                Console.WriteLine("Введите марку автобуса:");
                mas[i].BrandBus = Console.ReadLine();
            re2:
                Console.WriteLine("Введите год начала эксплуатации(4 числа):");
                a = Console.ReadLine();
                if (a.Length != 4)
                {
                    Console.WriteLine("Год начала эксплуатации введён неверно");
                    goto re2;
                }
                try
                {
                    mas[i].YearOfStartUse = Convert.ToUInt32(a);
                }
                catch (SystemException)
                {
                    Console.WriteLine("Год начала эксплуатации");
                    goto re2;
                }
            re3:
                Console.WriteLine("Введите пробег автобуса в километрах:");
                a = Console.ReadLine();
                try
                {
                    mas[i].Mileage= Convert.ToDouble(a);
                }
                catch (SystemException)
                {
                    Console.WriteLine("Пробег введён неверно");
                    goto re3;
                }
            }
           Console.Clear();
            return mas;
        }
        static void output(Bus[] mas)
        {
            for (int i = 0; mas.Length > i; i++)
            {
                Console.WriteLine($"Экземпляр номер {i}");
                Console.WriteLine($"Имя и инициалы водителя: {mas[i].Drivername}");
                Console.WriteLine($"Номер автобуса: {mas[i].BusNumber}");
                Console.WriteLine($"Номер маршрута: {mas[i].RoutNumber}");
                Console.WriteLine($"Марка автобуса: {mas[i].BrandBus}");
                Console.WriteLine($"Год начала эксплуатации: {mas[i].YearOfStartUse}");
                Console.WriteLine($"Пробег: {mas[i].Mileage}");
                Console.WriteLine($"_____________________________________________");   
            }
           
        }
        static void ListBusRoutNumber(Bus[] mas)
        {
            Console.WriteLine("Введите номер маршрута, по которому вы хотите найти автобусы: ");
            string a = Console.ReadLine();
            uint b;
            byte count = 0;
            re3:
            try
            {
                b = Convert.ToUInt32(a);
            }
            catch (SystemException)
            {
                Console.WriteLine("Значение введено некорректно");
                goto re3;
            }
            for(int i = 0; mas.Length > i; i++)
            {
                if(mas[i].RoutNumber == b)
                {
                    Console.WriteLine($"Автобус номер {i+1}");
                    count++;
                }
                if(count == 0)
                {
                    Console.WriteLine($"Автобусов с таким номером маршрута нет!");
                }
            }
        }
        static void ListBusYear(Bus[] mas)
        {
            Console.WriteLine("Введите количество лет. Автобусы, которые используются больше заданного срока будут выведены на экран");
            uint b;
            byte count = 0;
            re4:
            string a = Console.ReadLine();
            if (Convert.ToUInt32(a) >100 || Convert.ToUInt32(a) < 0)
            {
                Console.WriteLine("Некорректная дата");
                goto re4;
            }
            try
            {
                b = Convert.ToUInt32(a);
            }
            catch (SystemException)
            {
                Console.WriteLine("Некорректная дата");
                goto re4;
            }
            for(int i = 0; mas.Length >i; i++)
            {
                int year = 2020;
                if (b < (year - mas[i].YearOfStartUse))
                {
                    Console.WriteLine($"Автобус номер {i+1}");
                    count++;
                }
            }

        }
        static void construct()
        {
            Bus bus1 = new Bus("Силин В.", "Numvb123", 1234, "audi", 1999, 12343);
            Bus bus2 = new Bus();
        }
        static void BusYear(Bus[] mas)
        {
        re5:
            Console.WriteLine("Введите номер автобуса(0 - для возвращения обратно):");
            string a = Console.ReadLine();
            byte year;
            try
            {
                year = Convert.ToByte(a);
            }
            catch (SystemException)
            {
                Console.WriteLine("Номер введён некорректно");
                goto re5;
            }
            if(year-1 > Convert.ToByte(mas.Length))
            {
                Console.WriteLine("Такого номера автобуса нетттт...");
                goto re5;
            }else
            {
                Console.WriteLine($"Возраст автобуса номер {year}: {2020 - mas[year].YearOfStartUse}");
            }
            
        }
    }
}


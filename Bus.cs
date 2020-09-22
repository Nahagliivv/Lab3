using System;
using System.Threading;

namespace Lab3
{
    public class Bus
    {
        private string driver_name; //Фамилиия и инициалы водителя
        private string bus_number; // Номер автобуса
        private uint rout_number; //Номер маршрута
        private string brand_bus;// Марка автобуса
        private uint year_of_start_of_use;// Год начала эксплуатации
        private double mileage; //Пробег
        public static int CountOfBuses = 0;
        public const int wheels = 4;
        public string Drivername
        {
            get
            {
                return driver_name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Имя не можеи быть пустым");
                }
                driver_name = value;
            }
        }
        public string BusNumber
        {
            get
            {
                return bus_number;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Номер автобуса не может быть пустым");
                }
                bus_number = value;
            }
        }
        public uint RoutNumber
        {
            get
            {
                return rout_number;
            }
            set
            {

                rout_number = value;
            }
        }
        public string BrandBus
        {
            get
            {
                return brand_bus;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Марка автобуса не может быть пустой");
                }
                brand_bus = value;
            }
        }
        public uint YearOfStartUse
        {
            get
            {
                return year_of_start_of_use;
            }
            set
            {
                if (value > 2020)
                {
                    while (value > 2020)
                    {
                        Console.WriteLine("Год начала эксплуатации введён некорректно, введите год начала эксплуатации: ");
                        value = Convert.ToUInt32(Console.ReadLine());
                    }
                }
                year_of_start_of_use = value;
            }
        }

        public double Mileage
        {
            get
            {
                return mileage;
            }
            set
            {
                mileage = value;
            }
        }
        public Bus( string dn, string bn, uint rn,string bb,uint yosou, double m)
        { driver_name = dn;
          bus_number =  bn ;
          rout_number = rn ;
          brand_bus =  bb ;
          year_of_start_of_use = yosou ;
          mileage = m ;
        }
        public Bus()
        {
            driver_name = "Валуй В.";
            bus_number = "Cucumb3r";
            rout_number = 42040;
            brand_bus = "Кадиллак";
            year_of_start_of_use = 2020;
            mileage = 666;
        }
        static Bus()
        {
            Console.WriteLine("Вызов статического конструктора\n___________________________________");
        
        }
        public  static void Info()
        {
                Console.WriteLine($"Информация о классе...Он в себе содержит:");
                Console.WriteLine($"Имя и инициалы водителя.");
                Console.WriteLine($"Номер автобуса.");
                Console.WriteLine($"Номер маршрута.");
                Console.WriteLine($"Марку автобуса.");
                Console.WriteLine($"Год начала эксплуатации.");
                Console.WriteLine($"Пробег.");
                Console.WriteLine($"А так же хорошее настроеееение )0))))00)");
        }
        public static void BusYear(ref Bus[] mas) //возраст автобуса
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
                        Program.Main();
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
        public static Bus[] CreateABuses() // создание акземплярова автобусов
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
        public static void Output(ref Bus[] mas) //Вывод всех экземпляров из массива
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
        public static void ListBusRoutNumber(ref Bus[] mas) //функция для вывода автобусов по номеру маршрута
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
        public static void ListBusYear( ref Bus[] mas) //функция вывода автобусов, которые используются дольше заданного срока
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

        public static void Primer(out int num) //работа с out
        {
            num = 200 * 3;
        }
        public static void OutputWithToString(Bus[] mas)
        {
            for (int i = 0; mas.Length > i; i++)
            {
                Console.WriteLine(mas[i].ToString());
            }
        }
        public override string ToString()
        {
            return $"{driver_name}  {bus_number}  {rout_number}  {brand_bus}  {year_of_start_of_use}  {mileage}";
        }
        public override int GetHashCode()
        {
            return driver_name.GetHashCode();
        }

    }
    public class SchoolBus : Bus
    {
        private SchoolBus()
        {
           Console.WriteLine( "ШКОЛА");
        }

        public static void OutputPrivate(){
            SchoolBus aa = new SchoolBus();
        }
    }
    public partial class Driver
    {
        //Всякое разное
    }
}

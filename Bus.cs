using System;

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
        public Bus(string dn, string bn, uint rn, string bb, uint yosou,  double m) { dn = driver_name; bn = bus_number; rn = rout_number; bb = brand_bus; yosou = year_of_start_of_use; m = mileage;}
        public Bus() { driver_name= "Валуй В."; bus_number = "Num24123"; rout_number= 3234; brand_bus ="Кадиллак"; year_of_start_of_use = 2020; mileage = 666; }
    }
}

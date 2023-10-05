using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    /*    internal class Program2
        {

            static void Main(string[] args)
            {
                Car[] cars = new Car[] {
                new Car("Suzuki", 1998, 140),
                new Car("Opel", 2006, 130),
                new Car("BMW", 2012, 220),
                new Car("Mazda", 2000, 150),
                };
                Console.WriteLine(new string('-', Console.WindowWidth));
                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.Name}  {car.ProductionYear}  {car.MaxSpeed}");
                }
                Console.WriteLine("\n" + new string('-', Console.WindowWidth));
                int v;
                Console.WriteLine("Для сортировки по одному из параметров введите цифру:" +
                    "\n1 - Сортировка по названию" +
                    "\n2 - Сортировка по году выпуска" +
                    "\n3 - Сортировка по Максимальной скорости\n");
                v = Int32.Parse(Console.ReadLine());

                if (v == 1)
                {
                    Array.Sort(cars, new CarComparer(CarComparer.SortCrit.Name));
                    Console.WriteLine("\nСортировка по названию:");
                    foreach (var car in cars)
                    {
                    Console.WriteLine($"{car.Name}  {car.ProductionYear}  {car.MaxSpeed}");
                }

                        }
                else if (v == 2)
                {
                    Array.Sort(cars, new CarComparer(CarComparer.SortCrit.ProductionYear));
                    Console.WriteLine("\nСортировка по году выпуска:");
                    foreach (var car in cars)
                    {
                    Console.WriteLine($"{car.Name}  {car.ProductionYear}  {car.MaxSpeed}");
                    }

                }
                 else if ( v == 3) 
                {
                    Array.Sort(cars, new CarComparer(CarComparer.SortCrit.MaxSpeed));
                    Console.WriteLine("\nСортировка по  максимальной скорости:");
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Name}  {car.ProductionYear}  {car.MaxSpeed}");
                    }

                }
                else { throw new Exception("Недопустимое значение для сортировки!"); }
            }
        }   */


    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string name, int year, int speed)
        {
            Name = name;
            ProductionYear = year;
            MaxSpeed = speed;
        }
    }

    
    public class CarComparer : IComparer<Car>
    {
        SortCrit sortcrit;
        public enum SortCrit
        {
            Name,
            ProductionYear,
            MaxSpeed
        }
        

        public CarComparer(SortCrit Criter)
        {
            sortcrit = Criter;
        }

        
       public int Compare(Car x, Car y)
        {
            switch(sortcrit)
            {
                case SortCrit.Name:
                    return string.Compare(x.Name, y.Name);
                case SortCrit.ProductionYear:
                    return x.ProductionYear.CompareTo(y.ProductionYear);
                case SortCrit.MaxSpeed:
                    return x.MaxSpeed.CompareTo(y.MaxSpeed);
                    default: throw new ArgumentException("Неизвестный критерий сортировки!");
            }
        }
    }


}

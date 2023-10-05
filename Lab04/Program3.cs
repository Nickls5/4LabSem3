using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab04
{
 /*   class Program3
    {
        static void Main()
        {
            Car[] cars = new Car[]
         {
            new Car("Audi", 2010,250),
            new Car("Mazda", 2000,220),
            new Car("Toyota", 2005,230)
         };

            CarCatalog catalog = new CarCatalog(cars);

            Console.WriteLine("Прямой проход с первого элемента до последнего:");
            foreach (var car in catalog)
            {
                Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
            }

            Console.WriteLine();

            Console.WriteLine("Обратный проход от последнего к первому:");
            foreach (var car in catalog.GetReverseEnumerator())
            {
                Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
            }

            Console.WriteLine();

            Console.WriteLine("Проход по элементам массива с фильтром по году выпуска (2005):");
            foreach (var car in catalog.GetCarsByProductionYear(2005))
            {
                Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
            }

            Console.WriteLine();

            Console.WriteLine("Проход по элементам массива с фильтром по максимальной скорости (240):");
            foreach (var car in catalog.GetCarsByMaxSpeed(240))
            {
                Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
            }
        }*/

        public class CarCatalog : IEnumerable<Car>
        {
            private Car[] cars;

            public CarCatalog(Car[] cars)
            {
                this.cars = cars;
            }


            public IEnumerator<Car> GetEnumerator()
            {
                // Прямой проход с первого элемента до последнего
                for (int i = 0; i < cars.Length; i++)
                {
                    yield return cars[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerable<Car> GetReverseEnumerator()
            {
                // Обратный проход от последнего к первому
                for (int i = cars.Length - 1; i >= 0; i--)
                {
                    yield return cars[i];
                }
            }

            public IEnumerable<Car> GetCarsByProductionYear(int productionYear)
            {
                // Проход по элементам массива с фильтром по году выпуска
                foreach (var car in cars)
                {
                    if (car.ProductionYear == productionYear)
                    {
                        yield return car;
                    }
                }
            }

            public IEnumerable<Car> GetCarsByMaxSpeed(int maxSpeed)
            {
                // Проход по элементам массива с фильтром по максимальной скорости
                foreach (var car in cars)
                {
                    if (car.MaxSpeed <= maxSpeed)
                    {
                        yield return car;
                    }
                }
            }
        }


    }

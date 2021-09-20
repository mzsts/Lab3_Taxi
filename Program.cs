using System;
using System.Collections.Generic;

namespace Lab3_Taxi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<Passenger>> passengersLists = new()
            {
                new(), // Нет пассажиров
                new() // легковое
                {
                    new(2, 23),
                    new(4, 23),
                    new(6, 23),
                },
                new() // не хватит мест
                {
                    new(2, 23),
                    new(4, 23),
                    new(6, 23),
                    new(3, 23),
                    new(5, 23),
                },
                new() // грузовое
                {
                    new(24, 23),
                    new(42, 23),
                },
                new() // легковое
                {
                    new(2, 23),
                    new(42, 23),
                }
            };

            TaxiDispenser td = new();

            foreach (List<Passenger> passengers in passengersLists)
            {
                (bool, string) result = td.TryDispense(passengers);
                Console.WriteLine(result.Item2 + "\n");

                if (result.Item1)
                {
                    Console.WriteLine(td.Taxi.ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}

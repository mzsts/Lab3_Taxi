using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab3_Taxi
{
    public abstract class Taxi
    {
        protected List<Passenger> _passengers = new();
        protected uint _pricePerKilometer;
        protected uint _maxPassengersCount;
        protected static int counter;

        public int Id { get; init; }
        public string Driver { get; init; }
        public string TaxiType { get; protected set; }

        public Taxi(string driver) =>
            (Id, Driver) = (++counter, driver);

        public int CalculateCost(Passenger passenger) =>
            (int)(passenger.TravelDistance * _pricePerKilometer);
        public int CalculateCost(IEnumerable<Passenger> passengers) => 
            passengers.Sum(pass =>
            {
                if (_passengers.Contains(pass))
                {
                    return CalculateCost(pass);
                }
                else
                {
                    throw new Exception($"Пассажира под номером {passengers.ToList().IndexOf(pass)} не существует");
                }
            });
        public int TravelCostForAllPassengers() =>
            _passengers.Count / _passengers.Sum(passenger => CalculateCost(passenger));

        public virtual bool TryAddPassenger(Passenger passenger)
        {
            if (_passengers.Count == _maxPassengersCount || passenger is null)
            {
                return false;
            }

            _passengers.Add(passenger);
            return true;
        }
        public virtual bool TryAddPassengers(IEnumerable<Passenger> passengers)
        {
            if (_passengers.Count + passengers.Count() > _maxPassengersCount)
            {
                return false;
            }

            foreach (Passenger passenger in passengers)
            {
                if (TryAddPassenger(passenger) is false)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string info =
                $"{Id}_Тип такси: {TaxiType}\tВодитель: {Driver}\tКоличество пассажиров: {_passengers.Count}\n" +
                "---------------------------------------------------------------------------------------------\n";

            for (int i = 0; i < _passengers.Count; i++)
            {
                info += _passengers[i].ToString() + $"\nЦена поездки: {CalculateCost(_passengers[i])}\n" +
                    "---------------------------------------------------------------------------------------------\n";
            }

            return info;
        }
    }
}

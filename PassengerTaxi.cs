using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab3_Taxi
{
    public class PassengerTaxi : Taxi
    {
        private int _maxBaggageWeight = 50;
        public PassengerTaxi(string driver) : base(driver)
        {
            TaxiType = "Грузовое";
            _maxPassengersCount = 4;
            _pricePerKilometer = 12;
        }

        public override bool TryAddPassenger(Passenger passenger)
        {
            if (_passengers.Count == 4)
            {
                return false;
            }

            int currentBaggageWeight = (int)_passengers.Sum(pass => pass.BaggageWeight);
            if (currentBaggageWeight + passenger.BaggageWeight > _maxBaggageWeight)
            {
                return false;
            }

            _passengers.Add(passenger);
            return true;
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab3_Taxi
{
    public class Passenger
    {
        public uint BaggageWeight { get; init; }
        public uint TravelDistance { get; init; }

        public Passenger(uint baggageWeight, uint travelDistance) =>
            (BaggageWeight, TravelDistance) = (baggageWeight, travelDistance);
        public Passenger()
        { }

        public override string ToString() => 
            $"Вес багажа: {BaggageWeight}\tРасстояние поездки: {TravelDistance}";
    }
}

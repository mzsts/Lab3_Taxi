using System.Collections.Generic;
using System.Linq;

namespace Lab3_Taxi
{
    public class TaxiDispenser
    {
        public Taxi Taxi { get; private set; }
        public (bool Result, string Message) TryDispense(IEnumerable<Passenger> passengers)
        {
            if (passengers.Any() is false)
            {
                return (false, "Для распределения нужен хотя бы один пассажир.");
            }

            if (passengers.Count() > 4)
            {
                return (false, "Для такого количества пассажиров такси не подобрать.");
            }

            int totalBaggageWeight = (int)passengers.Sum(pass => pass.BaggageWeight);

            if (passengers.Count() > 2)
            {
                if (totalBaggageWeight > 50)
                {
                    return (false, "Вес багажа слишком велик для легкового такси. Пассажиров больше, чем вмещает грузовое такси");
                }
                else
                {
                    Taxi = new PassengerTaxi("Андрей");
                    if (Taxi.TryAddPassengers(passengers) is false)
                    {
                        return (false, "Ошибка в данных пассажиров");
                    }

                    return (true, "Пассажиры могут поехать на легковом такси.");
                }
            }

            if (totalBaggageWeight > 50)
            {
                Taxi = new CargoTaxi("Алберт");
                if (Taxi.TryAddPassengers(passengers) is false)
                {
                    return (false, "Ошибка в данных пассажиров");
                }
                return (true, "Пассажиры могут поехать на грузовом такси");
            }
            else
            {
                Taxi = new CargoTaxi("Азамат");
                if (Taxi.TryAddPassengers(passengers) is false)
                {
                    return (false, "Ошибка в данных пассажиров");
                }

                return (true, "Пассажиры могут поехать на легковом такси.");
            }
        }
    }
}

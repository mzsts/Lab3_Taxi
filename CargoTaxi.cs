namespace Lab3_Taxi
{
    public class CargoTaxi : Taxi
    {
        public CargoTaxi(string driver) : base(driver)
        {
            TaxiType = "Грузовое";
            _maxPassengersCount = 2;
            _pricePerKilometer = 20;
        }
    }
}

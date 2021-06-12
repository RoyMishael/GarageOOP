namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_VehicleName, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.ElecticCar:
                    {
                        newVehicle = new ElectricCar(i_VehicleName, i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricBike:
                    {
                        newVehicle = new ElectricBike(i_VehicleName, i_LicenseNumber);
                        break;
                    }

                case eVehicleType.FuelCar:
                    {
                        newVehicle = new FuelCar(i_VehicleName, i_LicenseNumber);
                        break;
                    }

                case eVehicleType.FuelBike:
                    {
                        newVehicle = new FuelBike(i_VehicleName, i_LicenseNumber);
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        newVehicle = new Truck(i_VehicleName, i_LicenseNumber);
                        break;
                    }
            }

            return newVehicle;
        }
    }
}

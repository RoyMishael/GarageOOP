using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private const eTiresAmount k_NumOfTires = eTiresAmount.Four;
        private const float k_MaximumTirePressure = 32;
        private const float k_MaximumBatteryTime = 3.2f;
        private eDoorAmount m_AmountOfDoors;
        private eVehicleColor m_VehicleColor;

        public ElectricCar(string i_VehicleName, string i_LicenseNumber)
            : base(k_MaximumBatteryTime, i_VehicleName, i_LicenseNumber, k_NumOfTires, k_MaximumTirePressure)
        {
        }

        public eDoorAmount NumberOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }

            set
            {
                m_AmountOfDoors = value;
            }
        }

        public eVehicleColor ColorOfVehicle
        {
            get
            {
                return m_VehicleColor;
            }

            set
            {
                m_VehicleColor = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
@"
Car's color: {0}
Car's amount of doors: {1}",
m_VehicleColor,
m_AmountOfDoors + 1);
        }
    }
}

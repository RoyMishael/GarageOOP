using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricBike : ElectricVehicle
    {
        private const eTiresAmount k_NumberOfWheels = eTiresAmount.Two;
        private const float k_MaximumTirePressure = 30;
        private const float k_MaximumBatteryTime = 1.8f;
        private eLicenseType m_TypeOfLicense;
        private int m_EngineCapacity;

        public ElectricBike(string i_VehicleName, string i_LicenseNumber)
            : base(k_MaximumBatteryTime, i_VehicleName, i_LicenseNumber, k_NumberOfWheels, k_MaximumTirePressure)
        {
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_TypeOfLicense;
            }

            set
            {
                m_TypeOfLicense = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                if (m_EngineCapacity > 0)
                {
                    m_EngineCapacity = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("air pressure of the wheels", 0);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
@"
Bike's license type: {0}
Bike's engine capacity: {1}",
m_TypeOfLicense,
m_EngineCapacity);
        }
    }
}

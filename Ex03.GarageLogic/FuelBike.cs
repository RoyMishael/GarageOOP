using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBike : FuelVehicle
    {
        private const eTiresAmount k_NumberOfWheels = eTiresAmount.Two;
        private const float k_MaximumTirePressure = 30;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_FuelCapacity = 6;
        private eLicenseType m_TypeOfLicense;
        private int m_EngineCapacity;

        public FuelBike(string i_VehicleName, string i_LicenseNumber)
            : base(k_FuelType, k_FuelCapacity, i_VehicleName, i_LicenseNumber, k_NumberOfWheels, k_MaximumTirePressure)
        {
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                if(value <= 0)
                {
                    throw new ValueOutOfRangeException("engine", 0);
                }
                else
                {
                    m_EngineCapacity = value;
                }
            }
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
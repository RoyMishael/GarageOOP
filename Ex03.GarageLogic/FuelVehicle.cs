using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaximumFuelAmount;
        private float m_CurrentFuelAmount;

        public FuelVehicle(eFuelType i_FuelType, float i_MaximumFuel, string i_VehicleName, string i_LicenseNumber, eTiresAmount i_TiresAmount, float i_MaximumTirePressure)
            : base(i_VehicleName, i_LicenseNumber, i_TiresAmount, i_MaximumTirePressure)
        {
            r_FuelType = i_FuelType;
            r_MaximumFuelAmount = i_MaximumFuel;
        }

        internal void RefuelVehicle(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(i_FuelType.ToString() + " is not matching the vehicle fuel type");
            }
            else if (i_FuelAmountToAdd + m_CurrentFuelAmount > r_MaximumFuelAmount || i_FuelAmountToAdd < 0)
            {
                throw new ValueOutOfRangeException("fueling", m_CurrentFuelAmount, r_MaximumFuelAmount);
            }

            m_CurrentFuelAmount += i_FuelAmountToAdd;
            SetEnergyPercentage(m_CurrentFuelAmount, r_MaximumFuelAmount);
        }

        public float MaximumFuelAmount
        {
            get
            {
                return r_MaximumFuelAmount;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount;
            }

            set
            {
                if(value > r_MaximumFuelAmount || value < 0)
                {
                    throw new ValueOutOfRangeException("fuel", 0, r_MaximumFuelAmount);
                }
                else
                {
                    m_CurrentFuelAmount = value;
                    SetEnergyPercentage(m_CurrentFuelAmount, r_MaximumFuelAmount);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
@"
Vehicle's fuel type: {0}
Vehicle's current fuel: {1}
Vehicle's maximum fuel: {2}", r_FuelType.ToString(),
m_CurrentFuelAmount,
r_MaximumFuelAmount);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected const float k_PercentageConverter = 100;
        private readonly eTiresAmount r_NumOfTires;
        private readonly string r_VehicleModelName;
        private readonly string r_LicenseNumber;
        private readonly float r_MaximumTirePressure;
        private readonly List<Wheel> r_Wheels = new List<Wheel>();
        private float m_RemainingEnergyPercentage;

        internal Vehicle(string i_VehicleName, string i_LicenseNumber, eTiresAmount i_TiresAmount, float i_MaximumTirePressure)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_VehicleModelName = i_VehicleName;
            r_NumOfTires = i_TiresAmount;
            r_MaximumTirePressure = i_MaximumTirePressure;
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
        }

        public float MaximumTirePressure
        {
            get
            {
                return r_MaximumTirePressure;
            }
        }

        internal void SetEnergyPercentage(float i_CurrentEnergy, float i_MaximumEnergy)
        {
            m_RemainingEnergyPercentage = i_CurrentEnergy / i_MaximumEnergy * k_PercentageConverter;
        }

        internal eTiresAmount NumberOfTires
        {
            get
            {
                return r_NumOfTires;
            }
        }

        internal string VehicleName
        {
            get
            {
                return r_VehicleModelName;
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public void CreateVehicleWheels(string i_ManufacturerName, float i_TirePressure)
        {
            for(int i = 0; i < (int)r_NumOfTires; i++)
            {
                r_Wheels.Add(new Wheel(i_ManufacturerName, r_MaximumTirePressure));

                if(i_TirePressure >= 0 && i_TirePressure <= r_MaximumTirePressure)
                {
                    r_Wheels[i].TirePressure = i_TirePressure;
                }
                else
                {
                    throw new ValueOutOfRangeException("pressure", 0, r_MaximumTirePressure);
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle's license plate: {0}
Vehicle's model name: {1}{2}
Energy percentage remaining: {3}",
r_LicenseNumber,
r_VehicleModelName,
r_Wheels[0].ToString(),
m_RemainingEnergyPercentage);
        }
    }
}
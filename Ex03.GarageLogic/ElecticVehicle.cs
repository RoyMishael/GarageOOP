namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private readonly float r_MaximumHoursOfBatteryTime;
        private float m_RemainingHoursOfBatteryTime;

        public ElectricVehicle(float i_MaximumBatteryHours, string i_VehicleName, string i_LicenseNumber, eTiresAmount i_TiresAmount, float i_MaximumTirePressure)
            : base(i_VehicleName, i_LicenseNumber, i_TiresAmount, i_MaximumTirePressure)
        {
            r_MaximumHoursOfBatteryTime = i_MaximumBatteryHours;
        }

        public void RechargeVehicle(float i_HoursOfBatteryToAdd)
        {
            if (i_HoursOfBatteryToAdd + m_RemainingHoursOfBatteryTime > r_MaximumHoursOfBatteryTime || i_HoursOfBatteryToAdd < 0)
            {
                throw new ValueOutOfRangeException("overcharging", m_RemainingHoursOfBatteryTime, r_MaximumHoursOfBatteryTime);
            }
            else
            {
                m_RemainingHoursOfBatteryTime += i_HoursOfBatteryToAdd;
                SetEnergyPercentage(m_RemainingHoursOfBatteryTime, r_MaximumHoursOfBatteryTime);
            }
        }

        public float MaximumBatteryTime
        {
            get
            {
                return r_MaximumHoursOfBatteryTime;
            }
        }

        public float RemainingBattery
        {
            get
            {
                return m_RemainingHoursOfBatteryTime;
            }

            set
            {
                if (value > r_MaximumHoursOfBatteryTime || value < 0)
                {
                    throw new ValueOutOfRangeException("charging", 0, r_MaximumHoursOfBatteryTime);
                }
                else
                {
                    m_RemainingHoursOfBatteryTime = value;
                    SetEnergyPercentage(m_RemainingHoursOfBatteryTime, r_MaximumHoursOfBatteryTime);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
@"
Vehicle's remaining battery: {0}
Vehicle's maximum battery: {1}",
m_RemainingHoursOfBatteryTime,
r_MaximumHoursOfBatteryTime);
        }
    }
}

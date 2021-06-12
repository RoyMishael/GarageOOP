namespace Ex03.GarageLogic
{
    public class Truck : FuelVehicle
    {
        private const eTiresAmount k_NumOfTires = eTiresAmount.Sixteen;
        private const float k_MaximumTirePressure = 26;
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_FuelCapacity = 120;
        private bool m_IsAllowedDangerousMaterials;
        private float m_MaximumCarryCapacity;

        public Truck(string i_VehicleName, string i_LicenseNumber)
            : base(k_FuelType, k_FuelCapacity, i_VehicleName, i_LicenseNumber, k_NumOfTires, k_MaximumTirePressure)
        {
        }

        public bool IsDrivingDangerousMaterial
        {
            get
            {
                return m_IsAllowedDangerousMaterials;
            }

            set
            {
                m_IsAllowedDangerousMaterials = value;
            }
        }

        public float MaximumCarryCapacity
        {
            get
            {
                return m_MaximumCarryCapacity;
            }

            set
            {
                if (m_MaximumCarryCapacity < 0)
                {
                    throw new ValueOutOfRangeException("carry capacity", 0, m_MaximumCarryCapacity);
                }
                else
                {
                    m_MaximumCarryCapacity = value;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
@"
Truck allowed to carry dangerous materials? {0}
Truck's maximum carry capacity: {1}",
m_IsAllowedDangerousMaterials,
m_MaximumCarryCapacity);
        }
    }
}

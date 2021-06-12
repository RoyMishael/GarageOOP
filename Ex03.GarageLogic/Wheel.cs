using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaximumTirePressure;
        private float m_CurrentTirePressure = 0;

        internal Wheel(string i_ManufacturerName, float i_MaximumTirePressure)
        {
            if(i_MaximumTirePressure <= 0)
            {
                throw new ValueOutOfRangeException("pressure", 0);
            }
            else
            {
                r_MaximumTirePressure = i_MaximumTirePressure;
            }

            r_ManufacturerName = i_ManufacturerName;
        }

        internal float TirePressure
        {
            get
            {
                return m_CurrentTirePressure;
            }

            set
            {
                if(value > r_MaximumTirePressure || value < 0)
                {
                    throw new ValueOutOfRangeException("pressure", 0);
                }
                else
                {
                    m_CurrentTirePressure = value;
                }
            }
        }

        internal string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        internal float MaximumTirePressure
        {
            get
            {
                return r_MaximumTirePressure;
            }
        }

        internal void Infale(float i_AmountOfAirToAdd)
        {
            if(i_AmountOfAirToAdd < 0 || i_AmountOfAirToAdd + m_CurrentTirePressure > r_MaximumTirePressure)
            {
                throw new ValueOutOfRangeException("pressure", 0, r_MaximumTirePressure);
            }
            else
            {
                m_CurrentTirePressure += i_AmountOfAirToAdd;
            }
        }

        internal void InfaleToMaximum()
        {
            m_CurrentTirePressure = r_MaximumTirePressure;
        }

        public override string ToString()
        {
            return string.Format(
@"
Wheel's manufacturer: {0}
Wheel's current air pressure: {1}
Wheel's maximum air pressure: {2}",
r_ManufacturerName,
m_CurrentTirePressure,
r_MaximumTirePressure);
        }
    }
}

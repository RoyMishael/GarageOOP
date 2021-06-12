namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string i_Field, float i_Minvalue, float i_Maxvalue)
            : base(string.Format("The value of the {0} should be between {1} to {2}", i_Field, i_Minvalue, i_Maxvalue))
        {
        }

        public ValueOutOfRangeException(string i_Field, float i_Minvalue)
            : base(string.Format("The value of the {0} should be above {1}", i_Field, i_Minvalue))
        {
        }
    }
}

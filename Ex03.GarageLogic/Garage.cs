using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, GarageClient> r_VehiclesInGarage;

        public Garage()
        {
            r_VehiclesInGarage = new Dictionary<string, GarageClient>();
        }

        private class GarageClient
        {
            private readonly string r_OwnerName;
            private readonly string r_PhoneNumber;
            private readonly Vehicle r_Vehicle;
            private eVehicleStatus m_VehicleGarageStatus;

            internal Vehicle Vehicle
            {
                get { return r_Vehicle; }
            }

            internal eVehicleStatus StatusInTheGarage
            {
                get { return m_VehicleGarageStatus; }
                set { m_VehicleGarageStatus = value; }
            }

            internal GarageClient(string i_ClientName, string i_PhoneNumber, Vehicle i_vehicle)
            {
                r_OwnerName = i_ClientName;
                r_PhoneNumber = i_PhoneNumber;
                r_Vehicle = i_vehicle;
                m_VehicleGarageStatus = eVehicleStatus.Repairing;
            }

            public override string ToString()
            {
                return string.Format(
@"Garage client name: {0}
Phone number: {1}
Status in the garage: {2}
{3}",
r_OwnerName,
r_PhoneNumber,
m_VehicleGarageStatus.ToString(),
r_Vehicle.ToString());
            }
        }

        public void EnterNewVehicleToGarge(string i_ClientName, string i_PhoneNumber, Vehicle i_NewVehicle)
        {
            r_VehiclesInGarage.Add(i_NewVehicle.LicenseNumber, new GarageClient(i_ClientName, i_PhoneNumber, i_NewVehicle));
        }

        public bool IsVehicleInTheGarage(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetListVehiclesInTheGarage(eVehicleStatus i_Status)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (KeyValuePair<string, GarageClient> item in r_VehiclesInGarage)
            {
                if (item.Value.StatusInTheGarage == i_Status || i_Status == eVehicleStatus.All)
                {
                    licenseNumbers.Add(item.Key);
                }
            }

            return licenseNumbers;
        }

        public string PrintGarageClient(string i_LicenseNumber)
        {
            return r_VehiclesInGarage[i_LicenseNumber].ToString();
        }

        public void SetWheelsMaximumPressure(string i_LicenseNumber)
        {
            foreach(Wheel wheel in r_VehiclesInGarage[i_LicenseNumber].Vehicle.Wheels)
            {
                wheel.InfaleToMaximum();
            }
        }

        public void SetClientStatusToHisChoice(string i_LicenseToChangeStatus, eVehicleStatus i_NewStatus)
        {
            r_VehiclesInGarage[i_LicenseToChangeStatus].StatusInTheGarage = i_NewStatus;
        }

        public void RefuelVehicle(string i_LicensePlate, float i_RefuelAmount, eFuelType i_FuelType)
        {
            FuelVehicle gasVehicle = r_VehiclesInGarage[i_LicensePlate].Vehicle as FuelVehicle;
            gasVehicle.RefuelVehicle(i_RefuelAmount, i_FuelType);
        }

        public void ChargeElectricVehicle(string i_LicenseToChangeStatus, float i_ChargeAmount)
        {
            ElectricVehicle electricVehicle = r_VehiclesInGarage[i_LicenseToChangeStatus].Vehicle as ElectricVehicle;
            electricVehicle.RechargeVehicle(i_ChargeAmount);
        }
    }
}

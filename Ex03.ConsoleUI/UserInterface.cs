using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private readonly GarageLogic.Garage r_Garage;

        internal UserInterface()
        {
            r_Garage = new GarageLogic.Garage();
        }

        public static int IsValidChoosingFromEnumList(int i_maxEnumValues)
        {
            int userInput;
            bool isValidChoosingFromEnumList;
            isValidChoosingFromEnumList = int.TryParse(Console.ReadLine(), out userInput);
            while (!isValidChoosingFromEnumList && userInput >= 1 && userInput <= i_maxEnumValues)
            {
                Console.WriteLine("Please provide a vaild number in range 1-{0} :", i_maxEnumValues);
                isValidChoosingFromEnumList = int.TryParse(Console.ReadLine(), out userInput);
            }

            return userInput;
        }

        private static void uiOptions()
        {
            string messageAskingAboutAllFunctions = string.Format(
@"Please choose an option (choose a number and press enter):

(1) Insert a new vehicle into the garage
(2) Display a list of license numbers currently in the garage
(3) Change a certain vehicle’s status 
(4) Inflate tires to maximum 
(5) Refuel a fuel-based vehicle
(6) Charge an electric-based vehicle 
(7) Display vehicle information
(8) Exit program
");
            Console.WriteLine(messageAskingAboutAllFunctions);
        }

        private static void showUserOptionsForVehicles()
        {
            string messageAskingAboutAllVehicles = string.Format(
@"Please Choose your vehicles type (choose a number and press enter):

(1) Fuel Car
(2) Fuel Bike
(3) Electic Car
(4) Electic Bike
(5) Truck
");

            Console.WriteLine(messageAskingAboutAllVehicles);
        }

        private static void showUserOptionsForLicenseType()
        {
            string messageAskingLicenseType = string.Format(
@"Please choose your license type (choose a number and press enter):

(1) Licence type A
(2) Licence type B1 
(3) Licence type AA
(4) Licence type BB
");

            Console.WriteLine(messageAskingLicenseType);
        }

        private static void showUserOptionsForFuel()
        {
            string messageAskingLicenseType = string.Format(
@"Please choose your fuel type (choose a number and press enter):

(1) Soler
(2) Octan 95
(3) Octan 96
(4) Octan 98
");

            Console.WriteLine(messageAskingLicenseType);
        }

        private static void showUserOptionsForColor()
        {
            string messageAskingAboutFuel = string.Format(
@"Please choose your car color (choose a number and press enter):

(1) Red Color
(2) Silver Color
(3) White Color
(4) Black Color
");

            Console.WriteLine(messageAskingAboutFuel);
        }

        private static void showUserOptionsForDoorAmount()
        {
            string messageAskingAboutDoors = string.Format(
@"Please choose your the amount of doors in your car (choose a number and press enter):

(1) TWO doors
(2) THREE doors
(3) FOUR doors
(4) FIVE doors
");

            Console.WriteLine(messageAskingAboutDoors);
        }

        private static void showUserOptionsForVehicleFiltering()
        {
            string messageAskingVehicleFiltering = string.Format(
@"Please choose one of the options (choose a number and press enter):

(1) Display cars which are in repair
(2) Display cars which are repaired
(3) Display cars which are paid
(4) Display all cars
");

            Console.WriteLine(messageAskingVehicleFiltering);
        }

        private static void showUserOptionsForStatusInGarage()
        {
            string messageAskingAboutDoors = string.Format(
@"Please choose one of the options (choose a number and press enter):

(1) For cars which are currently in repair
(2) For cars which are repaired
(3) For cars which are paid
");

            Console.WriteLine(messageAskingAboutDoors);
        }

        public eVehicleType getUserChoiceForVehicles()
        {
            return (eVehicleType)IsValidChoosingFromEnumList(eVehicleType.GetNames(typeof(eVehicleType)).Length);
        }

        public eLicenseType getUserChoiceForLicenseType()
        {
            return (eLicenseType)IsValidChoosingFromEnumList(eLicenseType.GetNames(typeof(eLicenseType)).Length);
        }

        public eVehicleColor getUserOptionsForColor()
        {
            return (eVehicleColor)IsValidChoosingFromEnumList(eVehicleColor.GetNames(typeof(eVehicleColor)).Length);
        }

        public eDoorAmount getUserOptionsForDoorAmount()
        {
            return (eDoorAmount)IsValidChoosingFromEnumList(eDoorAmount.GetNames(typeof(eDoorAmount)).Length);
        }

        public eVehicleStatus getUserOptionsForFiltering()
        {
            return (eVehicleStatus)IsValidChoosingFromEnumList(eVehicleStatus.GetNames(typeof(eVehicleStatus)).Length);
        }

        public eFuelType getUserOptionsForFuel()
        {
            return (eFuelType)IsValidChoosingFromEnumList(eFuelType.GetNames(typeof(eFuelType)).Length);
        }

        internal void WelcomeGarage()
        {
            eGarageFunctions userChoice;

            Console.WriteLine("Welcome to the garage!");
            uiOptions();
            userChoice = (eGarageFunctions)IsValidChoosingFromEnumList(eGarageFunctions.GetNames(typeof(eGarageFunctions)).Length);

            while (userChoice != eGarageFunctions.ExitFromProgram)
            {
                string isPlateInGarage;
                eFuelType fuelType;
                float reFuelOrCharge;
                Console.Clear();

                try
                {
                    switch (userChoice)
                    {
                        case eGarageFunctions.EnterNewVehicleToTheGarge:

                            Console.WriteLine("Hello! you would like to enter a new vehicle to the garage" + Environment.NewLine);
                            isPlateInGarage = getNumberLicence();

                            if (!r_Garage.IsVehicleInTheGarage(isPlateInGarage))
                            {
                                ArrayList newVehicleDetails = genericDetails(isPlateInGarage);
                                showUserOptionsForVehicles();
                                eVehicleType vehicleType = getUserChoiceForVehicles();
                                Console.Clear();
                                GarageLogic.Vehicle vehicle = GarageLogic.VehicleFactory.CreateVehicle(vehicleType, newVehicleDetails[2].ToString(), isPlateInGarage);
                                setVehicleWheels(vehicle);
                                fillAccordingToTheWantedVehicle(vehicleType, vehicle);
                                Console.Clear();
                                r_Garage.EnterNewVehicleToGarge(newVehicleDetails[0].ToString(), newVehicleDetails[1].ToString(), vehicle);
                                Console.WriteLine("The vehicle was successfully entered to the garage");
                            }
                            else
                            {
                                Console.WriteLine("It seems to be that your vehicle is already in the garage.");
                                Console.ReadLine();
                            }

                            break;

                        case eGarageFunctions.ShowListOfLicenseNumbersOfCurrentVehiclesInTheGarage:
                            showUserOptionsForVehicleFiltering();
                            eVehicleStatus vehicleStatus = getUserOptionsForFiltering();
                            Console.Clear();
                            printList(r_Garage.GetListVehiclesInTheGarage(vehicleStatus));
                            break;

                        case eGarageFunctions.ChangeStatusOfVehicleInTheGarage:

                            isPlateInGarage = getNumberLicence();
                            Console.WriteLine("Choose the status you want to change to:");
                            showUserOptionsForStatusInGarage();
                            eVehicleStatus isValidStatus = (eVehicleStatus)IsValidChoosingFromEnumList(eVehicleStatus.GetNames(typeof(eVehicleStatus)).Length - 1);
                            r_Garage.SetClientStatusToHisChoice(isPlateInGarage, isValidStatus);
                            Console.WriteLine("Vehicle's status changed!");

                            break;
                        case eGarageFunctions.InflatingAirPressureToMaximum:
                            isPlateInGarage = getNumberLicence();
                            if (r_Garage.IsVehicleInTheGarage(isPlateInGarage))
                            {
                                r_Garage.SetWheelsMaximumPressure(isPlateInGarage);
                                Console.WriteLine("Wheels inflated to their maximum!");
                            }
                            else
                            {
                                Console.WriteLine("This license plate is not registered in the garage, returning to menu");
                            }

                            break;
                        case eGarageFunctions.RefuelingFuelVehicle:

                            isPlateInGarage = getNumberLicence();
                            if (r_Garage.IsVehicleInTheGarage(isPlateInGarage))
                            {
                                showUserOptionsForFuel();
                                fuelType = getUserOptionsForFuel();
                                Console.WriteLine("Please type the amount of fuel that you would like to add:");
                                reFuelOrCharge = getUserChoiceForFloatingSections();
                                r_Garage.RefuelVehicle(isPlateInGarage, reFuelOrCharge, fuelType);
                                Console.WriteLine("Vehicle refuled!");
                            }
                            else
                            {
                                Console.WriteLine("This license plate is not registered in the garage, returning to menu");
                            }

                            break;
                        case eGarageFunctions.ChargeElectricVehicle:
                            isPlateInGarage = getNumberLicence();
                            if (r_Garage.IsVehicleInTheGarage(isPlateInGarage))
                            {
                                Console.WriteLine("Please type the amount of \"charging\" that you would like to add:");
                                reFuelOrCharge = getUserChoiceForFloatingSections();
                                r_Garage.ChargeElectricVehicle(isPlateInGarage, reFuelOrCharge);
                                Console.WriteLine("Vehicle recharged!");
                            }
                            else
                            {
                                Console.WriteLine("This license plate is not registered in the garage, returning to menu");
                            }

                            break;
                        case eGarageFunctions.ShowFullDataOfGarageClient:

                            Console.WriteLine(r_Garage.PrintGarageClient(getNumberLicence()));
                            Console.WriteLine();
                            break;
                        case eGarageFunctions.ExitFromProgram:
                            System.Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                catch (ValueOutOfRangeException err)
                {
                    Console.Clear();
                    printExceptionMessage(err, err.Message);
                    Console.WriteLine();
                }
                catch (ArgumentException err)
                {
                    Console.Clear();
                    printExceptionMessage(err, err.Message);
                    Console.WriteLine();
                }
                catch (FormatException err)
                {
                    Console.Clear();
                    printExceptionMessage(err, err.Message);
                    Console.WriteLine();
                }
                catch (KeyNotFoundException err)
                {
                    Console.Clear();
                    printExceptionMessage(err, err.Message);
                    Console.WriteLine();
                }
                catch (NullReferenceException err)
                {
                    Console.Clear();
                    printExceptionMessage(err, err.Message);
                    Console.WriteLine();
                }
                finally
                {
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Welcome to the garage!");
                    uiOptions();
                    userChoice = (eGarageFunctions)IsValidChoosingFromEnumList(eGarageFunctions.GetNames(typeof(eGarageFunctions)).Length);
                }
            }
        }

        private ArrayList genericDetails(string licensePlate)
        {
            ArrayList newVehicle = new ArrayList();
            string userName; // 0
            string phoneNumber; // 1
            string modelName; // 2

            Console.Clear();
            Console.WriteLine("Hello and thank you for choosing our garage :)" + Environment.NewLine + Environment.NewLine + "To start the registration process, please provide us your full name");
            userName = Console.ReadLine();
            while (!isValidName(userName))
            {
                Console.WriteLine("Please re-enter your name:");
                userName = Console.ReadLine();
                Console.Clear();
            }

            Console.Clear();

            Console.WriteLine("Please provide us your phone number:");
            phoneNumber = Console.ReadLine();
            while (!isValidPhonenumberAndLicencePlate(phoneNumber))
            {
                Console.WriteLine("Please re-enter your phone number:");
                phoneNumber = Console.ReadLine();
                Console.Clear();
            }

            Console.Clear();

            Console.WriteLine("Please enter your vehicle's model name:");
            modelName = Console.ReadLine();

            Console.Clear();
            newVehicle.Add(userName);
            newVehicle.Add(phoneNumber);
            newVehicle.Add(modelName);

            return newVehicle;
        }

        private void fillAccordingToTheWantedVehicle(eVehicleType i_VehicleType, Vehicle io_Vehicle)
        {
            string userDangerousMaterialInput;
            float userCarryCapacityInput;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    Console.WriteLine("Please write the quantity of fuel remaining in your car:");
                    ((GarageLogic.FuelCar)io_Vehicle).CurrentFuelAmount = getUserChoiceForFloatingSections();
                    Console.Clear();
                    showUserOptionsForDoorAmount();
                    ((GarageLogic.FuelCar)io_Vehicle).NumberOfDoors = getUserOptionsForDoorAmount();
                    Console.Clear();
                    showUserOptionsForColor();
                    ((GarageLogic.FuelCar)io_Vehicle).ColorOfVehicle = getUserOptionsForColor();
                    break;

                case eVehicleType.FuelBike:
                    Console.WriteLine("Please write the quantity of fuel remaining in your motorbike:");
                    ((GarageLogic.FuelBike)io_Vehicle).CurrentFuelAmount = getUserChoiceForFloatingSections();
                    Console.Clear();
                    showUserOptionsForLicenseType();
                    ((GarageLogic.FuelBike)io_Vehicle).LicenseType = getUserChoiceForLicenseType();
                    Console.Clear();
                    Console.WriteLine("Please write your engine capacity:");
                    ((GarageLogic.FuelBike)io_Vehicle).EngineCapacity = (int)getUserChoiceForFloatingSections();
                    break;
                case eVehicleType.ElecticCar:

                    Console.WriteLine("Please write the remaining battery time for your electric car:");
                    ((GarageLogic.ElectricCar)io_Vehicle).RemainingBattery = getUserChoiceForFloatingSections();
                    Console.Clear();
                    showUserOptionsForDoorAmount();
                    ((GarageLogic.ElectricCar)io_Vehicle).NumberOfDoors = getUserOptionsForDoorAmount();
                    Console.Clear();
                    showUserOptionsForColor();
                    ((GarageLogic.ElectricCar)io_Vehicle).ColorOfVehicle = getUserOptionsForColor();

                    break;
                case eVehicleType.ElectricBike:

                    Console.WriteLine("Please write the remaining battery time for your electric motorbike:");
                    ((GarageLogic.ElectricBike)io_Vehicle).RemainingBattery = getUserChoiceForFloatingSections();
                    Console.Clear();
                    ((GarageLogic.ElectricBike)io_Vehicle).LicenseType = getUserChoiceForLicenseType();
                    Console.WriteLine("Please write your engine size:");
                    Console.Clear();
                    ((GarageLogic.ElectricBike)io_Vehicle).EngineCapacity = (int)getUserChoiceForFloatingSections();

                    break;
                case eVehicleType.Truck:

                    Console.WriteLine("Please write the quantity of fuel remaining in your truck:");
                    ((GarageLogic.Truck)io_Vehicle).CurrentFuelAmount = getUserChoiceForFloatingSections();
                    Console.Clear();
                    Console.WriteLine("Does your truck transfer dangerous materials? type y (yes) / n (no)");
                    userDangerousMaterialInput = Console.ReadLine();

                    while ((userDangerousMaterialInput != "y") && (userDangerousMaterialInput != "n"))
                    {
                        Console.WriteLine("Please type y or n only");
                        userDangerousMaterialInput = Console.ReadLine();
                    }

                    Console.Clear();
                    Console.WriteLine("Whats is your maximum carry cpacity? (enter numbers only)");
                    userCarryCapacityInput = getUserChoiceForFloatingSections();

                    ((GarageLogic.Truck)io_Vehicle).IsDrivingDangerousMaterial = userDangerousMaterialInput == "y";
                    ((GarageLogic.Truck)io_Vehicle).MaximumCarryCapacity = userCarryCapacityInput;

                    Console.Clear();
                    break;
                default:
                    break;
            }
        }

        public float getUserChoiceForFloatingSections()
        {
            float number;
            bool isValid;

            isValid = float.TryParse(Console.ReadLine(), out number);

            while (!isValid || number < 0)
            {
                Console.WriteLine("Please provide a vaild amount:");
                isValid = float.TryParse(Console.ReadLine(), out number);
            }

            Console.Clear();

            return number;
        }

        private static void setVehicleWheels(Vehicle io_Vehicle)
        {
            string manfucaturerName;
            float currentTirePressure;

            Console.WriteLine("Please enter wheels manufacturer name:" + Environment.NewLine);
            manfucaturerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(string.Format("Please enter current tire pressure of your wheels (between 0-{0}):", io_Vehicle.MaximumTirePressure));
            currentTirePressure = float.Parse(Console.ReadLine());
            io_Vehicle.CreateVehicleWheels(manfucaturerName, currentTirePressure);
            Console.Clear();
        }

        private static void printExceptionMessage(Exception err, string i_Message)
        {
            Console.WriteLine(string.Format("{0} - {1}", err.GetType(), i_Message));
        }

        public static bool isValidName(string i_username)
        {
            bool checkValidation = (i_username == null) || i_username.IndexOf(" ") == -1 || i_username.Any(char.IsDigit) || !i_username.Any(char.IsLetterOrDigit);

            if (checkValidation)
            {
                Console.WriteLine("Your name isn't valid, it has digits/special charectars or does not a full name");
            }

            return !checkValidation;
        }

        public static string getNumberLicence()
        {
            string licencePlate;
            Console.WriteLine("Please provide us your licence plate:");
            licencePlate = Console.ReadLine();
            while (!isValidPhonenumberAndLicencePlate(licencePlate))
            {
                Console.WriteLine("Please re-enter licence plate:");
                licencePlate = Console.ReadLine();
                Console.Clear();
            }

            return licencePlate;
        }

        public static bool isValidPhonenumberAndLicencePlate(string i_Number)
        {
            bool checkValidation = (i_Number == null) || i_Number.IndexOf(" ") > -1 || i_Number.Any(char.IsLetter) || !i_Number.Any(char.IsLetterOrDigit);

            if (checkValidation)
            {
                Console.WriteLine("Your number isn't valid, it has lettes/special charectars/space." + Environment.NewLine + "Please re-enter your number:");
            }

            return !checkValidation;
        }

        public static void printList(List<string> i_LicencePlatesInTheGarage)
        {
            foreach (string plate in i_LicencePlatesInTheGarage)
            {
                Console.WriteLine("* " + plate);
            }
        }
    }
}
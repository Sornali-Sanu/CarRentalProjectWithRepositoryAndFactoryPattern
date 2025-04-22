using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Entities;
using CarRentalProjectWithRepositoryAndFactory.Enums;
using CarRentalProjectWithRepositoryAndFactory.Factory;
using CarRentalProjectWithRepositoryAndFactory.Manager;
using CarRentalProjectWithRepositoryAndFactory.Repository;

namespace CarRentalProjectWithRepositoryAndFactory
{
   
        internal class Program
        {
            public static CarRepository repo = new CarRepository();
            public static ICarService cars;
            static void Main(string[] args)
            {

                try
                {
                    DoTask();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally { Console.ReadLine(); }
            }

            private static void DoTask()
            {
                Console.WriteLine("\t\t\t\t\t\tC# Project");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tProject Name:Car Rental Information\n");
                Console.WriteLine("\t\t\t\t************************************************************\n");
               
                Console.WriteLine("\t\t\t\t\tHow many Information would you like to Know?\n");
                Console.WriteLine();
                int count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                int operationNumber = 0;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {

                        Console.WriteLine("\t\t\t\t\t\tChoose Operation\n");
                        Console.WriteLine("\t\t\t\t\t*****************************");

                        Console.WriteLine("\t\t\t\t\t\tHints:\n \n\t\t\t\t\t\tSelect -1\n\t\t\t\t\t\tCreate -2\n\t\t\t\t\t\tUpdate -3\n\t\t\t\t\t\tDelete -4\n");

                        operationNumber = Convert.ToInt16(Console.ReadLine());

                        switch (operationNumber)
                        {
                            case 1:
                                ShowCarInformation(null);
                                Console.WriteLine();
                                break;
                            case 2:
                                CreateCarInformation();
                                Console.WriteLine();
                                break;
                            case 3:
                                UpdateCarInformation();
                                Console.WriteLine();
                                break;
                            case 4:
                                DeleteCarInformation();
                                Console.WriteLine();
                                break;

                            default:
                                Console.WriteLine("Invalid operation");
                                break;
                        }
                    }
                }

            }

            private static void DeleteCarInformation()
            {
                Console.WriteLine("\t\t\t\t**Enter ID Of The Car Infromation That You Want to Remove**");
                int deleteId = Convert.ToInt32(Console.ReadLine());
            Car deleteCar = new Car();
                deleteCar.Id = deleteId;
                deleteCar = repo.RemoveCarInformation(deleteId);
                Console.WriteLine("\t\t\t\t\t**Car Removed successfully**\n");
                Console.WriteLine("\t\t\t\t******************************************");
                Console.WriteLine();
                ShowCarInformation(deleteCar);
            }

            private static void UpdateCarInformation()
            {
                Console.WriteLine("\t\t\t\t\t\tUpdate Car Information");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t************************************\n");

                Console.WriteLine("\t\t\t\t\t\tEnter ID");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\t\t\t\t\t\tEnter Model");
                string model = Console.ReadLine();

                Console.WriteLine("\t\t\t\t\t\tEnter customer Name");
                string name = Console.ReadLine();

                Console.WriteLine("\t\t\t\t\t\tEnter Car License");
                string license = Console.ReadLine();

                Console.WriteLine("\t\t\t\t\t\tEnter Color");
                string color = Console.ReadLine();

                Console.WriteLine("\t\t\t\t\t\tEnter Rental Days");
                int days = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\t\t\t\t\t\tEnter Daily Rate");
                double dailyrate = Convert.ToDouble(Console.ReadLine());



                EnterCarType:

                Console.WriteLine("\t\t\t\t\tEnter Car Type *Hints: New-1,Old-0");
                string type = Console.ReadLine();
                CarType carType;
                try
                {
                    carType = (CarType)Enum.Parse(typeof(CarType), type);
                }
                catch
                {
                    Console.WriteLine("Invalid type!! Try Again");
                    goto EnterCarType;
                }

                EnterBrands:

                Console.WriteLine("\t\t\t\t\tEnter Car Brand *Hint:Tesla=1,Toyota=2,Ford=3,Honda=4,BMW=5,Audi=6");
                string brand = Console.ReadLine();
            Brands brand1;
                try
                {
                    brand1 = (Brands)Enum.Parse(typeof(Brands), brand);
                }
                catch
                {
                    Console.WriteLine("Invalid type!! Try Again");
                    brand1 = Brands.None;
                    goto EnterBrands;
                }

                Car updatecar = new Car();
                updatecar.Id = id;
                ;
                updatecar.Model = model;
                updatecar.CarBrands = brand1;
                updatecar.CarType = carType;
                updatecar.rentalDays = days;
                updatecar.Color = color;
                updatecar.licenseNumber = license;
                updatecar.customerName = name;
                updatecar.DailyRate = dailyrate;

                Console.WriteLine("\t\t\t\t\t*Car updated successfully*");
                Console.WriteLine("\t\t\t\t*****************************************");
                Console.WriteLine();
                ShowCarInformation(updatecar);
            }

            private static void CreateCarInformation()
            {


                Console.WriteLine("\t\t\t\t\tEnter Model");
                string model = Console.ReadLine();



                Console.WriteLine("\t\t\t\t\tEnter Color");
                string color = Console.ReadLine();





                EnterCarType:

                Console.WriteLine("\t\t\t\t\tEnter Car Type *Hints: New-1,Old-0");
                string type = Console.ReadLine();
                CarType carType;
                try
                {
                    carType = (CarType)Enum.Parse(typeof(CarType), type);
                }
                catch
                {
                    Console.WriteLine("Invalid type!! Try Again");
                    goto EnterCarType;
                }

                EnterBrands:

                Console.WriteLine("\t\t\t\t\tEnter Car Brand *Hints:Tesla=1,Toyota=2,Ford=3,Honda=4,BMW=5,Audi=6");
                string brand = Console.ReadLine();
                Brands brand1;
                try
                {
                    brand1 = (Brands)Enum.Parse(typeof(Brands), brand);
                }
                catch
                {
                    Console.WriteLine("Invalid type!! Try Again");
                    brand1 = Brands.None;
                    goto EnterBrands;
                }


                Car carservice = new Car(0, model, color, brand1, 0, carType);

            BaseCarFactory car = new CarRentalManagerFactory().CreateFactory(carservice);

                car.ApplyDailyRate();

                repo.CreateNewCarInformation(carservice);
                Console.WriteLine("\t\t\t\t\t*Car information added successfully*");
                Console.WriteLine("\t\t\t\t***********************************************");
                Console.WriteLine();
                ShowCarInformation(carservice);
                ShowCarInformation(null);
            }

            private static void ShowCarInformation(Car car)
            {
                IEnumerable<Car> cars = repo.GetAllCarInformation();
                Console.WriteLine(string.Format("|{0,2}| {1,9}| {2,6}| {3,10}| {4,10}| {5,5}| {6,14}| {7,11}| {8,15}|", "ID", "Model",
                        "Color", "BrandName", "Daily Rate", "Type", "Customer Name", "License NO", "Rental Days"));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");

                Console.WriteLine();
                if (car == null)
                {
                    foreach (Car item in cars)
                    {
                        Console.WriteLine(string.Format("|{0,2}| {1,9}| {2,6}| {3,10}| {4,10}| {5,5}| {6,14}| {7,11}| {8,15}|", item.Id, item.Model,
                       item.Color, item.CarBrands, item.DailyRate, item.CarType, item.customerName, item.licenseNumber, item.rentalDays));
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

                    }
                }
                else
                {
                    Console.WriteLine(string.Format("|{0,2}| {1,9}| {2,6}| {3,10}| {4,10}| {5,5}| {6,14}| {7,11}| {8,15}|", car.Id, car.Model,
                       car.Color, car.CarBrands, car.DailyRate, car.CarType, car.customerName, car.licenseNumber, car.rentalDays));

                }

            }
        }
        
   
}

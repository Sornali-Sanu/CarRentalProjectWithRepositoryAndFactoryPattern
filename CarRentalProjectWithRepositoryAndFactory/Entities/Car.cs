using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Enums;

namespace CarRentalProjectWithRepositoryAndFactory.Entities
{
    public class Car
    {
        int id;
        string model;
        string color;
        Brands carBrands;
        double dailyRate;
        CarType carType;

        public Car(int id, string model, string color, Brands carBrands, double dailyRate, CarType carType)
        {
            this.Id = id;
            this.Model = model;
            this.Color = color;
            this.CarBrands = carBrands;
            this.DailyRate = dailyRate;
            this.CarType = carType;
        }
        public Car()
        {

        }
        public int Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }
        public Brands CarBrands { get => carBrands; set => carBrands = value; }
        public double DailyRate { get => dailyRate; set => dailyRate = value; }
        public CarType CarType { get => carType; set => carType = value; }
        public string customerName { get; set; }
        public string licenseNumber { get; set; }
        public int rentalDays { get; set; }


    }
}

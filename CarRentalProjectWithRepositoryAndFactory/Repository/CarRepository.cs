using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Entities;
using CarRentalProjectWithRepositoryAndFactory.Enums;
using CarRentalProjectWithRepositoryAndFactory.Interfaces;

namespace CarRentalProjectWithRepositoryAndFactory.Repository
{
    public class CarRepository : ICarRental
    {
        public readonly List<Car> _clist;
        public CarRepository()
        {
            _clist = new List<Car>()
            {
                new Car()


                {  Id=1,
                   Model="fn-102",
                   Color="Red",
                   CarBrands=Brands.Toyota,
                   DailyRate=10000.50,
                   customerName="Sornali",
                   licenseNumber="bd-679",
                   rentalDays=10,
                   CarType=CarType.New,

                },

                 new Car()


                {  Id=2,
                   Model="fn-107",
                   Color="Blue",
                   CarBrands=Brands.Ford,
                   DailyRate=13000.50,
                   customerName="Kobir",
                   licenseNumber="bd-133",
                   rentalDays=7,
                    CarType=CarType.Old,

                },
                  new Car()


                {  Id=3,
                   Model="BMW-106",
                   Color="Green",
                   CarBrands=Brands.Audi,
                   DailyRate=20000,
                   customerName="Jack",
                   licenseNumber="cd-308",
                   CarType=CarType.Old,
                   rentalDays=5
                },
                   new Car()


                {  Id=4,
                   Model="fn-106",
                   Color="Gray",
                   CarBrands=Brands.BMW,
                   DailyRate=50000.78,
                   customerName="Rexaul",
                   licenseNumber="bd-209",
                   CarType=CarType.New,
                   rentalDays=10
                },
                    new Car()


                {  Id=5,
                   Model="fn-106",
                   Color="Red",
                   CarBrands=Brands.Toyota,
                   DailyRate=15000.50,
                   customerName="Sabrina",
                   licenseNumber="bd-766",
                   CarType=CarType.New,
                   rentalDays=9
                },



            };



        }

        public Car CreateNewCarInformation(Car car)
        {
            Car exitingcar = (from c in _clist orderby c.Id descending select c).Take(1).Single() as Car;
            car.Id = exitingcar.Id + 1;
            _clist.Add(car);
            return car;
        }

        public IEnumerable<Car> GetAllCarInformation()
        {
            IEnumerable<Car> carInfo = from rows in _clist select rows;
            return carInfo;
        }

        public Car GetCarInformationById(int id)
        {
            var infoById = (from c in _clist where c.Id == id select c).FirstOrDefault();
            return infoById;
        }

        public Car RemoveCarInformation(int id)
        {
            Car removeCar = GetCarInformationById(id);
            if (removeCar != null)
            { _clist.Remove(removeCar); }
            return removeCar;
        }

        public Car UpdateCarInformation(Car upcar)
        {
            Car updateCar = GetCarInformationById(upcar.Id);
            if (updateCar != null)
            {
                updateCar.Id = upcar.Id;
                updateCar.Model = upcar.Model;
                updateCar.Color = upcar.Color;
                updateCar.CarBrands = upcar.CarBrands;
                updateCar.DailyRate = upcar.DailyRate;
                updateCar.customerName = upcar.customerName;
                updateCar.licenseNumber = upcar.licenseNumber;
                updateCar.rentalDays = upcar.rentalDays;
                updateCar.CarType = upcar.CarType;




            }
            return updateCar;
        }
    }
}

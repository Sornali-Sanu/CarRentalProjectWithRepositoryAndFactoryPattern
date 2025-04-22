using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Entities;
using CarRentalProjectWithRepositoryAndFactory.Enums;

namespace CarRentalProjectWithRepositoryAndFactory.Factory
{
    public class CarRentalManagerFactory
    {
        public BaseCarFactory CreateFactory(Car car)
        {
            BaseCarFactory returnValue = null;
            if (car.CarType == CarType.New)
            {
                returnValue = new NewCarModelFactory(car);
            }
            else if (car.CarType == CarType.Old)
            {
                returnValue = new OldCarModelFactory(car);
            }
            return returnValue;

        }

    }
}

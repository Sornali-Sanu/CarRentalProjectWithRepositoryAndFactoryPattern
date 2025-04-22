using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Entities;
using CarRentalProjectWithRepositoryAndFactory.Manager;

namespace CarRentalProjectWithRepositoryAndFactory.Factory
{
    public abstract class BaseCarFactory
    {
        protected Car _car;
        protected BaseCarFactory(Car car)
        {
            _car = car;
        }
        public abstract ICarService Create();
        public Car ApplyDailyRate()

        {
            ICarService manager = this.Create();

            _car.DailyRate = manager.GetPercentage();


            return _car;
        }
    }
}

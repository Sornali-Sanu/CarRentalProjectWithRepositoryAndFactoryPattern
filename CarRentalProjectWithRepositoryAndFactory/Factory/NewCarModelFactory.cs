using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Entities;
using CarRentalProjectWithRepositoryAndFactory.Manager;

namespace CarRentalProjectWithRepositoryAndFactory.Factory
{
    public class NewCarModelFactory : BaseCarFactory
    {
        protected new Car _car;

        public NewCarModelFactory(Car car) : base(car)
        {
            _car = car;
        }

        public override ICarService Create()
        {
            NewModelCarManager percentage = new NewModelCarManager();
            _car.DailyRate = percentage.GetPercentage();
            return percentage;
        }
    }
}

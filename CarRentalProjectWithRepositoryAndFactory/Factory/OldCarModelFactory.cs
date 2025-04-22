using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Entities;
using CarRentalProjectWithRepositoryAndFactory.Manager;

namespace CarRentalProjectWithRepositoryAndFactory.Factory
{
    public class OldCarModelFactory : BaseCarFactory
    {
        protected new Car _car;
        public OldCarModelFactory(Car car) : base(car)
        {
            _car = car;
        }

        public override ICarService Create()
        {
            OldModelCarManager percentage = new OldModelCarManager();
            _car.DailyRate = percentage.GetPercentage();
            return percentage;

        }
    }
}

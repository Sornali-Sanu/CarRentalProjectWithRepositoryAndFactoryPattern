using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalProjectWithRepositoryAndFactory.Manager
{
    public class NewModelCarManager : ICarService
    {
        public double GetPercentage()
        {
            double percentage = 0.5;
            double rentprice = 5000;
            double dailyRate = rentprice + (rentprice * percentage);
            return (double)dailyRate;
        }
    }
}

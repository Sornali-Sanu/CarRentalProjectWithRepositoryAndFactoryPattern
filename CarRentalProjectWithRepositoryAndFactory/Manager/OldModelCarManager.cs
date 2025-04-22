using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalProjectWithRepositoryAndFactory.Manager
{
    public class OldModelCarManager : ICarService
    {
        public double GetPercentage()
        {
            double percentage = 0.1;
            double rentprice = 2000;
            double dailyRate = rentprice - (rentprice * percentage);
            return (double)dailyRate;
        }
    }
}

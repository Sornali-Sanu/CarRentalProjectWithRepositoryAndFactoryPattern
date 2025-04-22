using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalProjectWithRepositoryAndFactory.Entities;

namespace CarRentalProjectWithRepositoryAndFactory.Interfaces
{
    
        public interface ICarRental
        {
            IEnumerable<Car> GetAllCarInformation();
            Car GetCarInformationById(int id);
            Car CreateNewCarInformation(Car car);
            Car UpdateCarInformation(Car car);
            Car RemoveCarInformation(int id);
        }
   
}

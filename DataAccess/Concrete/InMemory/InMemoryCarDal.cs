using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
          {
               new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=150,Year=2020,Description="2020 Model Opel Astra "},
               new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=190,Year=2021,Description="2021 Model Opel Astra "},
               new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=200,Year=2019,Description="2019 Model Wolksvagen Passat "},
               new Car{Id=4,BrandId=2,ColorId=4,DailyPrice=250,Year=2020,Description="2020 Model Wolksvagen Passat "}
          };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);


        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return null;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return null;
        }

        public List<Car> GetAllById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.Year = car.Year;
           
        }
    }
}

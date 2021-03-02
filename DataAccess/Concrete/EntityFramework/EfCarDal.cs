using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentaCarContext carContext = new RentaCarContext())
            {
                var result = from car in carContext.Cars
                             join color in carContext.Colors
                              on car.ColorId equals color.Id
                             join brand in carContext.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailDto { BrandName=brand.BrandName,CarName=car.CarName,ColorName=color.ColorName };
                return result.ToList();

                           
                            
                            
            }
        }
    }
}

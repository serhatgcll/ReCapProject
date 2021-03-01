using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentaCarContext carContext = new RentaCarContext())
            {
                var addedEntity = carContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentaCarContext carContext = new RentaCarContext())
            {
                var deletedEntity = carContext.Entry(entity);
               deletedEntity.State = EntityState.Deleted;
                carContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentaCarContext carContext = new RentaCarContext())
            {
                return carContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentaCarContext carContext = new RentaCarContext())
            {
                return filter == null
                    ? carContext.Set<Car>().ToList() 
                    : carContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentaCarContext carContext = new RentaCarContext())
            {
                var updatedEntity = carContext.Entry(entity);
               updatedEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }
    }
}

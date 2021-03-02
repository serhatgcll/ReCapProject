using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            //CarDeletedTest();
            // BrandUpdatedTest();
            //GetCarDetailsTest();
            CarAddedTest();
            //ColorTest();
            // CarTest();

        }

        private static void CarDeletedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 1 });
        }

        private static void BrandUpdatedTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 4, BrandName = "Citroen" });
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "/" + car.CarName + "/" + car.ColorName);
            }
        }

        private static void CarAddedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 150, Year = 2015, Description = "Deneme Ekleme"});
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "/" + color.ColorName);

            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 150, Description = "deneme", Year = 2021, Id = 3 });
        }
    }
}

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
            //RentalAdd();
            //CustomerAdded();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result=rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.CustomerId+"/"+rental.CarId+"/"+rental.RentDate+"/"+rental.ReturnDate);

            }
          

            // BrandUpdatedTest();
            // GetCarDetailsTest();
            //CarAddedTest();
            //ColorTest();
            //CarTest();

        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result2 = customerManager.Add(new Customer { CompanyName = "Rentacar şirket", UserId = 2 });
            Console.WriteLine(result2.Message);
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 3, CustomerId = 2, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);
        }

        private static void BrandUpdatedTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 4, BrandName = "Citroen" });
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.CarName + "/" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
         
        }

        private static void CarAddedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result= carManager.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 150, Year = 2015, Description = "d"});
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
          
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Id + "/" + color.ColorName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

          
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 150, Description = "deneme", Year = 2021, Id = 3 });
        }
    }
}

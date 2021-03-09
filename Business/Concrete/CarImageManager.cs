using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
         [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile files)
        {
            string imagePath = FileHelper.Add(files);
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId));
            if (result == null&&imagePath!=null)
            {
                carImage.Date = DateTime.Now;
                carImage.ImagePath = FileHelper.Add(files);
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ImageAdded);

            }
            return new ErrorResult(Messages.CarImageLimitExceded);

            
        }

        public IResult Delete(CarImage carImage)
        {
          FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

      

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        public IDataResult<List<CarImage>> GetImagesBycarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId).ToList());
        }


        public IDataResult<CarImage> GetImageById(int id)
        {

           
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));

        }

        private IResult CheckImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfImageNull(int id)
        {
            string path = @"carımages\default.png";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id).ToList());

        }

   
    }
    
}

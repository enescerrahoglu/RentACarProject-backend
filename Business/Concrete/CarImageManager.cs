using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Constant;
using Core.Utilities.Business;
using Microsoft.AspNetCore.Http;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using Core.Utilities.FileOperations;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(IFormFile imageFile, CarImage carImage)
        {
            var pathResult = FileOperations.Add(imageFile);
            carImage.ImagePath = pathResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }


        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            FileOperations.Delete(result.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);

        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            var result1 = FileOperations.Update(file, result.ImagePath);
            carImage.ImagePath = result1.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            var result = _carImageDal.Get(c => c.CarId == id);
            if (result.ImagePath == null)
            {
                List<CarImage> Cimage = new List<CarImage>();
                Cimage.Add(new CarImage { CarId = id, ImagePath = @"\CarImages\default.png" });
                return new SuccessDataResult<List<CarImage>>(Cimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(b => b.CarImageId == id));
        }
        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);

            return new SuccessDataResult<List<CarImage>>(result);
        }

        private IResult CheckCarImageAmount(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId);

            if (result.Count > 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();

        }
    }
}
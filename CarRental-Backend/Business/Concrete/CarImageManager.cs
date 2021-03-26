using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null) return result;

            carImage.ImagePath = AddPath(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            DeletePath(carImage);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = UpdatePath(carImage, formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }


        private string ReturnDefaultPath()
        {
            string path = @"\Images\default_pic.png";
            return path;
        }
        private IResult CheckIfImageNull(IFormFile formFile)
        {
            if (formFile == null) return new SuccessResult();
            return new ErrorResult();
        }
        private IResult CheckIfImageHasDefaultPic(string imagePath)
        {
            var defaultPic = ReturnDefaultPath();
            if (defaultPic == imagePath) return new SuccessResult();
            return new ErrorResult();
        }
        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private string AddPath(IFormFile formFile)
        {
            var nullResult = CheckIfImageNull(formFile);
            if (nullResult.Success)
            {
                return ReturnDefaultPath();
            }
            return FileHelper.Add(formFile).Data;
        }
        private void DeletePath(CarImage carImage)
        {
            var result = CheckIfImageHasDefaultPic(carImage.ImagePath);
            if (result.Success)
            {
                FileHelper.Delete(carImage.ImagePath);
            }
        }
        private string UpdatePath(CarImage carImage, IFormFile formFile)
        {
            var result = CheckIfImageHasDefaultPic(carImage.ImagePath);
            if (result.Success)
            {
                string path = AddPath(formFile);
                return path;
            }
            return FileHelper.Update(formFile, carImage.ImagePath).Data;
        }
    }
}
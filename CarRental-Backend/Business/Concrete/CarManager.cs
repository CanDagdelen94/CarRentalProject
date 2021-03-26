using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        //
        public IResult Add(Car car)
        {
            if (car.CarName.Length < 3 && (car.ModelYear <= 1950 && car.ModelYear >= DateTime.Now.Year)) return new ErrorResult();
            _carDal.Add(car); return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car); return new SuccessResult();
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car); return new SuccessResult();
        }


        //
        public IDataResult<List<CarDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }
        public IDataResult<List<CarDetailDto>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => min <= c.DailyPrice && c.DailyPrice <= max));
        }


        //
        public IDataResult<CarDetailDto> GetById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarByDetails(c => c.Id == carId));
        }

        public IDataResult<CarDetailDto> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarByDetails(c => c.BrandId == brandId));
        }

        public IDataResult<CarDetailDto> GetByColorId(int colorId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarByDetails(c => c.ColorId == colorId));
        }

        public IDataResult<CarDetailDto> GetByModelYear(decimal modelYear)
        {
            throw new NotImplementedException();
        }
    }
}

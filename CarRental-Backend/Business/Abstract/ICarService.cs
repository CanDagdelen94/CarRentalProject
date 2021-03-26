
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        // Lists
        IDataResult<List<CarDetailDto>> GetAll();
        IDataResult<List<CarDetailDto>> GetByDailyPrice(decimal min, decimal max);

        // Single
        IDataResult<CarDetailDto> GetById(int carId);
        IDataResult<CarDetailDto> GetByBrandId(int brandId);
        IDataResult<CarDetailDto> GetByColorId(int colorId);
        IDataResult<CarDetailDto> GetByModelYear(decimal modelYear);
        
    }
}

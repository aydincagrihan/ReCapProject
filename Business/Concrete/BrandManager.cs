﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}
		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded);
		}

		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult(Messages.BrandUpdated);
		}

		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult(Messages.BrandDeleted);
		}

		
		IDataResult<List<Brand>> IBrandService.GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
		}

		public IDataResult<Brand> GetById(int id)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
		}

		
	}
}

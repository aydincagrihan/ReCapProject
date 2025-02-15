﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
	public class CarImageManager:ICarImageService
	{
		private readonly ICarImageDal _carImageDal;

		public CarImageManager(ICarImageDal carImageDal)
		{
			_carImageDal = carImageDal;
		}

		public IDataResult<CarImage> GetById(int id)
		{
			var result = _carImageDal.Get(c => c.Id == id);

			IfCarImageOfCarNotExistsAddDefault(ref result);

			return new SuccessDataResult<CarImage>(result);
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId);

			IfCarImageOfCarNotExistsAddDefault(ref result);

			return new SuccessDataResult<List<CarImage>>(result);
		}
		//[SecuredOperation("car.add")]
		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(CarImage carImage, IFormFile file)
		{
			var result = BusinessRules.Run(
				CheckIfCarImageCountOfCarCorrect(carImage.CarId));
			if (result != null) return result;

			carImage.ImagePath = new FileManagerOnDisk().Add(file, CreateNewPath(file));
			carImage.Date = DateTime.Now;
			_carImageDal.Add(carImage);

			return new SuccessResult(Messages.CarImageAdded);
		}

		public IResult Update(CarImage carImage, IFormFile file)
		{
			var carImageToUpdate = _carImageDal.Get(c => c.Id == carImage.Id);
			carImage.CarId = carImageToUpdate.CarId;
			carImage.ImagePath = new FileManagerOnDisk().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
			carImage.Date = DateTime.Now;
			_carImageDal.Update(carImage);

			return new SuccessResult(Messages.CarImageUpdated);
		}

		public IResult Delete(CarImage carImage)
		{
			new FileManagerOnDisk().Delete(carImage.ImagePath);
			_carImageDal.Delete(carImage);

			return new SuccessResult(Messages.CarImageDeleted);
		}


		private void IfCarImageOfCarNotExistsAddDefault(ref List<CarImage> result)
		{
			if (result.Any()) return;
			result.Add(CreateDefaultCarImage());
		}

		private void IfCarImageOfCarNotExistsAddDefault(ref CarImage result)
		{
			result ??= CreateDefaultCarImage();
		}

		private CarImage CreateDefaultCarImage()
		{
			var defaultCarImage = new CarImage
			{
				ImagePath =
					$@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",
				Date = DateTime.Now
			};

			return defaultCarImage;
		}

		private string CreateNewPath(IFormFile file)
		{
			var fileInfo = new FileInfo(file.FileName);
			var newPath =
				$@"{Environment.CurrentDirectory}\Public\Images\CarImage\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

			return newPath;
		}
		private IResult CheckIfCarImageCountOfCarCorrect(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result >= 5) return new ErrorResult(Messages.CarImageCountOfCarError);

			return new SuccessResult();
		}
	}

}

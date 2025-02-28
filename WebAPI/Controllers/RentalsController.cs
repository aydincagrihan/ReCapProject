﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentalsController : ControllerBase
	{
		private readonly IRentalService _rentalService;

		public RentalsController(IRentalService rentalService)
		{
			_rentalService = rentalService;
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _rentalService.GetById(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _rentalService.GetAll();
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("isrentable")]
		public IActionResult IsRentable(Rental rental)
		{
			var result = _rentalService.IsRentable(rental);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}
		[HttpPost("add")]
		public IActionResult Add(Rental rental)
		{
			var result = _rentalService.Add(rental);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Rental rental)
		{
			var result = _rentalService.Update(rental);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Rental rental)
		{
			var result = _rentalService.Delete(rental);
			if (result.Success) return Ok(result);

			return BadRequest(result);
		}
	}
}

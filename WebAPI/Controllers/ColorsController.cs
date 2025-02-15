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
	public class ColorsController : ControllerBase
	{
		private readonly IColorService _colorService;

		public ColorsController(IColorService colorService)
		{
			_colorService = colorService;
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _colorService.GetById(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _colorService.GetAll();
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}
		[HttpPost("add")]
		public IActionResult Add(Color color)
		{
			var result = _colorService.Add(color);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Color color)
		{
			var result = _colorService.Update(color);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Color color)
		{
			var result = _colorService.Delete(color);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}
	}
}

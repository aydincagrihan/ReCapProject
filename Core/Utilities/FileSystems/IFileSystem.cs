﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileSystems
{
	public interface IFileSystem
	{
		string Add(IFormFile file, string path);
		string Update(string pathToUpdate, IFormFile file, string path);
		void Delete(string path);
	}
}

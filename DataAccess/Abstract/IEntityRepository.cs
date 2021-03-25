﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IEntityRepository<T>
	{   //default public,filtreleme yapmak için expression geçtik

		List<T> GetAll(Expression<Func<T,bool>> filter=null);

		T Get(Expression<Func<T,bool>>filter);

		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NewsAggregator.DAL.EntityFramework;

namespace NewsAggregator.DAL.Repository
{
	public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
	{
		public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
		{
			List<T> list;
			using (var context = new AppContext())
			{
				IQueryable<T> dbQuery = context.Set<T>();

				foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
					dbQuery = dbQuery.Include<T, object>(navigationProperty);

				list = dbQuery
					.AsNoTracking()
					.ToList<T>();
			}
			return list;
		}

		public virtual IList<T> GetList(Func<T, bool> where,
			params Expression<Func<T, object>>[] navigationProperties)
		{
			List<T> list;
			using (var context = new AppContext())
			{
				IQueryable<T> dbQuery = context.Set<T>();

				foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
					dbQuery = dbQuery.Include<T, object>(navigationProperty);

				list = dbQuery
					.AsNoTracking()
					.Where(where)
					.ToList<T>();
			}
			return list;
		}

		public virtual T GetSingle(Func<T, bool> where,
			params Expression<Func<T, object>>[] navigationProperties)
		{
			T item = null;
			using (var context = new AppContext())
			{
				IQueryable<T> dbQuery = context.Set<T>();

				foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
					dbQuery = dbQuery.Include<T, object>(navigationProperty);

				item = dbQuery
					.AsNoTracking()
					.FirstOrDefault(where);
			}
			return item;
		}

		public virtual void Add(params T[] items)
		{
			using (var context = new AppContext())
			{
				foreach (T item in items)
				{
					context.Entry(item).State = EntityState.Added;
				}
				context.SaveChanges();
			}
		}
		public virtual void Update(params T[] items)
		{
			using (var context = new AppContext())
			{
				foreach (T item in items)
				{
					context.Entry(item).State = EntityState.Modified;
				}
				context.SaveChanges();
			}
		}

		public virtual void Remove(params T[] items)
		{
			using (var context = new AppContext())
			{
				foreach (T item in items)
				{
					context.Entry(item).State = EntityState.Deleted;
				}
				context.SaveChanges();
			}
		}

	}
}

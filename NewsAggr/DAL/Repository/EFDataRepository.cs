using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NewsAggr.DAL.Repository
{
// ReSharper disable once InconsistentNaming
	public class EFDataRepository<TContext, TEntity> : IGenericDataRepository<TEntity, Guid>
		where TEntity : class, IEntity<Guid> 
		where TContext : DbContext, new()
	{
		private TContext _context = new TContext();
		private bool _disposed = false;

		public TContext Context
		{
			get { return _context; }
			set { _context = value; }
		}


		public virtual IQueryable<TEntity> GetAll(out Exception exception)
		{
			exception = null;

			try
			{
				var query = _context.Set<TEntity>();
				return query;
			}
			catch (Exception ex)
			{
				exception = ex;
				return null;
			}
		}

		public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, out Exception exception)
		{
			exception = null;

			try
			{
				var query = _context.Set<TEntity>().Where(predicate);
				return query;
			}
			catch (Exception ex)
			{
				exception = ex;
				return null;
			}
		}

		public virtual TEntity Get(Guid id, out Exception exception)
		{
			exception = null;

			try
			{
				var query = _context.Set<TEntity>().Find(id);
				return query;
			}
			catch (Exception ex)
			{
				exception = ex;
				return null;
			}
		}

		public virtual bool Add(TEntity entity, out Exception exception)
		{
			exception = null;

			try
			{
				_context.Set<TEntity>().Add(entity);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				exception = ex;
				return false;
			}
		}

		public virtual bool Update(TEntity entity, out Exception exception)
		{
			exception = null;
			try
			{
				_context.Entry(entity).State = EntityState.Modified;
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				exception = ex;
				return false;
			}
		}

		public virtual void Delete(TEntity entity, out Exception exception)
		{
			exception = null;

			try
			{
				_context.Set<TEntity>().Remove(entity);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				exception = ex;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
				if (disposing)
					_context.Dispose();

			this._disposed = true;
		}
		public void Dispose()
		{
			Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
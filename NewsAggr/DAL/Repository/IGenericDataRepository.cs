using System;
using System.Linq;
using System.Linq.Expressions;

namespace NewsAggr.DAL.Repository
{
	public interface IGenericDataRepository<TEntity, in TKey> : IDisposable 
		where TEntity : class, IEntity<Guid>
		where TKey : IComparable
	{
		IQueryable<TEntity> GetAll(out Exception exception);
		IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, out Exception exception);
		TEntity Get(TKey key, out Exception exception);
		bool Add(TEntity entity, out Exception exception);
		bool Update(TEntity entity, out Exception exception);
		void Delete(TEntity entity, out Exception exception);
	}
}

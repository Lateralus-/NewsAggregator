using System;
using NewsAggr.DAL.EntityFramework;

namespace NewsAggr.DAL.Repository
{
	public class NewsAggregatorRepository<TEntity> : EFDataRepository<AppContext, TEntity> where TEntity : class, IEntity<Guid>
	{

	}
}
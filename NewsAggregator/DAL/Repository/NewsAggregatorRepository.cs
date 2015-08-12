using System;
using NewsAggregator.DAL.EntityFramework;

namespace NewsAggregator.DAL.Repository
{
	public class NewsAggregatorRepository<TEntity> : EFDataRepository<AppContext, TEntity> where TEntity : class, IEntity<Guid>
	{

	}
}
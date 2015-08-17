using System;

namespace NewsAggregator.DAL.Repository
{
	public interface IEntity<TId> where TId : IComparable 
	{
		TId Id { get; set; }
	}
}

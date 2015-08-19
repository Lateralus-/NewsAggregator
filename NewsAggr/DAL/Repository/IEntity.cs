using System;

namespace NewsAggr.DAL.Repository
{
	public interface IEntity<TId> where TId : IComparable 
	{
		TId Id { get; set; }
	}
}

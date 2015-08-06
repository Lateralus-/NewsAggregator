using System;
using System.ComponentModel.DataAnnotations;

namespace NewsAggregator.Models 
{
	public class Resource
	{
		[Key]
		public Guid ResourceId { get; set; }

		public string Name { get; set; }

		public string Link { get; set; }

		public string Tag { get; set; }

		public DateTime LastUpdatedDate { get; set; }

		public virtual Feed Feed { get; set; }
	}
}

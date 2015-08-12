using System;
using System.ComponentModel.DataAnnotations;
using NewsAggregator.DAL.Repository;

namespace NewsAggregator.Client.Models
{
	public class Feed : IEntity<Guid>
	{
		[Key]
		public Guid Id { get; set; }

		public string Title { get; set; }

		public string Body { get; set; }

		public DateTime Date { get; set; }

		public string AuthorName { get; set; }

		public virtual Resource Resource { get; set; }

	}

}

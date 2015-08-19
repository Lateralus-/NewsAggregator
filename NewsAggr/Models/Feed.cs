using System;
using System.ComponentModel.DataAnnotations;
using NewsAggr.DAL.Repository;

namespace NewsAggr.Models
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

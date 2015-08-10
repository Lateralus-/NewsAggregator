using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsAggregator.Client.Models
{
	public class Feed
	{
		[Key]
		public Guid FeedId { get; set; }

		public string Title { get; set; }

		public string Body { get; set; }

		public DateTime Date { get; set; }

		public string AuthorName { get; set; }

		public virtual Resource Resource { get; set; }
	}

}

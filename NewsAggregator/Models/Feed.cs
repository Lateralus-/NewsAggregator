﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsAggregator.Models
{
	public class Feed
	{
		[Key]
		public Guid FeedId { get; set; }

		public string Title { get; set; }

		public string Body { get; set; }

		public DateTime Date { get; set; }

		public string AuthorName { get; set; }

		public virtual ICollection<Resource> Resources { get; set; }
	}

	public class AnotherOneTable
	{
		[Key]
		public Guid Id { get; set; }
		public string NAme { get; set; }
	}
}
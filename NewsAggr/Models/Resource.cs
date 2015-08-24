using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewsAggr.DAL;
using NewsAggr.DAL.Repository;

namespace NewsAggr.Models 
{
	public class Resource : IEntity<Guid>
	{
		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Link { get; set; }

		public string Tag { get; set; }

		public DateTime LastUpdatedDate { get; set; }

		public virtual ICollection<Feed> Feeds { get; set; }

        public Resource()
        {
            this.Id = Guid.NewGuid();
        }
	}
}

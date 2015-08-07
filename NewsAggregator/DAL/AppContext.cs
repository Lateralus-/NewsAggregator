using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NewsAggregator.Models;

namespace NewsAggregator.DAL
{
	public class AppContext : DbContext
	{
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Feed> Feeds { get; set; }

		public AppContext() : base("AppContext") {}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}

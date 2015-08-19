using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NewsAggr.Models;

namespace NewsAggr.DAL.EntityFramework
{
	public partial class AppContext : DbContext
	{
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Feed> Feeds { get; set; }

		public AppContext() : base("NewsAggr") {}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}

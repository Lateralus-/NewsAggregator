using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NewsAggregator.Models;

namespace NewsAggregator.DAL
{
	public class AppContext : DbContext
	{
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Feed> Feeds { get; set; }
		public DbSet<AnotherOneTable> AnotherOneTables { get; set; }

		public AppContext() : base("AppContext")
		{
		}

		public AppContext(string connString)
			: base(connString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}

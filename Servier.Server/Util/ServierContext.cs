using Microsoft.EntityFrameworkCore;
using Servier.Server.Models;

namespace Servier.Server.Util
{
    public class ServierContext : DbContext
    {
		public DbSet<DataFile> DataFiles { get; set; }
		public ServierContext()
		{
			Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SRV;Username=postgres;Password=root");
		}
	}
}

using BuyBitz.Practical.Dto;
using Microsoft.EntityFrameworkCore;

namespace BuyBitz.Practical.DataAccess
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Country> Countries { get; set; }
		public DbSet<State> States { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
	}
}

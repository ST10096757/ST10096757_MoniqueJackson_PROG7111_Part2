using AngryEnergy_Test.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AngryEnergy_Test.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<FarmerModel> FarmersDbSet { get; set; }
		public DbSet<UserModel> UsersDbSet { get; set; }
		public DbSet<ProductModel> ProductsDbSet { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}


    }
}
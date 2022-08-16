using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Data
{
	public class WeatherDbContext : DbContext
	{
		public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
			:base(options)
		{

		}

		public DbSet<Weather> Weather { get; set; }

		public DbSet<WeatherStatistics> WeatherStatistics { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Seed Weather Table
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 1, City = "Lisboa", Temperature = 25, Date = new DateTime(2022, 08, 12, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 2, City = "Lisboa", Temperature = 27, Date = new DateTime(2022, 08, 13, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 3, City = "Lisboa", Temperature = 28, Date = new DateTime(2022, 08, 14, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 4, City = "Lisboa", Temperature = 30, Date = new DateTime(2022, 08, 15, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 5, City = "Lisboa", Temperature = 22, Date = new DateTime(2022, 08, 16, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 6, City = "Porto", Temperature = 20, Date = new DateTime(2022, 08, 12, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 7, City = "Porto", Temperature = 22, Date = new DateTime(2022, 08, 13, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 8, City = "Porto", Temperature = 21, Date = new DateTime(2022, 08, 14, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 9, City = "Porto", Temperature = 23, Date = new DateTime(2022, 08, 15, 10, 00, 00) });
			modelBuilder.Entity<Weather>().HasData(
				new Weather { Id = 10, City = "Porto", Temperature = 26, Date = new DateTime(2022, 08, 16, 10, 00, 00) });
		}

	}
}

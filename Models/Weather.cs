using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
	public class Weather
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string City { get; set; }

		public double Temperature { get; set; }

		[Required]
		public DateTime Date { get; set; }
	}
}

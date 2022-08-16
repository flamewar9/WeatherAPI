using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
	public class WeatherStatistics
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string City { get; set; }
		public double CurrentTemperature { get; set; }
		public double AverageTemp { get; set; }
		public double MaxTemp { get; set; }
		public double MinTemp { get; set; }
	}
}

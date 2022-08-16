using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPI.Data;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeatherStatisticsController : ControllerBase
	{
		private readonly WeatherDbContext _context;
		private string _myWeatherKey { get; set; }

		public WeatherStatisticsController(WeatherDbContext context, IConfiguration configuration)
		{
			this._context = context;
			this._myWeatherKey = configuration.GetValue<string>("MyWeatherKey");
		}

		[HttpGet("city")]
		public async Task<WeatherStatistics> Get(string city)
		{
			var query = await _context.Weather.Where(w => w.City == city).ToListAsync();

			WeatherStatistics weatherStatistics = new WeatherStatistics()
			{
				City = city,
				AverageTemp = query.Average(w => w.Temperature),
				MaxTemp = query.Max(w => w.Temperature),
				MinTemp = query.Min(w => w.Temperature)
			};

			var url = string.Format("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{0}/today?unitGroup=metric&include=current&key={1}",
				city, _myWeatherKey);

			var httpRequest = (HttpWebRequest)WebRequest.Create(url);

			httpRequest.Accept = "application/json";

			var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				var result = streamReader.ReadToEnd();
				dynamic weather = JsonConvert.DeserializeObject(result);

				foreach (var day in weather.days)
				{
					weatherStatistics.CurrentTemperature = day.temp;
				}
			}

			return weatherStatistics;
		}
	}
}

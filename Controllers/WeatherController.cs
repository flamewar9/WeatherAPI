using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Data;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeatherController : ControllerBase
	{
		private readonly WeatherDbContext _context;

		public WeatherController(WeatherDbContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public async Task<IEnumerable<Weather>> Get()
		{
			return await _context.Weather.ToListAsync();
		}

		[HttpGet("id")]
		[ProducesResponseType(typeof(Weather), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(int id)
		{
			var weather = await _context.Weather.FindAsync(id);
			return weather == null ? NotFound() : Ok(weather);
		}

		[HttpGet("city")]
		[ProducesResponseType(typeof(Weather), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetByCity(string city)
		{
			var weather = await _context.Weather.Where(w => w.City.ToLower() == city.ToLower()).ToListAsync();
			return weather == null ? NotFound() : Ok(weather);
		}

		//[HttpPost]
		//[ProducesResponseType(StatusCodes.Status201Created)]
		//public async Task<IActionResult> AddWeather(Weather weather)
		//{
		//	await _context.Weather.AddAsync(weather);
		//	await _context.SaveChangesAsync();

		//	return CreatedAtAction(nameof(GetById), new { id = weather.Id }, weather);
		//}

		[HttpPost("{city}/{date}/{temperature}")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> AddWeather(string city, DateTime date, double temperature)
		{
			Weather weather = new Weather()
			{
				City = city,
				Date = date,
				Temperature = temperature
			};
			await _context.Weather.AddAsync(weather);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = weather.Id }, weather);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> AddWeatherWithBody(Weather weather)
		{
			await _context.Weather.AddAsync(weather);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = weather.Id }, weather);
		}

		[HttpPut("{city}/{date}/{temperature}")]
		public async Task<IActionResult> UpdateWeather(string city, DateTime date, double temperature)
		{
			var query = await _context.Weather.Where(w => w.City == city && w.Date == date).FirstOrDefaultAsync();

			if (query == null) return BadRequest();

			query.Temperature = temperature;

			//_context.Entry(weather).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateWeatherWithBody(int id, Weather weather)
		{
			if (id != weather.Id) return BadRequest();

			_context.Entry(weather).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using System;
using TariffComparison.Contracts;

namespace TariffComparison.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TariffComparisonController : ControllerBase
	{
		private readonly ITariffComparisonService _service;
		public TariffComparisonController(ITariffComparisonService service)
		{
			_service = service;
		}
		/// <summary>
		/// Description - Get Tariff Comparison Products
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		/// <returns>List of Tariff Comparison Product</returns>
		[HttpGet]
		public IActionResult GetAllGetTariffProducts()
		{
			var item = _service.GetAllTariffProducts();
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}
		/// <summary>
		/// Description - Get Tariff Calculations, sorted by Annual Cost in Ascending Order
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		/// <param name="Consumption"></param>
		/// <returns>List of TariffComparisonProduct</returns>
		[HttpGet("{Consumption}")]
		public IActionResult Get(int Consumption)
		{
			var item = _service.GetTariffProductsByConsumption(Consumption);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}
	}
}

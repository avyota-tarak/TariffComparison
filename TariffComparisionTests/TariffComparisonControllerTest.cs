using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TariffComparison.Contracts;
using TariffComparison.Controllers;
using TariffComparison.Model;
using TariffComparison.Services;
using Xunit;

namespace TariffComparisionTests
{
	public class TariffComparisonControllerTest
	{
		private readonly TariffComparisonController _controller;
		private readonly ITariffComparisonService _service;

		public TariffComparisonControllerTest()
		{
			_service = new TariffComparisonService();
			_controller = new TariffComparisonController(_service);
		}

		/// <summary>
		/// Description - Retrived Tariff Products
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void GetAllGetTariffProducts_ReturnsOkResult()
		{
			// Act
			var okResult = _controller.GetAllGetTariffProducts();

			// Assert
			Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
		}


		/// <summary>
		/// Description - Basic Tariff Calculation, inputs 3500, expected 830
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void Basic_Tariff_Calculations_Checks_For_Consumption_3500_Expected_830()
		{
			// Act
			decimal ConsumptionResult = _service.CalculateBasicElectricityTariff(3500);

			// Assert
			var Consumption = Assert.IsType<decimal>(ConsumptionResult);
			Assert.Equal(830, Consumption);
		}

		/// <summary>
		/// Description - Basic Tariff Calculation, inputs 4500, expected 1050
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void Basic_Tariff_Calculations_Checks_For_Consumption_4500_Expected_1050()
		{
			// Act
			decimal ConsumptionResult = _service.CalculateBasicElectricityTariff(4500);

			// Assert
			var Consumption = Assert.IsType<decimal>(ConsumptionResult);
			Assert.Equal(1050, Consumption);
		}

		/// <summary>
		/// Description - Basic Tariff Calculation, inputs 6000, expected 1380
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void Basic_Tariff_Calculations_Checks_For_Consumption_6000_Expected_1380()
		{
			// Act
			decimal ConsumptionResult = _service.CalculateBasicElectricityTariff(6000);

			// Assert
			var Consumption = Assert.IsType<decimal>(ConsumptionResult);
			Assert.Equal(1380, Consumption);
		}


		/// <summary>
		/// Description - Packaged Tariff Calculation, inputs 3500, expected 800
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void Packaged_Tariff_Calculations_Checks_For_Consumption_3500_Expected_800()
		{
			// Act
			decimal ConsumptionResult = _service.CalculatePackagedTariff(3500);

			// Assert
			var Consumption = Assert.IsType<decimal>(ConsumptionResult);
			Assert.Equal(800, Consumption);
		}


		/// <summary>
		/// Description - Packaged Tariff Calculation, inputs 4500, expected 950
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void PackagedTariff_Calculations_Checks_For_Consumption_4500_Expected_950()
		{
			// Act
			decimal ConsumptionResult = _service.CalculatePackagedTariff(4500);

			// Assert
			var Consumption = Assert.IsType<decimal>(ConsumptionResult);
			Assert.Equal(950, Consumption);
		}


		/// <summary>
		/// Description - Packaged Tariff Calculation, inputs 6000, expected 1400
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void PackagedTariff_Calculations_Checks_For_Consumption_6000_Expected_1400()
		{
			// Act
			decimal ConsumptionResult = _service.CalculatePackagedTariff(6000);

			// Assert
			var Consumption = Assert.IsType<decimal>(ConsumptionResult);
			Assert.Equal(1400, Consumption);
		}


		/// <summary>
		/// Description - Compares and get Cheapest Tariff Plan By Consumption Units, inputs 3500, expected Packaged Tariff
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void Get_Cheapest_TarriffPlan_For_Consumption_3500_Expected_Packaged_Tariff()
		{
			// Act
			TariffComparisonProductByCosumption ConsumptionResult = _service.GetTariffProductsByConsumption(3500)[0];

			// Assert
			var Consumption = Assert.IsType<TariffComparisonProductByCosumption>(ConsumptionResult);
			Assert.Equal("Packaged Tariff", Consumption.TariffName);
		}

		/// <summary>
		/// Description - Compares and get Cheapest Tariff Plan By Consumption Units, inputs 4500, expected Packaged Tariff
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void Get_Cheapest_TarriffPlan_For_Consumption_4500_Expected_Packaged_Tariff()
		{
			// Act
			TariffComparisonProductByCosumption ConsumptionResult = _service.GetTariffProductsByConsumption(4500)[0];

			// Assert
			var Consumption = Assert.IsType<TariffComparisonProductByCosumption>(ConsumptionResult);
			Assert.Equal("Packaged Tariff", Consumption.TariffName);
		}

		/// <summary>
		/// Description - Compares and get Cheapest Tariff Plan By Consumption Units, inputs 6000, expected Basic Electricity Tariff
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		[Fact]
		public void Get_Cheapest_TarriffPlan_For_Consumption_6000_Expected_Basic_Electricity_Tariff()
		{
			// Act
			TariffComparisonProductByCosumption ConsumptionResult = _service.GetTariffProductsByConsumption(6000)[0];

			// Assert
			var Consumption = Assert.IsType<TariffComparisonProductByCosumption>(ConsumptionResult);
			Assert.Equal("Basic Electricity Tariff", Consumption.TariffName);
		}
	}
}

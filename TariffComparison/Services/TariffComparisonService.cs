using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Contracts;
using TariffComparison.Model;

namespace TariffComparison.Services
{
	public class TariffComparisonService : ITariffComparisonService
	{
		private List<TariffComparisonProduct> _tariffComparisonProduct;
		private List<TariffComparisonProductByCosumption> _tariffComparisonProductByCosumption;

		private string BasicElectricityTariffName = "Basic Electricity Tariff";
		private string PackagedTariffTariffName = "Packaged Tariff";

		private string BasicElectricityTariffCalculationModel = "Base costs per month 5 € + consumption costs 22 cent/kWh";
		private string PackagedTariffCalculationModel = "800 € for up to 4000 kWh/year and above 4000 kWh/year additionally 30 cent/kWh";

		private string UnitWithDuration = " €/year";

		/// <summary>
		/// Description - Get Tariff Comparison Products
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		/// <returns>List of Tariff Comparison Product</returns>
		public List<TariffComparisonProduct> GetAllTariffProducts()
		{
			_tariffComparisonProduct = new List<TariffComparisonProduct>()
			{
				new TariffComparisonProduct() {  TariffName =BasicElectricityTariffName , CalculationModel = BasicElectricityTariffCalculationModel},
				new TariffComparisonProduct() {  TariffName =PackagedTariffTariffName , CalculationModel = PackagedTariffCalculationModel}
			};
			return _tariffComparisonProduct;
		}

		/// <summary>
		/// Description - Get Tariff Calculations, sorted by Annual Cost in Ascending Order
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		/// <param name="Consumption"></param>
		/// <returns>List of TariffComparisonProduct</returns>
		public List<TariffComparisonProductByCosumption> GetTariffProductsByConsumption(int Consumption)
		{
			try
			{
				_tariffComparisonProductByCosumption = new List<TariffComparisonProductByCosumption>()
			{
				new TariffComparisonProductByCosumption { TariffName = BasicElectricityTariffName, CalculationModel = BasicElectricityTariffCalculationModel, AnnualCostsInNumber = CalculateBasicElectricityTariff(Consumption) },
				new TariffComparisonProductByCosumption { TariffName = PackagedTariffTariffName, CalculationModel = PackagedTariffCalculationModel, AnnualCostsInNumber = CalculatePackagedTariff(Consumption) },
			};
				List<TariffComparisonProductByCosumption> _sortedTariffComparisonProductByCosumption = _tariffComparisonProductByCosumption.OrderBy(a => a.AnnualCostsInNumber).ToList();
				_sortedTariffComparisonProductByCosumption.ForEach(a => a.AnnualCosts = a.AnnualCostsInNumber + UnitWithDuration);
				return _sortedTariffComparisonProductByCosumption;
			}
			catch (Exception ex)
			{
				throw ex.InnerException;
				//Handling exception and loggins at proper place. In production, this has to handle using separately in .Net core - using Exception Handler Middleware   
			}
		}

		/// <summary>
		/// Description - Calculates Basic Electricity Tariff
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		/// <param name="Consumption"></param>
		/// <returns>Annual Cost</returns>
		public decimal CalculateBasicElectricityTariff(int Consumption)
		{
			return 60 + (decimal)(0.22 * (Consumption < 0 ? 0 : Consumption));
		}


		/// <summary>
		/// Description - Calculates Packaged Tariff
		/// Developed by Tarak Dave
		/// Created Date - 28th October 2021
		/// </summary>
		/// <param name="Consumption"></param>
		/// <returns>Annual Cost</returns>
		public decimal CalculatePackagedTariff(int Consumption)
		{
			return Consumption <= 4000 ? 800 : (decimal)(800 + ((Consumption - 4000) * 0.30));
		}
	}
}

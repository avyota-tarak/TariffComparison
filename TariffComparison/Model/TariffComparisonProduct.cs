using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TariffComparison.Model
{
	public class TariffComparisonProduct
	{
		public string TariffName { get; set; }
		public string CalculationModel { get; set; }

	}
	public class TariffComparisonProductByCosumption : TariffComparisonProduct
	{
		[JsonIgnore]
		public decimal AnnualCostsInNumber { get; set; }
		public string AnnualCosts { get; set; }
	}
}

using System.Collections.Generic;
using TariffComparison.Model;

namespace TariffComparison.Contracts
{
	public interface ITariffComparisonService
    {
        List<TariffComparisonProduct> GetAllTariffProducts();
        List<TariffComparisonProductByCosumption> GetTariffProductsByConsumption(int Consumption);
        public decimal CalculateBasicElectricityTariff(int Consumption);
        public decimal CalculatePackagedTariff(int Consumption);

    }
}

using Fruitpal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fruitpal.Contracts
{
	/// <summary>
	/// Fruitpal Calculator Interface
	/// </summary>
	public interface IFruitpalCalculator
	{
		/// <summary>
		/// Retrieves the cost of the fruit in different countries
		/// </summary>
		/// <param name="fruit">The fruit you want to retreive the prices for.</param>
		/// <param name="pricePerTon">The price per ton.</param>
		/// <param name="tons">The amount of tons.</param>
		/// <returns>Returns a list of FruitPriceRecord instances</returns>
		IList<FruitPriceRecord> CalculateCost(string fruit, decimal pricePerTon, int tons);
	}
}

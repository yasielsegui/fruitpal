using Fruitpal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fruitpal.Contracts
{
	/// <summary>
	/// Market Data Provider Interface
	/// </summary>
	public interface IMarketOverheadDataProvider
	{
		/// <summary>
		/// Retrieves the fruit prices data pulled from a default path.
		/// </summary>
		/// <returns>Returns a list of MarketOverheadDataEntry instances.</returns>
		IList<MarketOverheadDataEntry> PullData();

		/// <summary>
		/// Retrieves the fruit prices data pulled from the specified path.
		/// </summary>
		/// <param name="path">The path you want to pull the data from.</param>
		/// <returns>Returns a list of MarketOverheadDataEntry instances.</returns>
		IList<MarketOverheadDataEntry> PullData(string path);
	}
}

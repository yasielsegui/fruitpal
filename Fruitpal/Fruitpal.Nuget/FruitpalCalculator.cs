using Fruitpal.Contracts;
using Fruitpal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fruitpal
{
	public class FruitpalCalculator : IFruitpalCalculator
	{
		private readonly IMarketOverheadDataProvider _marketDataProvider;

		public FruitpalCalculator(IMarketOverheadDataProvider marketDataProvider)
		{
			// check if parameter is null
			if (marketDataProvider == null)
				// throw error
				throw new ArgumentNullException(nameof(marketDataProvider));
			// assign market data provider
			_marketDataProvider = marketDataProvider;
		}

		public IList<FruitPriceRecord> CalculateCost(string fruit, decimal pricePerTon, int tons)
		{
			// create the list to be filled
			var listResult = new List<FruitPriceRecord>();
			// pul the marked data from the source
			var maketDataEntries = _marketDataProvider.PullData();
			// select from the marked data those entries relevant to the fruit
			var fruitDataEntries = maketDataEntries.Where(x => x.Commodity.ToLower() == fruit.ToLower()).ToList();
			// check if no relevent entries were found
			if (fruitDataEntries.Count == 0)
				// throw error
				throw new Exception("The fruit does not appear among the commodities.");
			// for each fruit entry
			foreach (var fruitEntry in fruitDataEntries)
			{
				// map the market data entry to fruit price record
				var fruitPriceRecord = new FruitPriceRecord()
				{
					Country = fruitEntry.Country,
					Cost = pricePerTon,
					FixedOverhead = decimal.Parse(fruitEntry.FixedOverhead),
					Fruit = fruitEntry.Commodity,
					Tons = tons,
					VariableOverhead = decimal.Parse(fruitEntry.VariableOverhead)
				};
				// add the fruit price record to the list
				listResult.Add(fruitPriceRecord);
			}
			// return the list
			return listResult.OrderByDescending(x => x.TotalCost).ToList();
		}
	}
}

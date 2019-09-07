using Fruitpal.Contracts;
using Fruitpal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Fruitpal.Tests
{
	[TestClass]
	public class FruitpalCalculatorTest
	{
		private Mock<IMarketOverheadDataProvider> _marketDataProvider;

		[TestCleanup]
		public void TestCleanup()
		{
			_marketDataProvider = null;
		}

		[TestInitialize]
		public void TestInitialize()
		{
			_marketDataProvider = new Mock<IMarketOverheadDataProvider>();
		}

		[TestMethod]
		[ExpectedException(typeof(Exception), "The fruit does not appear among the commodities.")]
		public void MissingFruitInMarketDataThrowAnException()
		{
			_marketDataProvider.Setup(x => x.PullData()).Returns(SampleMarketData());

			var fruitpalCalculator = new FruitpalCalculator(_marketDataProvider.Object);

			var result = fruitpalCalculator.CalculateCost("manggo", It.IsAny<decimal>(), It.IsAny<int>());

		}

		[TestMethod]
		[ExpectedException(typeof(Exception), "The fruit does not appear among the commodities.")]
		public void PullDataReturnsEmptyListThrowAnException()
		{
			_marketDataProvider.Setup(x => x.PullData()).Returns(new List<MarketOverheadDataEntry>());

			var fruitpalCalculator = new FruitpalCalculator(_marketDataProvider.Object);

			var result = fruitpalCalculator.CalculateCost("mango", It.IsAny<decimal>(), It.IsAny<int>());
		}

		[TestMethod]
		public void ResutlsShouldComeCorrectAndOrderedByTotalCostFromHighestToLowest()
		{
			_marketDataProvider.Setup(x => x.PullData()).Returns(SampleMarketData());

			var fruitpalCalculator = new FruitpalCalculator(_marketDataProvider.Object);

			var resultList = fruitpalCalculator.CalculateCost("mango", 53, 405);

			for (int i = 0; i < resultList.Count - 1; i++)
			{
				// validating calculations correctness
				Assert.AreEqual(resultList[i].TotalCost, (resultList[i].Cost + resultList[i].VariableOverhead) * resultList[i].Tons + resultList[i].FixedOverhead);
				// validating order correctness
				Assert.IsTrue(resultList[i].TotalCost >= resultList[i + 1].TotalCost);
			}
			// validating calculations correctness on the last element of the list
			Assert.AreEqual(resultList[resultList.Count - 1].TotalCost, (resultList[resultList.Count - 1].Cost + resultList[resultList.Count - 1].VariableOverhead) * resultList[resultList.Count - 1].Tons + resultList[resultList.Count - 1].FixedOverhead);
		}

		private List<MarketOverheadDataEntry> SampleMarketData()
		{
			return new List<MarketOverheadDataEntry>() 
			{
				new MarketOverheadDataEntry()
				{
					Commodity = "mango",
					Country = "MX",
					FixedOverhead = "32.00",
					VariableOverhead = "1.24"
				},
				new MarketOverheadDataEntry()
				{
					Commodity = "mango",
					Country = "BR",
					FixedOverhead = "20.00",
					VariableOverhead = "1.42"
				},
			};
		}
	}
}

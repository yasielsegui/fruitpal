using Fruitpal.Contracts;
using Fruitpal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fruitpal.Tests
{
	[TestClass]
	public class MarketOverheadDataProviderTest
	{
		[TestCleanup]
		public void TestCleanup()
		{
		}

		[TestInitialize]
		public void TestInitialize()
		{
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "path")]
		public void EmptyPathThrowArgumentException()
		{
			var marketDataProvider = new MarketOverheadDataProvider("");
			marketDataProvider.PullData();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "path")]
		public void NullPathThrowArgumentException()
		{
			var marketDataProvider = new MarketOverheadDataProvider(null);
			marketDataProvider.PullData();
		}

		[TestMethod]
		public void UnavailableRemotePathReturnNull()
		{
			var marketDataProvider = new MarketOverheadDataProvider("http://remotepath.com/maketdata.json");
			var result = marketDataProvider.PullData();

			Assert.IsNull(result);
		}

		[TestMethod]
		public void ValidLocalPathJsonReturnActualData()
		{
			string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
			var marketDataProvider = new MarketOverheadDataProvider($"{projectDirectory}\\marketdata.json");
			var result = marketDataProvider.PullData();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void WrongLocalPathReturnNull()
		{
			string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
			var marketDataProvider = new MarketOverheadDataProvider($"{projectDirectory}\\_marketdata.json");
			var result = marketDataProvider.PullData();

			Assert.IsNull(result);
		}
	}
}

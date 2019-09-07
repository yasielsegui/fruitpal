using Newtonsoft.Json;
using System;

namespace Fruitpal.Models
{
	/// <summary>
	/// Represent each entry in the Market Data
	/// </summary>
	public class MarketOverheadDataEntry
	{
		/// <summary>
		/// Country Code
		/// </summary>
		public string Country { get; set; }
		
		/// <summary>
		/// Commodity
		/// </summary>
		public string Commodity { get; set; }

		/// <summary>
		/// Fixed Overhead fee
		/// </summary>
		[JsonProperty("FIXED_OVERHEAD")]
		public string FixedOverhead { get; set; }

		/// <summary>
		/// Variable Overhead fee
		/// </summary>
		[JsonProperty("VARIABLE_OVERHEAD")]
		public string VariableOverhead { get; set; }
	}
}

using System;

namespace Fruitpal.Models
{
	/// <summary>
	/// Represent the Fruit Price Record to compare
	/// </summary>
	public class FruitPriceRecord
	{
		/// <summary>
		/// Fruit label
		/// </summary>
		public string Fruit { get; set; }

		/// <summary>
		/// Amount of tons
		/// </summary>
		public int Tons { get; set; }

		/// <summary>
		/// Country Code
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// Fixed Overhead fee
		/// </summary>
		public decimal FixedOverhead { get; set; }
		/// <summary>
		/// 
		/// Variable Overhead fee
		/// </summary>
		public decimal VariableOverhead { get; set; }

		/// <summary>
		/// Cost
		/// </summary>
		public decimal Cost { get; set; }

		/// <summary>
		/// Total Cost considering all the overheads and fees
		/// </summary>
		public decimal TotalCost 
		{ 
			get 
			{
				return (Cost + VariableOverhead) * Tons + FixedOverhead;
			} 
		}

		/// <summary>
		/// Convert the object to string.
		/// </summary>
		/// <returns>A string representation of the instance</returns>
		public override string ToString()
		{
			return $"{Country} {TotalCost} | ({Cost + VariableOverhead}*{Tons}) + {FixedOverhead}";
		}
	}
}

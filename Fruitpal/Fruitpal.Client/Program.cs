using Fruitpal.Contracts;
using System;
using System.IO;

namespace Fruitpal.Client
{
	class Program
	{
		static IFruitpalCalculator _fruitpalCalculator;

		static void Main(string[] args)
		{
			_fruitpalCalculator = new FruitpalCalculator(new MarketOverheadDataProvider(Path.GetFullPath(@"..\..\..\marketdata.json")));
			Console.WriteLine("Welcome to Fruitpal !");
			Console.WriteLine();
			while (true)
			{
				try
				{
					// enter command message
					Console.WriteLine("Enter command:");
					// reading the line
					var line = Console.ReadLine();
					// checking if is the 'exit command'
					if (line.ToLower() == "exit")
					{
						// break the execution
						break;
					}
					// split the line
					var lineSplit = line.Split(" ");
					// rading the command
					var command = lineSplit[0];
					// checking if is the 'fruitpal' command
					if (command.ToLower() != "fruitpal")
					{
						// print 'not recognized command' message
						Console.WriteLine($"Command '{command}' not recognized.");
						// continue the execution
						continue;
					}
					// reading the fruit
					var  fruit = lineSplit[1];
					// reading and parsing the cost
					var cost = decimal.Parse(lineSplit[2]);
					// reading and parsing the amount of tons
					var tons = int.Parse(lineSplit[3]);
					// calculation the cost
					var fruitPricesEntries = _fruitpalCalculator.CalculateCost(fruit, cost, tons);
					// foreach entry in costs
					foreach (var entry in fruitPricesEntries)
						// print the cost details
						Console.WriteLine(entry);
				}
				catch (Exception ex)
				{
					// print error message
					Console.WriteLine("There was an error!");
				}
				// print blank line between each execution
				Console.WriteLine();
			}
		}
	}
}

using Fruitpal.Contracts;
using Fruitpal.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Fruitpal
{
	public class MarketOverheadDataProvider : IMarketOverheadDataProvider
	{
		private readonly string _path;

		public MarketOverheadDataProvider(string path)
		{
			// check if parameter is null or empty 
			if (string.IsNullOrEmpty(path))
				// throw error
				throw new ArgumentException(nameof(path));
			// assign path 
			_path = path;
		}

		public IList<MarketOverheadDataEntry> PullData()
		{
			// call the PullData overload passing the private member '_path'
			return PullData(_path);
		}

		public IList<MarketOverheadDataEntry> PullData(string path)
		{
			// check if parameter is null or empty
			if (string.IsNullOrEmpty(path))
				// throw error
				throw new ArgumentException(nameof(path));

			try
			{
				// json string
				string jsonString;
				// check if is a local path
				if (string.IsNullOrEmpty(new Uri(path).Host))
				{
					// read string form local file
					jsonString = File.ReadAllText(path);
				}
				else // it is a remote path
				{
					// creating http client
					using (var httpClient = new HttpClient())
					{
						// hitting the endpoint to retrieve the data
						jsonString = httpClient.GetStringAsync(path).Result;
					}
				}
				// deserializing the json into an List object
				var listResult = JsonConvert.DeserializeObject<List<MarketOverheadDataEntry>>(jsonString);
				// returning the result list
				return listResult;
			}
			catch (Exception ex)
			{
				// log the error
				Debug.WriteLine(ex.Message);
				// return null
				return null;
			}
		}
	}
}

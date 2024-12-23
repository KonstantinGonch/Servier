﻿using CsvHelper;
using Servier.Server.Models;
using System.Formats.Asn1;
using System.Globalization;

namespace Servier.Server.Util
{
	public class ReportFileStorageManager : IReportFileStorageManager
	{
		private const string _filePath = "Data/data.csv";
		private IEnumerable<SalesItem> _reportData;

		public ReportFileStorageManager()
		{
			_reportData = new List<SalesItem>();
		}

		public IEnumerable<SalesItem> GetSalesItemsFromFile()
		{
			if (_reportData.Any())
			{
				return _reportData;
			}
			var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _filePath);

			using (var reader = new StreamReader(filePath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				var records = csv.GetRecords<SalesItem>();
				_reportData = records;
				return records;
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace MultiRecords
{
	[DelimitedRecord(";")]
	public class CustomersSemiColon
	{
		public string Nombre;
		public string Apellido;
	}
	[DelimitedRecord("|")]
	public class OrdersVerticalBar
	{
		public int OrderID;
		public string CustomerID;
		public int EmployeeID;
		public DateTime OrderDate;
		public DateTime RequiredDate;

		[FieldNullValue(typeof(DateTime), "2005-1-1")]
		public DateTime ShippedDate;
		public int ShipVia;
		public decimal Freight;
	}
	class Program
	{
		static void Main(string[] args)
		{
			MultiRecordEngine engine;
			engine = new MultiRecordEngine(typeof(OrdersVerticalBar), typeof(CustomersSemiColon)); 
			engine.RecordSelector = new RecordTypeSelector(CustomSelector);
			object[] res = engine.ReadFile(@"C:\Documents and Settings\l0737860\Mis documentos\Multi.txt"); 
		}
		static Type CustomSelector(MultiRecordEngine engine, string record)
		{
			if (Char.IsLetter(record[0]))
				return typeof(CustomersSemiColon);
			else
				return typeof(OrdersVerticalBar);
		}
	}

}

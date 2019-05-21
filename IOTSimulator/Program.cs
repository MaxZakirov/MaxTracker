using System;

namespace IOTSimulator
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				MaxtrackerApi api = new MaxtrackerApi();
				string id = "cb532510-7c34-4264-988d-31640d006668";
				api.ToggleItemRoom(102, Guid.Parse(id)).GetAwaiter().GetResult();

				Console.WriteLine("Hello World!");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}

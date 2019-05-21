using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator
{
	public class MaxtrackerApi
	{
		public async Task ToggleItemRoom(int roomNumber, Guid itemId)
		{
			using(var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:43612/");
				string jsonBody = $"{{ \"ItemId\":\"{itemId}\", \"RoomNumber\": \"{roomNumber}\" }}";
				StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

				var response = await client.PutAsync("api/Items/ToggleItemRoom", content);

				Console.WriteLine(response.StatusCode);
			}
		}
	}
}

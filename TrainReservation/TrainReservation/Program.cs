namespace TrainReservation
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void Main(string[] args)
        {
            InitAsync().Wait();
            Console.ReadLine();
        }

        private static async Task InitAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                await GetBookingId(client);
                await GetExpress_2000_info(client);
                await GetLocal_1000_info(client);
                await ReserveSeat(client);
            }
        }

        private static async Task ReserveSeat(HttpClient client)
        {
            var request = new ReserveRequest()
            {
                booking_reference = "75bcd15",
                train_id = "express_2000",
                seats = new List<string>(){
                    "1A", "2B"
                }
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("reserve", request);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsAsync<object>();
            }
        }

        private static async Task<Train> GetLocal_1000_info(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("data_for_train/local_1000");
            var train = new Train();
            train.Seats = new List<Seat>();

            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsAsync<object>().Result;

                Dictionary<string, JObject> seats = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(res.ToString());

                train.Name = "Local_1000";

                foreach (var seat in seats)
                {
                    Dictionary<string, JObject> data = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(seat.Value.ToString());
                    foreach (var item in data)
                    {
                        train.Seats.Add(JsonConvert.DeserializeObject<Seat>(item.Value.ToString()));
                    }
                }
            }
            return train;
        }

        /// <summary>
        /// Gets the express_2000_info.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        private static async Task<Train> GetExpress_2000_info(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("data_for_train/express_2000");
            var train = new Train();
            train.Seats = new List<Seat>();

            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsAsync<object>().Result;

                Dictionary<string, JObject> seats = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(res.ToString());

                train.Name = "express_2000";

                foreach (var seat in seats)
                {
                    Dictionary<string, JObject> data = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(seat.Value.ToString());
                    foreach (var item in data)
                    {
                        train.Seats.Add(JsonConvert.DeserializeObject<Seat>(item.Value.ToString()));
                    }
                }
            }
            return train;
        }

        private static async Task GetBookingId(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("booking_reference");

            if (response.IsSuccessStatusCode)
            {
                var booking_id = await response.Content.ReadAsAsync<string>();
            }
        }
    }
}
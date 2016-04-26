namespace TrainReservation
{
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
        }

        private static async Task InitAsync()
        {
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri("http://localhost:9000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("booking_reference");

                if (response.IsSuccessStatusCode)
                {
                    //var kk = await response.Content.ReadAsAsync()
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
            }
        }
    }
}
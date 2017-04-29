using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Consume_wepApi_consule
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task<List<Product>> RunAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7899");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Product> products = null;
            HttpResponseMessage response = await client.GetAsync("api/products");
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<Product>>();
            }
            foreach (var item in products)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Price);
            }
            
            Console.ReadKey();
            return products;
        }
    }
}

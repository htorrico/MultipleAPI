using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {

            await GetDocuments();
            await GetToDoItem();            
            Console.Read();
        }

        private static async Task GetToDoItem()
        {
            List<TodoItem> items = new List<TodoItem>();
            Console.WriteLine("GetToDoItem");
            HttpClient client = new HttpClient();

            var urlBase = "http://192.168.1.10/todoapi/api/todoitems/";

            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "Get");

            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                
                var result = await response.Content.ReadAsStringAsync();
                items=  JsonConvert.DeserializeObject<List<TodoItem>>(result);

                foreach (var item in items)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Notes);
                    Console.WriteLine(item.Done);

                }

                //Console.WriteLine(result);
            }
        }

        private static async Task GetDocuments()
        {
            Console.WriteLine("GetDocuments");
            //Thread.Sleep(5000);
            HttpClient client = new HttpClient();

            var urlBase = "https://enviodocumentos.wicpr.net/WICAPI2b/api/PoliceProcedure/";

            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "Get");

            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
        }


    }
}

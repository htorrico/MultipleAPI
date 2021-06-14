using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TodoItemController : Controller
    {
        // GET: TodoItem
        public async Task<ActionResult> Index()
        {

            var model = await GetToDoItem();

            return View(model);
        }

        private async Task<List<TodoItem>> GetToDoItem()
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
                items = JsonConvert.DeserializeObject<List<TodoItem>>(result);
                //Console.WriteLine(result);
            }

            return items;
        }


    }
}
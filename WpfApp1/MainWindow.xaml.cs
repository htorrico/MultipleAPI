using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  MainWindow()
        {
            InitializeComponent();
            
            
        }
        private  async Task<List<TodoItem>> GetToDoItem()
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            lvTodoItems.ItemsSource = await GetToDoItem(); ;
        }
    }
}

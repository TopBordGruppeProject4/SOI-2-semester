using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace _2.Iteration.Model.Persistency
{
    class PersistencyService
    {
        private const string ServerUrl = "http://localhost:4569";

        #region Customer

        public static async Task<List<Customer>> LoadCustomersFromJsonAsync()
        {
            var handler = new HttpClientHandler() {UseDefaultCredentials = true};
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var response = client.GetAsync("api/Customers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var customerList = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                        return customerList.ToList();

                    }
                    return null;

                }

                catch (Exception)
                {

                    throw;
                }


            }


        }

        public static async void SaveCustomersAsJsonAsync(Customer customers)
        {
            var handler = new HttpClientHandler() {UseDefaultCredentials = true};
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/Customers", customers);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteCustomersAsync(Customer customers)
        {
            var handler = new HttpClientHandler() {UseDefaultCredentials = true};

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/Customers/" + customers.Id);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        #endregion

        #region Order

        public static async Task<List<Order>> LoadOrdersFromJsonAsync()
        {
            var handler = new HttpClientHandler() {UseDefaultCredentials = true};
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var response = client.GetAsync("api/Orders").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var orderList = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
                        return orderList.ToList();

                    }
                    return null;

                }

                catch (Exception)
                {

                    throw;
                }


            }


        }

        public static async void SaveOrdersAsJsonAsync(Order orders)
        {
            var handler = new HttpClientHandler() {UseDefaultCredentials = true};
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/Orders", orders);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteOrdersAsync(Order orders)
        {
            var handler = new HttpClientHandler() {UseDefaultCredentials = true};

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/Orders/" + orders.Id);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        #endregion

        
    }
}

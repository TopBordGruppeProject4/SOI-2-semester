using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace _1.Iteration.Model.Persistency
{
    class PersistencyService
    {
        private const string ServerUrl = "http://localhost:4569";

        public static async Task<List<Worker>> LoadWorkersFromJsonAsync()
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var response = client.GetAsync("api/Workers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var workerList = response.Content.ReadAsAsync<IEnumerable<Worker>>().Result;
                        return workerList.ToList();

                    }
                    return null;

                }

                catch (Exception)
                {

                    throw;
                }


            }


        }

        public static async void SaveWorkersAsJsonAsync(Worker workers)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/Workers", workers);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteWorkersAsync(Worker workers)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/Workers/" + workers.Id);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        } 
    }
}

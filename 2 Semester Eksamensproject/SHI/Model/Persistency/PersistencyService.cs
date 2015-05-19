using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace SHI.Model.Persistency
{
    class PersistencyService
    {
        private const string ServerUrl = "http://localhost:2941";

        #region Customer

        public static async Task<List<Customer>> LoadCustomersFromJsonAsync()
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
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
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
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
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };

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

        #region SavedOrder

        public static async Task<List<SavedOrder>> LoadSavedOrdersFromJsonAsync()
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var response = client.GetAsync("api/SavedOrders").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var orderList = response.Content.ReadAsAsync<IEnumerable<SavedOrder>>().Result;
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

        public static async void SaveSavedOrdersAsJsonAsync(SavedOrder savedOrders)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/SavedOrders", savedOrders);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteSavedOrdersAsync(SavedOrder savedOrders)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/SavedOrders/" + savedOrders.Id);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        #endregion

        #region Worker

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

        public static async void SaveWorkersAsJsonAsync(Worker worker)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/Workers", worker);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteWorkersAsync(Worker worker)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/Workers/" + worker.Id);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        #endregion

        #region Product

        public static async Task<List<Product>> LoadProductsFromJsonAsync()
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var response = client.GetAsync("api/Products").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var productList = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                        return productList.ToList();

                    }
                    return null;

                }

                catch (Exception)
                {

                    throw;
                }


            }


        }

        public static async void SaveProductsAsJsonAsync(Product product)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/Products", product);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteProductsAsync(Product product)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/Products/" + product.Id);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        #endregion

        #region RawMaterial

        public static async Task<List<RawMaterial>> LoadRawMaterialsFromJsonAsync()
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var response = client.GetAsync("api/RawMaterials").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var rawMaterialList = response.Content.ReadAsAsync<IEnumerable<RawMaterial>>().Result;
                        return rawMaterialList.ToList();

                    }
                    return null;

                }

                catch (Exception)
                {

                    throw;
                }


            }


        }

        public static async void SaveRawMaterialsAsJsonAsync(RawMaterial rawMaterial)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.PostAsJsonAsync("api/RawMaterials", rawMaterial);
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteRawMaterialsAsync(RawMaterial rawMaterial)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = true };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/RawMaterials/" + rawMaterial.Id);
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

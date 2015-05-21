using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHI.Model.Persistency;

namespace SHI.Model
{
    class ProductCatalogSingleton
    {
        private static ProductCatalogSingleton _instance = new ProductCatalogSingleton();

        public static ProductCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new ProductCatalogSingleton()); }
        }

        public ObservableCollection<Product> Products { get; set; }

        private ProductCatalogSingleton()
        {
            Products = new ObservableCollection<Product>();
        }

        public async void LoadProductsAsync()
        {
            var products = await PersistencyService.LoadProductsFromJsonAsync();
            if (products != null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }

        public bool CheckProduct(string name)
        {
            var check = true;
            foreach (var product in Products)
            {
                if (product.Name == name)
                {
                    check = false;
                }
            }
            return check;
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
            PersistencyService.SaveProductsAsJsonAsync(product);
        }

        public void AddProduct(int amount, string description, int id, string name, double price)
        {
            var product = new Product(amount, description, id, name, price);
            Products.Add(product);
            PersistencyService.SaveProductsAsJsonAsync(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
            PersistencyService.DeleteProductsAsync(product);
        }
    }
}

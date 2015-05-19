using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHI.Model.Persistency;

namespace SHI.Model
{
    class CustomerCatalogSingleton
    {
        private static CustomerCatalogSingleton _instance = new CustomerCatalogSingleton();

        public static CustomerCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new CustomerCatalogSingleton()); }
        }

        public ObservableCollection<Customer> Customers { get; set; }

        private CustomerCatalogSingleton()
        {
            Customers = new ObservableCollection<Customer>();
        }

        public async void LoadCustomersAsync()
        {
            var customers = await PersistencyService.LoadCustomersFromJsonAsync();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            PersistencyService.SaveCustomersAsJsonAsync(customer);
        }

        public void AddCustomer(string address, int id, string name, string tlf, string email)
        {
            Customer customer = new Customer(address, id, name, tlf, email);
            Customers.Add(customer);
            PersistencyService.SaveCustomersAsJsonAsync(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
            PersistencyService.DeleteCustomersAsync(customer);
        }
    }
}

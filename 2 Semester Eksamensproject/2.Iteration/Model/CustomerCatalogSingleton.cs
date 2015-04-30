using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2.Iteration.Model.Persistency;

namespace _2.Iteration.Model
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
            var customers1 = await PersistencyService.LoadCustomersFromJsonAsync();
            if (customers1 != null)
            {
                foreach (var customer in customers1)
                {
                    Customers.Add(customer);
                }
            }
        }

        public void AddCustomer(Customer customerToAdd)
        {
            Customers.Add(customerToAdd);
            PersistencyService.SaveCustomersAsJsonAsync(customerToAdd);
        }

        public void AddCustomer(string address, int id, string name, string tlf, string email)
        {
            Customer customer = new Customer(address, id, name, tlf, email);
            Customers.Add(customer);
            PersistencyService.SaveCustomersAsJsonAsync(customer);
        }

        public void RemoveCustomer(Customer customerToRemove)
        {
            Customers.Remove(customerToRemove);
            PersistencyService.DeleteCustomersAsync(customerToRemove);
        }

    }
}

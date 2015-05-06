using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2.Iteration.Model;

namespace _2.Iteration.ViewModel
{
    class MainViewModel
    {
        public OrderCatalogSingleton OrderCatalogSingleton { get; set; }

        public CustomerCatalogSingleton CustomerCatalogSingleton { get; set; }

        public MainViewModel()
        {
            OrderCatalogSingleton = OrderCatalogSingleton.Instance;
            OrderCatalogSingleton.Orders.Clear();
            OrderCatalogSingleton.LoadOrdersAsync();

            CustomerCatalogSingleton = CustomerCatalogSingleton.Instance;
            CustomerCatalogSingleton.Customers.Clear();
            CustomerCatalogSingleton.LoadCustomersAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}

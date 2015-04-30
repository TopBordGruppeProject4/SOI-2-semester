using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Iteration.Model
{
    class OrderCatalogSingleton
    {
        private static OrderCatalogSingleton _instance = new OrderCatalogSingleton();

        public static OrderCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new OrderCatalogSingleton()); }
        }

        public ObservableCollection<Order> Orders { get; set; }

        private OrderCatalogSingleton()
        {
            Orders = new ObservableCollection<Order>();
        }
    }
}

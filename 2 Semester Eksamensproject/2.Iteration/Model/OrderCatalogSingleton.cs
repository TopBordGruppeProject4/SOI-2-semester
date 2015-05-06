using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2.Iteration.Model.Persistency;

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

        public async void LoadOrdersAsync()
        {
            var orders1 = await PersistencyService.LoadOrdersFromJsonAsync();
            if (orders1 != null)
            {
                foreach (var order in orders1)
                {
                    Orders.Add(order);
                }
            }
        }

        public void AddOrder(Order orderToAdd)
        {
            Orders.Add(orderToAdd);
            PersistencyService.SaveOrdersAsJsonAsync(orderToAdd);
        }

        public void AddOrder(DateTime creationDate, DateTime deadline, string description, int id, double price, int workerId, int customerId)
        {
            Order order = new Order(creationDate, deadline, description, id, price, workerId, customerId);
            Orders.Add(order);
            PersistencyService.SaveOrdersAsJsonAsync(order);
        }

        public void RemoveOrder(Order orderToRemove)
        {
            Orders.Remove(orderToRemove);
            PersistencyService.DeleteOrdersAsync(orderToRemove);
        }
    }
}

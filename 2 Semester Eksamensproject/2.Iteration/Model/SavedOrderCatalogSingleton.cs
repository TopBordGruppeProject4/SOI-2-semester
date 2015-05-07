using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2.Iteration.Model.Persistency;

namespace _2.Iteration.Model
{
    class SavedOrderCatalogSingleton
    {
        private static SavedOrderCatalogSingleton _instance = new SavedOrderCatalogSingleton();

        public static SavedOrderCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new SavedOrderCatalogSingleton()); }
        }

        public ObservableCollection<SavedOrder> Orders { get; set; }

        private SavedOrderCatalogSingleton()
        {
            Orders = new ObservableCollection<SavedOrder>();
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

        public void AddOrder(SavedOrder orderToAdd)
        {
            Orders.Add(orderToAdd);
            PersistencyService.SaveOrdersAsJsonAsync(orderToAdd);
        }

        public void AddOrder(DateTime creationDate, DateTime deadline, string description, int id, double price, int workerId, int customerId)
        {
            SavedOrder order = new SavedOrder(creationDate, deadline, description, id, price, workerId, customerId);
            Orders.Add(order);
            PersistencyService.SaveOrdersAsJsonAsync(order);
        }

        public void RemoveOrder(SavedOrder orderToRemove)
        {
            Orders.Remove(orderToRemove);
            PersistencyService.DeleteOrdersAsync(orderToRemove);
        }
    }
}

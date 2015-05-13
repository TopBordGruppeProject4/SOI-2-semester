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

        public ObservableCollection<SavedOrder> SavedOrders { get; set; }

        private SavedOrderCatalogSingleton()
        {
            SavedOrders = new ObservableCollection<SavedOrder>();
        }

        public async void LoadSavedOrdersAsync()
        {
            var savedOrders1 = await PersistencyService.LoadOrdersFromJsonAsync();
            if (savedOrders1 != null)
            {
                foreach (var savedOrder in savedOrders1)
                {
                    SavedOrders.Add(savedOrder);
                }
            }
        }

        public void AddSavedOrder(SavedOrder savedOrderToAdd)
        {
            SavedOrders.Add(savedOrderToAdd);
            PersistencyService.SaveOrdersAsJsonAsync(savedOrderToAdd);
        }

        public void AddSavedOrder(string creationdate, string deadline, string description, int id, int price,
            int workerId, int customerId)
        {
            SavedOrder savedOrder = new SavedOrder(creationdate, deadline, description, id, price, workerId, customerId);
            SavedOrders.Add(savedOrder);
            PersistencyService.SaveOrdersAsJsonAsync(savedOrder);
        }

        public void RemoveSavedOrder(SavedOrder savedOrderToRemove)
        {
            SavedOrders.Remove(savedOrderToRemove);
            PersistencyService.DeleteOrdersAsync(savedOrderToRemove);
        }
    }
}

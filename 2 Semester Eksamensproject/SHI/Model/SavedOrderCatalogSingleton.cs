using System;
using System.Collections.ObjectModel;
using SHI.Model.Persistency;

namespace SHI.Model
{
    public class SavedOrderCatalogSingleton
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
            var savedOrders1 = await PersistencyService.LoadSavedOrdersFromJsonAsync();
            if (savedOrders1 != null)
            {
                foreach (var savedOrder in savedOrders1)
                {
                    SavedOrders.Add(savedOrder);
                }
            }
        }

        

        public void AddOrdersToList(ObservableCollection<SavedOrder> savedOrders, int id)
        {
            foreach (var savedOrder in SavedOrders)
            {
                if (savedOrder.WorkerId == id)
                {
                    savedOrders.Add(savedOrder);
                }
            }
        }

        public void AddOrdersToList(ObservableCollection<SavedOrder> savedOrders, int id1, int id2)
        {
            foreach (var savedOrder in SavedOrders)
            {
                if (savedOrder.WorkerId != id1 && savedOrder.WorkerId != id2)
                {
                    savedOrders.Add(savedOrder);
                }
            }
        }

        

        public void AddSavedOrder(SavedOrder savedOrderToAdd)
        {
            SavedOrders.Add(savedOrderToAdd);
            PersistencyService.SaveSavedOrdersAsJsonAsync(savedOrderToAdd);
        }

        public void AddSavedOrder(DateTime creationdate, DateTime deadline, string description, int id, int price,
            int workerId, int customerId)
        {
            SavedOrder savedOrder = new SavedOrder(creationdate, deadline, description, id, price, workerId, customerId);
            SavedOrders.Add(savedOrder);
            PersistencyService.SaveSavedOrdersAsJsonAsync(savedOrder);
        }

        public void RemoveSavedOrder(SavedOrder savedOrderToRemove)
        {
            SavedOrders.Remove(savedOrderToRemove);
            PersistencyService.DeleteSavedOrdersAsync(savedOrderToRemove);
        }
    }
}

﻿using System.Collections.ObjectModel;
using SHI.Model.Persistency;

namespace SHI.Model
{
    public class WorkerCatalogSingleton
    {
        private static WorkerCatalogSingleton _instance = new WorkerCatalogSingleton();

        public static WorkerCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new WorkerCatalogSingleton()); }
        }

        public ObservableCollection<Worker> Workers { get; set; }

        private WorkerCatalogSingleton()
        {
            Workers = new ObservableCollection<Worker>();
        }



        public bool CheckWorker(string username, string password)
        {
            foreach (var worker in Workers)
            {
                if (worker.Username == username && worker.Password == password)
                {
                    return true;

                }
            }

            return false;
        }

        public bool CheckWorker(string username)
        {
            foreach (var worker in Workers)
            {
                if (worker.Username == username)
                {
                    return true;
                }
            }
            return false;
        }
        public Worker GetWorker(string username)
        {
            var tempWorker = new Worker("0", 0, "0", "0", false, "0", "0");
            for (int i = 0; i < Workers.Count; i++)
            {
                if (Workers[i].Username == username)
                {
                    tempWorker = Workers[i];
                }

            }
            return tempWorker;
        }

        public async void LoadWorkersAsync()
        {
            var workers1 = await PersistencyService.LoadWorkersFromJsonAsync();
            if (workers1 != null)
            {
                foreach (var worker in workers1)
                {
                    Workers.Add(worker);
                }
            }
        }

        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
            PersistencyService.SaveWorkersAsJsonAsync(worker);
        }

        public void AddWorker(bool admin, string password, string username, string address, int id, string name,
            string tlf)
        {
            Worker worker = new Worker(address, id, name, tlf, admin, username, password);
            Workers.Add(worker);
            PersistencyService.SaveWorkersAsJsonAsync(worker);
        }

        public void RemoveWorker(Worker worker)
        {
            Workers.Remove(worker);
            PersistencyService.DeleteWorkersAsync(worker);
        }
    }
}

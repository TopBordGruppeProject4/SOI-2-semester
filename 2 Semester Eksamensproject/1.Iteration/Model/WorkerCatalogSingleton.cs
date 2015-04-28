using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _1.Iteration.Model.Persistency;

namespace _1.Iteration.Model
{
    class WorkerCatalogSingleton
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
            var check = false;
            foreach (var worker in Workers)
            {
                if (worker.Username == username && worker.Password == password)
                {
                    check = true;
                    
                }
            }

            return check;
        }

        public Worker GetWorker(string username)
        {
            var tempWorker= new Worker(false, "0", "0", "0", 1, "0", "0");
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

        public void AddWorker(Worker workerToAdd)
        {
            Workers.Add(workerToAdd);
            PersistencyService.SaveWorkersAsJsonAsync(workerToAdd);
        }

        public void AddWorker(bool admin, string password, string username, string address, int id, string name,
            string tlf)
        {
            Worker worker = new Worker(admin, password, username, address, id, name, tlf);
            Workers.Add(worker);
            PersistencyService.SaveWorkersAsJsonAsync(worker);
        }

        public void RemoveWorker(Worker workerToRemove)
        {
            Workers.Remove(workerToRemove);
            PersistencyService.DeleteWorkersAsync(workerToRemove);
        }
    }
}

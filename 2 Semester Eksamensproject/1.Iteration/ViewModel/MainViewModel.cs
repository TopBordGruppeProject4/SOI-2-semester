using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.Iteration.Model;

namespace _1.Iteration.ViewModel
{
    class MainViewModel
    {
        public WorkerCatalogSingleton WorkerCatalogSingleton { get; set; }

        public static Worker CurrentWorker { get; set; }

        public MainViewModel()
        {
            
            WorkerCatalogSingleton = WorkerCatalogSingleton.Instance;
            WorkerCatalogSingleton.Workers.Clear();
            WorkerCatalogSingleton.LoadWorkersAsync();
        }
    }
}

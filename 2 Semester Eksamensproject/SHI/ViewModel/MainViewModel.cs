using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.FileProperties;

namespace SHI.ViewModel
{
    class MainViewModel
    {
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTlf { get; set; }
        public int ProductAmount { get; set; }
        public string ProductDescription { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int RawMaterialAmount { get; set; }
        public string RawMaterialDescription { get; set; }
        public string RawMaterialName { get; set; }
        public DateTimeOffset SavedOrderDeadlineDate { get; set; }
        public TimeSpan SavedORderDeadlineTime { get; set; }
        public string SavedOrderDescription { get; set; }
        public int SavedOrderPrice { get; set; }
        public string WorkerAddress { get; set; }
        public bool WorkerAdmin { get; set; }
        public string WorkerName { get; set; }
        public string WorkerTlf { get; set; }
        public string WorkerPassword { get; set; }
        public string WorkerUsername { get; set; }

    }
}

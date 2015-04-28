using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using _1.Iteration.Annotations;
using _1.Iteration.Model;

namespace _1.Iteration.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        private static Worker _selectedWorker;

        public  static Worker SelectedWorker
        {
            get { return _selectedWorker; }
            set { _selectedWorker = value;  }
        }

        public WorkerCatalogSingleton WorkerCatalogSingleton { get; set; }

        public static Worker CurrentWorker { get; set; }

        public void LoginWorker(string username, string password)
        {
            if (WorkerCatalogSingleton.CheckWorker(username, password))
            {
                CurrentWorker = WorkerCatalogSingleton.GetWorker(username);
                

            }

            
        }

        public MainViewModel()
        {
            
            WorkerCatalogSingleton = WorkerCatalogSingleton.Instance;
            WorkerCatalogSingleton.Workers.Clear();
            WorkerCatalogSingleton.LoadWorkersAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _1.Iteration.Annotations;
using _1.Iteration.Model;

namespace _1.Iteration.ViewModel
{
    class Core: INotifyPropertyChanged
    {
        private static Core _instance = new Core();
        private Worker _coreSelectedWorker;

        public static Core Instance 
        {
            get { return _instance ?? (_instance = new Core()); }
        }

        public Worker CoreSelectedWorker
        {
            get { return _coreSelectedWorker; }
            set { _coreSelectedWorker = value; OnPropertyChanged(); }
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using _1.Iteration.Model;
using _1.Iteration.View;
using _1.Iteration.ViewModel;

namespace _1.Iteration
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public Worker SelectedWorker
        //{
        //    get { return MainViewModel.SelectedWorker; }
        //    set { MainViewModel.SelectedWorker = value; }
        //}

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = (MainViewModel) this.DataContext;
            viewmodel.LoginWorker(BoxUser.Text, BoxPass.Text);
            if (viewmodel.WorkerCatalogSingleton.CheckWorker(BoxUser.Text, BoxPass.Text))
            {
                this.Frame.Navigate(typeof (Menu));
            }
            
        }

        
    }
}

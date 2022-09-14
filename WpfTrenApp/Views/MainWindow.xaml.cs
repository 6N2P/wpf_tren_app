using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTrenApp.ViewModels;
using WpfTrenApp.Views;


using WpfTrenApp.Data;
using System.Data.Entity;
using System.ComponentModel;
using System.Security.Policy;

namespace WpfTrenApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();            

            this.DataContext = new MainViewModel();

            this.Closing += MainWindow_Closing;

        }

        
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            //     db.Dispose();
            
        }

       

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Min_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState=WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

      

        
    }
}

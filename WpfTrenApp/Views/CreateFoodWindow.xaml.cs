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
using System.Windows.Shapes;
using WpfTrenApp.ViewModels;

namespace WpfTrenApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateFoodWindow.xaml
    /// </summary>
    public partial class CreateFoodWindow : Window
    {
        public CreateFoodWindow()
        {
            InitializeComponent();
            this.DataContext=new CreateFoodViewModel();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

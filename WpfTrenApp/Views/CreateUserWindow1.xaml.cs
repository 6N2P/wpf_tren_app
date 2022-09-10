
using System.Windows;
using WpfTrenApp.ViewModels;
using System.Windows.Input;

namespace WpfTrenApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateUserWindow1.xaml
    /// </summary>
    public partial class CreateUserWindow1 : Window
    {
        public CreateUserWindow1()
        {
            InitializeComponent();
            this.DataContext = new CreateUserViewModel();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}

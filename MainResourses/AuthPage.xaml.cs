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

namespace AutoService_WS
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void buttonEnterAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (password.Text == "0000")
            {
                Frames.MainFrame.mainFrame.Navigate(new AdminResorses.AdminMenuPage());
            }
            else
                MessageBox.Show("Пароль неверный");
        }

        private void buttonEnterClient_Click(object sender, RoutedEventArgs e)
        {
            Frames.MainFrame.mainFrame.Navigate(new ManufacturerListPageClient());
        }
    }
}

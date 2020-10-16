
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoService_WS.AdminResorses
{
	/// <summary>
	/// Interaction logic for AdminMenuPage.xaml
	/// </summary>
	public partial class AdminMenuPage : Page
	{
		public AdminMenuPage()
		{
			InitializeComponent();
		}
		void ButtonAddManuf_Click(object sender, RoutedEventArgs e)
		{
			Frames.MainFrame.mainFrame.Navigate(new ClientAddManufPage());
		}
		void ButtonLastestClientService_Click(object sender, RoutedEventArgs e)
		{
			Frames.MainFrame.mainFrame.Navigate(new LatestClientServicePage());
		}
		void ButtonManufList_Click(object sender, RoutedEventArgs e)
		{
			Frames.MainFrame.mainFrame.Navigate(new ManufacturerListPage());
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.MainFrame.mainFrame.GoBack();
		}
	}
}
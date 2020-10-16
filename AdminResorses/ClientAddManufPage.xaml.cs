
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using AutoService_WS.DbUsingContext;

namespace AutoService_WS
{
	/// <summary>
	/// Interaction logic for ClientAddManufPage.xaml
	/// </summary>
	public partial class ClientAddManufPage : Page
	{
		public ClientAddManufPage()
		{
			InitializeComponent();
			
			foreach (var element in UsingContext.db.Client) {
				ComboBoxItem item = new ComboBoxItem();
				item.Content = element.FirstName + " " + element.LastName + " " + element.Patronymic;
				item.Tag = element.ID;
				comboClients.Items.Add(item);
			}
			
			foreach (var element in UsingContext.db.Service) {
				ComboBoxItem item = new ComboBoxItem();
				item.Content = element.Title + " " + element.DurationInSeconds / 60 + " минут";
				item.Tag = element.ID;
				comboManuf.Items.Add(item);
			}
		}
		void acceptButton_Click(object sender, RoutedEventArgs e)
		{
			DateTime date = datePicker.SelectedDate.Value;
			ClientService newClientService = new ClientService{
				ClientID = Convert.ToInt32(((ComboBoxItem)comboClients.SelectedItem).Tag),
				ServiceID = Convert.ToInt32(((ComboBoxItem)comboManuf.SelectedItem).Tag),
				StartTime = date
			};
			UsingContext.db.ClientService.Add(newClientService);
			UsingContext.db.SaveChanges();
			MessageBox.Show("Клиент успешно записан на услугу!","Успех",MessageBoxButton.OK,MessageBoxImage.Information);
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.MainFrame.mainFrame.GoBack();
		}
	}
}

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
	/// Interaction logic for LatestClientServicePage.xaml
	/// </summary>
	public partial class LatestClientServicePage : Page
	{
		public LatestClientServicePage()
		{
			InitializeComponent();
			
			foreach (ClientService item in UsingContext.db.ClientService)
        	{
                StackPanel panel = new StackPanel();
				Border border = new Border();
				border.BorderThickness = new Thickness(8);
				border.BorderBrush = new SolidColorBrush(Colors.Gray);

                TextBlock title = new TextBlock();
                title.Text = item.Service.Title;
				title.TextAlignment = TextAlignment.Center;
				title.VerticalAlignment = VerticalAlignment.Center;
				
                TextBlock cost = new TextBlock();
                cost.TextAlignment = TextAlignment.Center;
				cost.Text = item.Client.FirstName + " " + item.Client.LastName + " " + item.Client.Patronymic;
				cost.VerticalAlignment = VerticalAlignment.Center;
				
				TextBlock email = new TextBlock();
                email.TextAlignment = TextAlignment.Center;
				email.Text = item.Client.Email;
				email.VerticalAlignment = VerticalAlignment.Center;
				
				TextBlock phone = new TextBlock();
                phone.TextAlignment = TextAlignment.Center;
				phone.Text = item.Client.Phone;
				phone.VerticalAlignment = VerticalAlignment.Center;
				
				TextBlock date = new TextBlock();
                date.TextAlignment = TextAlignment.Center;
                date.Text = item.StartTime.ToString();
				date.VerticalAlignment = VerticalAlignment.Center;
				
                panel.Height = 110;
                panel.HorizontalAlignment = HorizontalAlignment.Center;
                panel.VerticalAlignment = VerticalAlignment.Center;

                panel.Children.Add(title);
                panel.Children.Add(cost);
				panel.Children.Add(email);
				panel.Children.Add(phone);
				panel.Children.Add(date);
				
				border.Child = panel;
                stackPanel.Children.Add(border);
            }
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.MainFrame.mainFrame.GoBack();
		}
	}
}
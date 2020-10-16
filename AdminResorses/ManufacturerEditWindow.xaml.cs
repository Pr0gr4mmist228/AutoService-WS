
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AutoService_WS
{
	/// <summary>
	/// Interaction logic for ManufacturerEditWindow.xaml
	/// </summary>
	public partial class ManufacturerEditWindow : Window
	{
		Service service;
		public ManufacturerEditWindow(Service service)
		{
			InitializeComponent();
			this.service = service;
			
			BitmapImage bitImage = new BitmapImage();
			bitImage.BeginInit();
			bitImage.UriSource = new Uri(@"C:\Users\artem\Desktop\WS\services_a_import\" + service.MainImagePath);
			bitImage.EndInit();
			
			image.Source = bitImage;
			
			boxCost.Text = service.Cost.ToString();
			boxName.Text = service.Title;
			boxDuration.Text = (service.DurationInSeconds/60).ToString();
			boxDescrip.Text = service.Description;
			boxDiscount.Text = service.Discount.ToString();
			boxFilePath.Text = service.MainImagePath;
		}
		void ButtonAccept_Click(object sender, RoutedEventArgs e)
		{
			try{
				service.Title = boxName.Text;
				service.Cost = decimal.Parse(boxCost.Text);
				service.DurationInSeconds = int.Parse(boxDuration.Text)*60;
				service.Description = boxDescrip.Text;
				service.Discount = double.Parse(boxDiscount.Text);
				service.MainImagePath = boxFilePath.Text;
				DbUsingContext.UsingContext.db.SaveChanges();
				MessageBox.Show("Услуга успешно изменена!","Успех",MessageBoxButton.OK,MessageBoxImage.Information);
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message);
			}
			
		}
		void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
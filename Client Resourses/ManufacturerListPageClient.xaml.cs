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
using AutoService_WS.DbUsingContext;

namespace AutoService_WS
{
    /// <summary>
    /// Логика взаимодействия для ManufacturerListPageClient.xaml
    /// </summary>
    public partial class ManufacturerListPageClient : Page
    {
        public ManufacturerListPageClient()
        {
            InitializeComponent();
         	 UpdateList();
        }
        
        void UpdateList(){
        	stackPanel.Children.RemoveRange(0,stackPanel.Children.Count);
			List<Service> serviceManufacture = GetCheckedRadios();
        	foreach (Service item in serviceManufacture)
        	{
                StackPanel panel = new StackPanel();
				Border border = new Border();
				border.BorderThickness = new Thickness(8);
				border.BorderBrush = new SolidColorBrush(Colors.Gray);

                Image image1 = new Image();
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                Uri imageSource = new Uri(@"C:\Users\artem\Desktop\WS\services_a_import\" + item.MainImagePath.ToString());
                image.UriSource = imageSource;
                image.EndInit();

                image1.Source = image;
                image1.Height = 50;
                image1.Width = 50;

                TextBlock title = new TextBlock();
                title.Text = item.Title;
				title.TextAlignment = TextAlignment.Center;
				title.VerticalAlignment = VerticalAlignment.Center;
                TextBlock cost = new TextBlock();
                cost.TextAlignment = TextAlignment.Center;
                cost.Text = item.Cost + " рублей " + item.DurationInSeconds/60 + " минут";
				cost.VerticalAlignment = VerticalAlignment.Center;
                panel.Height = 110;
                panel.HorizontalAlignment = HorizontalAlignment.Center;
                panel.VerticalAlignment = VerticalAlignment.Center;
                panel.Children.Add(image1);
                panel.Children.Add(title);
                panel.Children.Add(cost);
				border.Child = panel;
                stackPanel.Children.Add(border);
            }
        				textblockCountItems.Text = "Количество записей: "+serviceManufacture.Count;
        }

        public List<Service> GetCheckedRadios(){
        	double firstValue = GetDiscountFirst();
			double secondValue = GetDiscountSecond();
			
			if (radioOrderByPrice.IsChecked == true) {
        		return UsingContext.db.Service.OrderBy(x => x.Cost).Where(x => x.Discount >= firstValue && x.Discount <= secondValue).ToList();
        	}
        	else if(radioOrderByPriceDesc.IsChecked == true){
        	  return UsingContext.db.Service.OrderByDescending(x => x.Cost).Where(x => x.Discount >= firstValue && x.Discount <= secondValue).ToList();
        	}
        	else if(defaultSort.IsChecked == true){
        		return UsingContext.db.Service.Where(x => x.Discount >= firstValue && x.Discount <= secondValue).ToList();
        	}
			return null;
        }
        
        public double GetDiscountFirst(){
        	if(comboDiscounts.SelectedIndex == 0){
				return 0;
        	}
        	else if(comboDiscounts.SelectedIndex == 1){
        		return 0.05;
        	}
        	else if(comboDiscounts.SelectedIndex == 2){
        		return 0.15;
        	}
        	else if(comboDiscounts.SelectedIndex == 3){
        		return 0.3;
        	}
        	else if(comboDiscounts.SelectedIndex == 4){
        		return 0.7;
        	}
			return 0;
        }
        
        double GetDiscountSecond(){
        	if(comboDiscounts.SelectedIndex == 0){
				return 0.05;
        	}
        	else if(comboDiscounts.SelectedIndex == 1){
        		return 0.15;
        	}
        	else if(comboDiscounts.SelectedIndex == 2){
				return 0.3;
        	}
        	else if(comboDiscounts.SelectedIndex == 3){
				return 0.7;
        	}
        	else if(comboDiscounts.SelectedIndex == 4){
				return 1;
        	}
			return 1;
        }
        
		void RadioOrderByPrice_Checked(object sender, RoutedEventArgs e)
		{
			UpdateList();
		}
		void RadioOrderByPriceDesc_Checked(object sender, RoutedEventArgs e)
		{
			UpdateList();
		}
				
		void DefaultSort_Checked(object sender, RoutedEventArgs e)
		{
			UpdateList();
		}

		void ComboDiscounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateList();
		}
		void ButtonReset_Click(object sender, RoutedEventArgs e)
		{
			comboDiscounts.SelectedItem = null;
			defaultSort.IsChecked = true;
			radioOrderByPrice.IsChecked = false;
			radioOrderByPriceDesc.IsChecked = false;
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.MainFrame.mainFrame.GoBack();
		}
    }
}

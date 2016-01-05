using RestaurantManager.Models;
using RestaurantManager.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RestaurantManager.UniversalWindows
{
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            IMessageService messageService = new MessageDialogService();
            this.DataContext = new OrderViewModel(messageService, "Order has been Submitted");
            this.InitializeComponent();     
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

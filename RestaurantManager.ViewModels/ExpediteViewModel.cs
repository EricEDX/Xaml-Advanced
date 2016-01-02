using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            OrderItems = base.Repository.Orders;         
        }

        private void IdsRegister()
        {
            int id = 0;
            if (OrderItems != null)
            {
                foreach (Order orderItem in OrderItems)
                {
                    orderItem.Id = id++;
                }
            }
        }

        private ObservableCollection<Order> orderItems;

        public ObservableCollection<Order> OrderItems
        {
            get { return orderItems; }
            set
            {
                if (value != orderItems)
                {
                    orderItems = value;
                    IdsRegister();
                    base.OnPropertyChanged();
                }
            }
        }

        public DelegateCommand<int> DeleteOrderCommand { get; private set; }

        private void DeleteOrderExecute(int parameter)
        {
            Order orderToRemove = OrderItems[parameter];
            OrderItems.Remove(orderToRemove);
            IdsRegister();
        }

        public DelegateCommand<object> ClearAllOrderCommand { get; private set; }

        private void ClearAllOrderExecute(object parameter)
        {
            if (OrderItems != null)
            {
                OrderItems.Clear();
            }            
        }

        public ExpediteViewModel()
        {
            DeleteOrderCommand = new DelegateCommand<int>(DeleteOrderExecute);
            ClearAllOrderCommand = new DelegateCommand<object>(ClearAllOrderExecute);
        }
    }
}

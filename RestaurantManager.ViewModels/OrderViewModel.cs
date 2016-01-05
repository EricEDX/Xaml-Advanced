using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestaurantManager.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RestaurantManager.ViewModels;
using System;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        private List<MenuItem> menuItems;

        public List<MenuItem> MenuItems
        {
            get
            {
                return menuItems; 
            }
            set
            {
                if (value != menuItems)
                {
                    menuItems = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<MenuItem> currentlySelectedMenuItems;

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get
            {
                return currentlySelectedMenuItems;
            }
            set
            {
                if (value != currentlySelectedMenuItems)
                {
                    currentlySelectedMenuItems = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string specialRequests;

        public string SpecialRequests
        {
            get { return specialRequests; }
            set { specialRequests = value; base.OnPropertyChanged(); }
        }

        public string Message { get; set; }

        private readonly IMessageService _messageService;

        public DelegateCommand<int> AddToOrderCommand { get; private set; }

        private void AddToOrderExecute(int parameter)
        {
            this.CurrentlySelectedMenuItems.Add(this.MenuItems[parameter]);
            SubmitOrderCommand.RaiseCanExecuteChanged();
        }

        public DelegateCommand<string> SubmitOrderCommand { get; private set; }

        private void SubmitOrderExecute(string parameter)
        {            
            Order orderToSubmit = new Order { Complete = false, Expedite = false, SpecialRequests = parameter, Table = Repository.Tables[0], Items = CurrentlySelectedMenuItems.ToList() };
            base.Repository.Orders.Add(orderToSubmit);
            this.CurrentlySelectedMenuItems.Clear();
            this.SpecialRequests = "";
            SubmitOrderCommand.RaiseCanExecuteChanged();
            _messageService.ShowDialog(this.Message);
        }

        public bool AddToOrderButtonIsEnabled;

        private bool AddToOrderCanExecute(int parameter)
        {
            if (parameter > -1) { AddToOrderButtonIsEnabled = true; return true; }
            else { AddToOrderButtonIsEnabled = false; return false; }
        }

        public bool SubmitButtonIsEnabled;

        private bool SubmitOrderCanExecute(string parameter)
        {
            if (CurrentlySelectedMenuItems.Count > 0) { SubmitButtonIsEnabled = true; return true; }
            else { SubmitButtonIsEnabled = false; return false; }
        }

        public OrderViewModel(IMessageService messageService, string message)
        {
            _messageService = messageService;
            this.Message = message;
            AddToOrderCommand = new DelegateCommand<int>(AddToOrderExecute, AddToOrderCanExecute);
            SubmitOrderCommand = new DelegateCommand<string>(SubmitOrderExecute, SubmitOrderCanExecute);
        }
    }
}

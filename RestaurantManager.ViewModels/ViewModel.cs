using RestaurantManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
            { 
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        protected RestaurantContext Repository { get; private set; }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }

        public ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            IsLoading = true;
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            IsLoading = false;
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}

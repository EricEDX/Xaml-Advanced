using RestaurantManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.UniversalWindows
{
    public sealed class MessageDialogService : IMessageService
    {
        public async void ShowDialog(string message)
        {
            await new Windows.UI.Popups.MessageDialog(message).ShowAsync();
        }
    }
}

using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RestaurantManager.Extensions
{
    public class ClearTextBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }
  
        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            if (this.AssociatedObject is TextBox)
            {
                (this.AssociatedObject as TextBox).DoubleTapped += ClearTextBehavior_DoubleTapped;
            }
        }

        private void ClearTextBehavior_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            (sender as TextBox).Text = "";
        }

        public void Detach()
        {
            if (this.AssociatedObject != null && this.AssociatedObject is TextBox)
            {
                this.AssociatedObject = null;
                (this.AssociatedObject as TextBox).DoubleTapped -= ClearTextBehavior_DoubleTapped;
            }
        }
    }
}

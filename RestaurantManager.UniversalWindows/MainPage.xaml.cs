using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace RestaurantManager.UniversalWindows
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ExpeditePage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExpeditePage));
        }

        private void OrderPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrderPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {            
            Storyboard ButtonsAnimation = new Storyboard();

            Duration duration = new Duration(TimeSpan.FromSeconds(1d));
            double FirstFrom = 0 - (ActualWidth) / 2;
            double SecondFrom = (ActualWidth) / 2;

            DoubleAnimation firstButtonAnimation = new DoubleAnimation
            {
                Duration = duration,
                From = FirstFrom,
                To = 0
            };

            DoubleAnimation secondButtonAnimation = new DoubleAnimation
            {
                Duration = duration,
                From = SecondFrom,
                To = 0
            };

            CircleEase circleEase = new CircleEase();
            circleEase.EasingMode = EasingMode.EaseOut;

            firstButtonAnimation.EasingFunction = circleEase;
            secondButtonAnimation.EasingFunction = circleEase;

            ButtonsAnimation.Children.Add(firstButtonAnimation);
            Storyboard.SetTarget(firstButtonAnimation, GoToOrderButton.RenderTransform);
            Storyboard.SetTargetProperty(firstButtonAnimation, "X");

            ButtonsAnimation.Children.Add(secondButtonAnimation);
            Storyboard.SetTarget(secondButtonAnimation, SubmitOrderButton.RenderTransform);
            Storyboard.SetTargetProperty(secondButtonAnimation, "X");

            ButtonsAnimation.Begin();
        }
    }
}

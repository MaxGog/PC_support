﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Core;

namespace PC_support.Views
{
    public sealed partial class ConsolePage : Page
    {
        private int xbox = 0, ps = 0, nintendo = 0;
        private string final;

        private void HaveGame_Toggled(object sender, RoutedEventArgs e)
        {
            if (HaveGame.IsOn == true)
            {
                Steam.IsEnabled = true;
                EAGames.IsEnabled = true;
                Xbox.IsEnabled = true;
                PS.IsEnabled = true;
                Nintendo.IsEnabled = true;
            }
            else
            {
                Steam.IsEnabled = false;
                EAGames.IsEnabled = false;
                Xbox.IsEnabled = false;
                PS.IsEnabled = false;
                Nintendo.IsEnabled = false;
            }
        }

        public ConsolePage()
        {
            this.InitializeComponent();
            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            //SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            //{
            //    App.TryGoBack();
            //    //Frame.Navigate(typeof(MainPage));
            //    //Frame.GoBack();
            //};
        }

        private async void Finish_Click(object sender, RoutedEventArgs e)
        {
            xbox = 0;
            ps = 0;
            nintendo = 0;
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            if (GameBuy.IsOn == false)
            {
                xbox += 1;
                ps += 1;
            }
            if (HaveGame.IsOn == true)
            {
                if (Steam.IsChecked == true || EAGames.IsChecked == true || Xbox.IsChecked == true)
                    xbox += 1;
                if (Nintendo.IsChecked == true)
                    nintendo += 1;
                if (PS.IsChecked == true)
                    ps += 1;
            }
            if (MuchPlay.IsOn == true)
            {
                ps += 2;
                xbox += 1;
            }
            if (Graphics.IsOn == true)
            {
                ps += 1;
            }
            else
            {
                xbox += 1;
                nintendo += 1;
            }
            if (Mobile.IsOn == true)
            {
                nintendo += 1;
            }
            if (Friend.IsOn == true)
            {
                nintendo += 1;
                xbox += 1;
            }
            if (Media.IsOn == true)
            {
                xbox += 2;
            }

            if (xbox > ps && xbox > nintendo || xbox >= nintendo)
            {
                final = "Xbox One S / Xbox One fat";
                Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualConsoles/XboxOne_fat.png"));
                if (Graphics.IsOn == true)
                {
                    final = "Xbox Series X";
                    Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualConsoles/XboxSeries_X.png"));
                    if (Mobile.IsOn == true)
                    {
                        final = "Xbox Series S";
                        Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualConsoles/XboxSeries_S.png"));
                        if (GameBuy.IsOn == false)
                        {
                            final = "Xbox One X";
                            Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualConsoles/XboxOne_X.png"));
                        }
                    }
                }
                    
            }
            if (nintendo >= xbox && nintendo >= ps)
            {
                final = "Nintendo Switch";
                Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualConsoles/NintendoSwitch.png"));
            }
            if (ps > xbox && ps >= nintendo || ps >= xbox)
            {
                final = "PlayStation 4";
                Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualConsoles/PS4.png"));
                if (Graphics.IsOn == true)
                {
                    final = "PlayStation 5";
                    Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualConsoles/PS5.png"));
                }  
            }
            ContentDialog Result = new ContentDialog()
            {
                Title = resourceLoader.GetString("Result"),
                Content = final,
                PrimaryButtonText = resourceLoader.GetString("Okay"),
            };
            ContentDialogResult result = await Result.ShowAsync();
        }
    }
}

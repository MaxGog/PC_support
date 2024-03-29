﻿
using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
//using Windows.Services.Store;

namespace PC_support.Views
{
    public sealed partial class PCLaptopPage : Page
    {
        public string type = "PC or Laptop", model = "Surface", СPU_model = "Intel", image = @"Surface_model.png", ROM_str, OS_str;
        public string typeCPU = "x64", VideoCard_model = "Invidia", typeRAM = "DDR4";
        private int OS = 0, RAM = 0, ROM = 0, kernels = 0, VideoCard = 0;
        private double CPU = 1.5;
        public PCLaptopPage()
        {
            this.InitializeComponent();

            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            //SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            //{
            //    App.TryGoBack();
            //    //Frame.Navigate(typeof(MainPage));
            //    //Frame.GoBack();
            //};
            //StoreServicesCustomEventLogger logger = StoreServicesCustomEventLogger.GetDefault();
            //logger.Log("myCustomEvent");
        }
        private void Pro_ver_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PCLaptopPage_pro));
        }
        private void pro_Toggled(object sender, RoutedEventArgs e)
        {
            if (pro.IsOn == true)
            {
                pro_adobe.IsEnabled = true;
                pro_vr.IsEnabled = true;
            }
            else
            {
                pro_adobe.IsEnabled = false;
                pro_adobe.IsOn = false;
                pro_vr.IsEnabled = false;
                pro_vr.IsOn = false;
            }
        }
        private void Sync_Toggled(object sender, RoutedEventArgs e)
        {
            if (Sync.IsOn == true)
                Phone_sync.IsEnabled = true;
            else
                Phone_sync.IsEnabled = false;
        }
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            OS = 0; 
            RAM = 0; 
            ROM = 0; 
            kernels = 0; 
            VideoCard = 0;
            if (Mobile.IsOn == true)
                type = "Laptop or Tablet";
            else
                type = "PC or Laptop";
            if (pro.IsOn == true)
            {
                RAM += 4; 
                ROM += 100; 
                kernels += 2; 
                OS = 12;
                СPU_model = "Intel Core i5";
                if (pro_adobe.IsOn == true)
                {
                    VideoCard += 2; 
                    kernels += 1;
                    //VideoCard_model = "Invidia GeForce GTX";
                }
                if (pro_vr.IsOn == true)
                {
                    VideoCard += 2; 
                    kernels += 2; 
                    CPU += 1.5; 
                    RAM += 2;
                    //VideoCard_model = "Invidia GeForce GTX";
                }
                if (Develop_purpose.IsChecked == true)
                {
                    OS = 124;
                    RAM += 2; 
                    kernels += 2;
                    typeCPU = "x64";
                }
            }
            if (bigROM.IsOn == true)
            {
                ROM += 1024;
            }
            if (Ecosystem.IsOn == true)
            {
                if (Work_purpose.IsChecked == true)
                {
                    if (Develop_purpose.IsChecked == true)
                        OS = 1;
                    else
                        OS = 12;
                }

                else if (Work_purpose.IsChecked == true && pro_adobe.IsOn == true)
                    OS = 2;
                else
                    OS = 123;
            }
            if (OS == 1 || OS == 12 && Home_purpose.IsEnabled == true && pro_vr.IsOn == true)
            {
                OS_str = "Windows"; 
                OS = 1;
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Windows.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/Surface.png"));
            }
            else if (OS == 12 && pro_adobe.IsOn == true && Work_purpose.IsEnabled == true)
            {
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Apple.png"));
                OS = 2;
                if (type == "Laptop" || type == "Laptop or Tablet")
                {
                    model = "MacBook Pro";
                    type = "Laptop";
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/MacBook_Air.png"));
                }
                else if (Home_purpose.IsEnabled == true && Mobile.IsOn == false && type == "PC or Laptop")
                {
                    model = "iMac";
                    type = "PC";
                    ROM = 8;
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/iMac.png"));
                }
                else
                {
                    model = "MacBook Air";
                    type = "Laptop";
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets//VisualPictures/PC/MacBook_Air.png"));
                }
                OS_str = "MacOS";
                СPU_model = "Apple M1";
                typeCPU = "ARM";
            }
            else if (OS == 123 || OS == 134 && Home_purpose.IsEnabled == true && Work_purpose.IsEnabled == false && pro_adobe.IsOn == true)
            {
                OS = 3;
                OS_str = "Chrome OS"; 
                model = "ChromeBook";
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/ChromeOS.png"));
            }
            else if (OS == 123 || OS == 134 || OS == 124 && Gaming_purpose.IsEnabled == false && pro_adobe.IsOn == false)
            {
                OS_str = "Linux";
                OS = 4;
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Linux.png"));
            }
            else
            {
                OS_str = "Windows";
                OS = 1;
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Windows.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/Surface.png"));
            }
            if (Assembly.IsOn == true)
            {
                if (OS == 1 && Mobile.IsOn == true)
                    model = "Surface";
                else if (OS == 1 && Mobile.IsOn == false)
                    model = "Lenovo";
            }
            if (Accuracy.IsChecked == false)
            {
                if (ROM <= 64)
                    ROM = 64;
                if (RAM <= 4)
                    RAM = 4;
                if (ROM >= 65 && ROM <= 128)
                    ROM = 128;
                else if (ROM >= 129 && ROM <= 512)
                    ROM = 512;
                else if (ROM >= 513 && ROM <= 1024)
                    ROM = 1024;
                else if (ROM >= 1025)
                    ROM = 2048;
            }
            if (VideoCard == 0)
                VideoCard = 1;
            if (model == "Lenovo")
            {
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Lenovo.png"));
                if (Work_purpose.IsEnabled == true && Gaming_purpose.IsEnabled == false)
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/LenovoThinkPad.png"));
                else
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/LenovoIdeaPad.png"));

            }
            else
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/PCLaptop.png"));
            if (Gaming_purpose.IsChecked == true)
            {
                RAM = 16;
                ROM = 1524;
                CPU = 4.0;
                kernels = 8;
                VideoCard = 6;
                VideoCard_model = "Invidia GeForce RTX"; СPU_model = "Intel Core i9";
                if (Mobile.IsOn == true)
                {
                    type = "Laptop";
                    model = "Gaming laptop";
                }
                else
                {
                    type = "PC";
                    model = "Gaming PC";
                }
                OS_str = "Windows";
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Windows.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/GamingPC.png"));
            }
            Final_Result();
        }
        public async void Final_Result()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ContentDialog Result = new ContentDialog()
            {
                Title = resourceLoader.GetString("Result"),
                Content = resourceLoader.GetString("Model_str") + model + "\n" +
                            //"Рекомандованные для Вас характеристики ПК:" + "\n" +
                            resourceLoader.GetString("OS") + OS_str + "\n" +
                            resourceLoader.GetString("TypeDevice") + type + "\n" +
                            resourceLoader.GetString("RAM") + RAM + " GB (" + typeRAM + ")" + "\n" + resourceLoader.GetString("ROM") + ROM + " GB" + "\n" +
                            "CPU: " + СPU_model + resourceLoader.GetString("CPU") + CPU + resourceLoader.GetString("Processor_architecture") + typeCPU + "\n" +
                            resourceLoader.GetString("VideoCard") + VideoCard_model + ", " + resourceLoader.GetString("ROMvideo") + VideoCard + " GB",
                PrimaryButtonText = resourceLoader.GetString("Okay"),
            };
            ContentDialogResult result = await Result.ShowAsync();
        }
    }
}

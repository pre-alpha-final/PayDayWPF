﻿using Microsoft.Extensions.DependencyInjection;
using PayDayWPF.Pages;
using PayDayWPF.Persistence;
using PayDayWPF.Persistence.Implementation;
using System.Windows;
using System.Windows.Controls;
using PayDayWPF.ViewModels;

namespace PayDayWPF
{
    public partial class MainWindow : Window
    {
        public static ServiceProvider ServiceProvider { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<AddPackageViewModel>();
            serviceCollection.AddTransient<MainMenuViewModel>();
            serviceCollection.AddTransient<MarkMeetingViewModel>();
            serviceCollection.AddTransient<RemainingMeetingsViewModel>();
            serviceCollection.AddTransient<StatisticsViewModel>();
            serviceCollection.AddSingleton<IRepository, JsonRepository>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void ChangePage(Page page)
        {
            NavigationFrame.NavigationService.Navigate(page);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ChangePage(new MainMenuPage());
        }
    }
}

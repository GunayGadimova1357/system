using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.Http;
using WeatherApp.Controllers;
using WeatherApp.Services;
using WeatherApp.Infrastructure;
using WeatherApp.Avalonia.Infrastructure;

namespace WeatherApp.Avalonia.Views
{
    public partial class MainWindow : Window
    {
        private readonly WeatherController _controller;

        public MainWindow()
        {
            InitializeComponent();

            var http = new HttpClient();
            var apiKey = "b0ca02ccee2287053a0abd3fe462f1b5";
            var service = new WeatherService(http, apiKey);
            IUiSync ui = new AvaloniaUiSync();

            _controller = new WeatherController(service, ui);
            _controller.StateChanged += info =>
            {
                TempText.Text = $"{info.TempC:F1} °C";
                DescText.Text = info.Description;
                ErrorText.Text = "";
            };
            _controller.Error += msg => ErrorText.Text = msg;
        }

        private void FetchBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            var city = CityBox.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(city)) _controller.Start(city);
            else ErrorText.Text = "Enter a valid city name";
        }
    }
}
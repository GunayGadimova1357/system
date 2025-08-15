using System;
using Avalonia.Threading;
using WeatherApp.Infrastructure; 

namespace WeatherApp.Avalonia.Infrastructure
{
    public sealed class AvaloniaUiSync : IUiSync
    {
        public void Post(Action action) => Dispatcher.UIThread.Post(action);
    }
}
using System;
using System.Collections.Concurrent;
using WeatherApp.Infrastructure;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Workers;

namespace WeatherApp.Controllers
{
  
    public sealed class WeatherController
    {
        private readonly IWeatherService _service;
        private readonly IUiSync _ui;
        private readonly ConcurrentDictionary<string, WeatherPoller> _workers = new();

        public event Action<WeatherInfo>? StateChanged;
        public event Action<string>? Error;

        public WeatherController(IWeatherService service, IUiSync ui)
        {
            _service = service;
            _ui = ui;
        }

        public void Start(string city)
        {
            var worker = _workers.GetOrAdd(city, c =>
            {
                var w = new WeatherPoller(_service, c);
                w.Tick += info => _ui.Post(() => StateChanged?.Invoke(info));
                w.Error += msg => _ui.Post(() => Error?.Invoke(msg));
                return w;
            });

            worker.Start();
        }

        public void Stop(string city)
        {
            if (_workers.TryRemove(city, out var w))
                w.Stop();
        }

        public void StopAll()
        {
            foreach (var w in _workers.Values)
                w.Stop();
            _workers.Clear();
        }
    }
}
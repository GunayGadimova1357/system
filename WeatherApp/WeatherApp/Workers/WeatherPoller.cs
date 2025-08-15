using System;
using System.Threading;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Workers
{

    public sealed class WeatherPoller
    {
        private readonly IWeatherService _service;
        private readonly string _city;
        private Thread? _thread;
        private volatile bool _running;

        public event Action<WeatherInfo>? Tick;   
        public event Action<string>? Error;      

        public WeatherPoller(IWeatherService service, string city)
        {
            _service = service;
            _city = city;
        }

        public void Start()
        {
            if (_running) return; 
            _running = true;
            _thread = new Thread(Loop) { IsBackground = true, Name = $"Weather:{_city}" };
            _thread.Start();
        }

        public void Stop() => _running = false;

        private void Loop()
        {
            while (_running)
            {
                try
                {
                    var info = _service.GetCurrent(_city);
                    Tick?.Invoke(info);
                }
                catch (Exception ex)
                {
                    Error?.Invoke(ex.Message);
                }
                
                for (int i = 0; i < 100 && _running; i++)
                    Thread.Sleep(100);
            }
        }
    }
}
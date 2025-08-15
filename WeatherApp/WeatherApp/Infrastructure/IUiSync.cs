using System;

namespace WeatherApp.Infrastructure
{
 
    public interface IUiSync
    {

        void Post(Action action);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicApp.Models;
using MagicMvvm;

namespace BasicApp.ViewModels
{
    public class FetchDataViewModel : ViewModelBase
    {
        private readonly WeatherForecastService _forecastService;

        public FetchDataViewModel(WeatherForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        public IEnumerable<WeatherForecast> Forecasts { get; private set; }

        public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(DateTime startDate)
        {
            return await _forecastService.GetForecastAsync(startDate);
        }

        public override async Task OnInitializedAsync()
        {
            Forecasts = await GetForecastsAsync(DateTime.Now);
        }
    }
}

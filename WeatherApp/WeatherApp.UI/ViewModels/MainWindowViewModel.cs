using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Core;
using WeatherApp.Core.Models;

namespace WeatherApp.UI.ViewModels;

public partial class MainWindowViewModel(IWeatherServices weatherServices) : ObservableObject
{
    private string _cityInput = "";
    private WeatherForecast? _forecast;
    private bool _isLoading;
    private string? _errorMessage;
    
    public string CityInput
    {
        get => _cityInput;
        set
        {
            _cityInput = value;
            OnPropertyChanged();
        }
    }

    public WeatherForecast? Forecast
    {
        get => _forecast;
        
        set
        {
            _forecast = value;
            OnPropertyChanged();
        }
    }

    public bool IsLoading
    {
        get => _isLoading;
        
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }
    
    public ObservableCollection<ForecastDay> DailyForecast { get; } = [];
    
    [RelayCommand] //Async tied to MVVM 
    private async Task SearchAsync() //It fetches weather data and update's ViewModel's properties. 
    {
        if (string.IsNullOrWhiteSpace(CityInput))
        {
            return; 
        }
        
        IsLoading = true;
        ErrorMessage = null;

        try
        {
            

        }
        catch(Exception e)
        {
            _errorMessage = $"Could not search for {CityInput}";
            ErrorMessage = e.Message;
        }
        finally
        {
            IsLoading = false;
        }
        
    }


}
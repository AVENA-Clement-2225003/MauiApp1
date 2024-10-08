﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        async void Add()
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            if(connectivity.NetworkAccess != NetworkAccess.Internet) 
            {
                await Shell.Current.DisplayAlert("Uh oh!", "No internet", "Ok");
                return;
            }

            items.Add(text);
            text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s) 
        {
            if (Items.Contains(s)) { Items.Remove(s); }
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }
    }
}

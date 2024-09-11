using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            items = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            items.Add(text);
            text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s) 
        {
            if (Items.Contains(s)) { Items.Remove(s); }
        }
    }
}

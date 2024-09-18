using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BeginnersTask.ViewModels;

[QueryProperty("Text", "Text")]
public partial class DetailViewModel : ObservableObject {

    [ObservableProperty]
    string text = string.Empty;

    [RelayCommand]
    async Task GoBack() {
        await Shell.Current.GoToAsync("..");
    }

}

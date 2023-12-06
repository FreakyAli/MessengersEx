using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace MessengersEx;

internal partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {

    }

    [RelayCommand]
    private void StrongReference()
    {
        StrongReferenceMessenger.Default.Send(new StrongRefdMessage("Strong Reference Messenger"));
    }

    [RelayCommand]
    private void WeakReference()
    {
        // Default sender, you also can create your own if you want!
        WeakReferenceMessenger.Default.Send(new WeakRefMessage("Weak Reference Messenger"));
    }
}
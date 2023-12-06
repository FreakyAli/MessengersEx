using CommunityToolkit.Mvvm.Messaging;

namespace MessengersEx;

public partial class MainPage : ContentPage,
                                IRecipient<WeakRefMessage>,
                                IRecipient<StrongRefdMessage>
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Register so that you can recieve your messages,
        // receiver only works after you register.
        // There is an inline registration that lets you configure a lambda
        // but it looks very unclean to me i prefer this way
        // if you like your messages to be a lamba inline you can do that too.
        WeakReferenceMessenger.Default.Register<WeakRefMessage>(this);
        StrongReferenceMessenger.Default.Register<StrongRefdMessage>(this);

        // Do you have multiple weak or strong messengers and they all need to be received here?
        //Use these instead
        //WeakReferenceMessenger.Default.RegisterAll(this);
        //StrongReferenceMessenger.Default.RegisterAll(this);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Its Mandatory for you to unregister StrongReferenceMessenger,
        // unregistering WeakReferenceMessenger is optional
        WeakReferenceMessenger.Default.Unregister<WeakRefMessage>(this); //optional
        StrongReferenceMessenger.Default.Unregister<StrongRefdMessage>(this);

        // Do you have multiple weak or strong messengers and they all need to be unregistered here?
        //Use these instead
        //WeakReferenceMessenger.Default.UnregisterAll(this);
        //StrongReferenceMessenger.Default.UnregisterAll(this);
    }

    // The reciever that comes from IRecipient
    public void Receive(WeakRefMessage message)
    {
        // MainThread is only needed if you are uncertain if this will be called from the mainthread.
        // You can check if it works without it but I recommend you always run your messages on mainthread.
        // if you are using .NET Maui you can use `MainThread.IsMainThread` boolean to check the same.
        MainThread.InvokeOnMainThreadAsync(async () => await this.DisplayAlert(message.Value, "Hello from WeakReferenceMessenger", "Ok"));
    }

    public void Receive(StrongRefdMessage message)
    {
        MainThread.InvokeOnMainThreadAsync(async () => await this.DisplayAlert(message.Value, "Hello from StrongReferenceMessenger", "Ok"));
    }
}
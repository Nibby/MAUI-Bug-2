namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
        
        window.Deactivated += HandleWindowDeactivated;
        
        return window;
    }

    private async void HandleWindowDeactivated(object sender, EventArgs e)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            // Add this delay to increase chances that Android saves fragment state and reject the upcoming PopAsync call()
            await Task.Delay(5000);
            
            Console.WriteLine("About to POP after stop");
            
            await Current!.MainPage!.Navigation.PopAsync();
            
            Console.WriteLine("Finished POP after stop");
        });
    }
}
namespace MauiApp1;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void PushPage(object sender, EventArgs e)
    {
        _ = MainThread.InvokeOnMainThreadAsync(() =>
        {
            Navigation.PushAsync(new PushedPage());
        });
    }
}
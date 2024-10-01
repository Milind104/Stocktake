using MauiStockTake.UI.Helpers;

namespace MauiStockTake.UI;

public partial class App : Application
{
    public static Theme Theme { get; set; } = Theme.Default;

    public App()
    {
#if WINDOWS
        if (WinUIEx.WebAuthenticator.CheckOAuthRedirectionActivation())
            return;
#endif
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override async void OnStart()
    {
        base.OnStart();

        await MainPage.Navigation.PushModalAsync<LoginPage>();
    }
}

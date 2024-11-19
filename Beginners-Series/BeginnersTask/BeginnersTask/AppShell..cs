namespace BeginnersTask;

public class AppShell : Shell {
    public AppShell(MainPage mainPage) {

        Title = "Beginners Task";
        FlyoutBehavior = FlyoutBehavior.Disabled;

        var shellContent = new ShellContent {
            Title = "Home",
            ContentTemplate = new DataTemplate(() => mainPage),
            Route = "MainPage"
        };


        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));

        Items.Add(shellContent);
    }
}

namespace BasicTemplate;

public partial class AppShell : Shell {
    public AppShell() {

        Title = "Basic Template";
        FlyoutBehavior = FlyoutBehavior.Disabled;

        // Define shellcontent
        var shellContent = new ShellContent {
            Title = "Home",
            ContentTemplate = new DataTemplate(() => new MainPage()),
            Route = "MainPage"
        };

        Items.Add(shellContent);
    }
}

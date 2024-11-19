namespace Calculator;

public class AppShell : Shell {


    public AppShell() {


        Title = "Calculator";
        FlyoutBehavior = FlyoutBehavior.Disabled;

        var shellContent = new ShellContent {
            Title = "Calculator",
            ContentTemplate = new DataTemplate(() => new MainPage()),
            Route = "MainPage"
        };


        Items.Add(shellContent);

    }


}

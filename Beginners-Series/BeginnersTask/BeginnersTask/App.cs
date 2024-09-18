namespace BeginnersTask;

public partial class App : Application {
    public App(IServiceProvider serviceProvider) {


        //InitializeComponent();

        if(Application.Current?.Resources.MergedDictionaries is not { } mergedDictionaries) {
            return;
        }

        mergedDictionaries.Clear();
        mergedDictionaries.Add(new Resources.Styles.Colors());
        mergedDictionaries.Add(new Resources.Styles.Styles());

        var mainPage = serviceProvider.GetService<MainPage>();

        MainPage = new AppShell(mainPage!);
    }
}

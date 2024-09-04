namespace BasicTemplate;

public partial class App : Application {
    public App() {
        //InitializeComponent();

        if(Application.Current?.Resources.MergedDictionaries is not { } mergedDictionaries) {
            return;
        }

        mergedDictionaries.Clear();
        mergedDictionaries.Add(new Resources.Styles.Colors());
        mergedDictionaries.Add(new Resources.Styles.Styles());

        MainPage = new AppShell();
    }
}

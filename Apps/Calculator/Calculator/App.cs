namespace Calculator;

public class App : Application {
    public App() {


        if(Application.Current?.Resources.MergedDictionaries is not { } mergedDictionaries) {
            return;
        }

        mergedDictionaries.Clear();
        mergedDictionaries.Add(new Resources.Styles.Colors());
        mergedDictionaries.Add(new Resources.Styles.Styles());

        MainPage = new AppShell();
    }
}

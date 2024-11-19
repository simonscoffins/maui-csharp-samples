namespace ShellFlyout {


    public partial class App : Application {

        public App() {

            var mergedDictionaries = Current?.Resources.MergedDictionaries;

            if(mergedDictionaries != null) {
                mergedDictionaries.Add(new Resources.Styles.Colors());
                mergedDictionaries.Add(new Resources.Styles.Styles());
            }
        }

        protected override Window CreateWindow(IActivationState? activationState) {
            return new Window(new AppShell());
        }
    }
}
using ShellTabBar.Pages;

namespace ShellTabBar {
    public partial class AppShell : Shell {
        public AppShell() {

            Title = "Basic Template";
            FlyoutBehavior = FlyoutBehavior.Disabled;


            var tabBar = BuildTabBar();
            Items.Add(tabBar);
        }


        private TabBar BuildTabBar() {

            var resources = App.Current?.Resources;

            var tabBar = new TabBar();


            // Tab One
            tabBar.Items.Add(new Tab() {
                Title = "One",
                Icon = resources["IconOne"] as ImageSource,
                Items = {
                    new ShellContent() {
                        Title = "One",
                        ContentTemplate = new DataTemplate(() => new PageOne()),
                        Route = "PageOne"
                    }
                }
            });


            // Tab Two
            tabBar.Items.Add(new Tab() {
                Title = "Two",
                Icon = resources["IconTwo"] as ImageSource,
                Items = {
                    new ShellContent() {
                        Title = "Two",
                        ContentTemplate = new DataTemplate(() => new PageTwo()),
                        Route = "PageTwo"
                    }
                }
            });


            // Tab Three
            tabBar.Items.Add(new Tab() {
                Title = "Three",
                Icon = resources["IconThree"] as ImageSource,
                Items = {
                    new ShellContent() {
                        Title = "Three",
                        ContentTemplate = new DataTemplate(() => new PageThree()),
                        Route = "PageThree"
                    }
                }
            });


            // Tab Four
            tabBar.Items.Add(new Tab() {
                Title = "Four",
                Icon = resources["IconFour"] as ImageSource,
                Items = {
                    new ShellContent() {
                        Title = "Four",
                        ContentTemplate = new DataTemplate(() => new PageFour()),
                        Route = "PageFour"
                    }
                }
            });

            return tabBar;
        }
    }
}

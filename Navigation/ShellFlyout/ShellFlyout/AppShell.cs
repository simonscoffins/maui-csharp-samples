
using ShellFlyout.Pages;

namespace ShellFlyout {


    public partial class AppShell : Shell {
        public AppShell() {

            Title = "Basic Template";
            FlyoutBehavior = FlyoutBehavior.Flyout;

            // Define shellcontent
            var shellContent = new ShellContent {
                Title = "Main Page",
                ContentTemplate = new DataTemplate(() => new MainPage()),
                Route = "MainPage"
            };




            //Items.Add(shellContent);

            var resources = App.Current?.Resources;



            // Flyout One
            Items.Add(new FlyoutItem {
                Title = "One",
                FlyoutIcon = resources["IconOne"] as ImageSource,
                Items = {
                    new ShellContent {
                        Title = "One",
                        ContentTemplate = new DataTemplate(() => new PageOne()),
                        Route = "PageOne"
                        }
                    }
            });

            // Flyout Two
            Items.Add(new FlyoutItem {
                Title = "Two",
                FlyoutIcon = resources["IconTwo"] as ImageSource,
                Items = {
                    new ShellContent {
                        Title = "Two",
                        ContentTemplate = new DataTemplate(() => new PageTwo()),
                        Route = "PageTwo"
                        }
                    }
            });


            // Flyout Three
            Items.Add(new FlyoutItem {
                Title = "Three",
                FlyoutIcon = resources["IconThree"] as ImageSource,
                Items = {
                    new ShellContent {
                        Title = "Three",
                        ContentTemplate = new DataTemplate(() => new PageThree()),
                        Route = "PageThree"
                        }
                    }
            });


            // Flyout Four
            Items.Add(new FlyoutItem {
                Title = "Four",
                FlyoutIcon = resources["IconFour"] as ImageSource,
                Items = {
                    new ShellContent {
                        Title = "Four",
                        ContentTemplate = new DataTemplate(() => new PageFour()),
                        Route = "PageFour"
                        }
                    }
            });


        }

    }




}

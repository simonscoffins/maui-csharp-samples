
using ShellMixed.Pages;

namespace ShellMixed {
    public partial class AppShell : Shell {
        public AppShell() {


            Title = "Shell Mixed";
            FlyoutBehavior = FlyoutBehavior.Flyout;

            var reources = App.Current?.Resources;

            // add flyout items
            Items.Add(FlyoutItemOne());
            Items.Add(FlyoutItemTwo());
            Items.Add(FlyoutItemThree());
        }



        private FlyoutItem FlyoutItemOne() {

            var resources = App.Current?.Resources;

            return new FlyoutItem() {
                Title = "One",
                FlyoutIcon = resources["IconOne"] as ImageSource,
                Route = "One",
                Items = {
                    new ShellContent {
                        Title = "One",
                        ContentTemplate = new DataTemplate(() => new PageOne()),
                        Route = "PageOne"
                        }
                    }
            };
        }


        private FlyoutItem FlyoutItemTwo() {

            var resources = App.Current?.Resources;

            return new FlyoutItem() {
                Title = "Two",
                FlyoutIcon = resources["IconTwo"] as ImageSource,
                Route = "Two",
                Items = {
                    new Tab {
                        Title = "TwoA",
                        Icon = resources["IconOne"] as ImageSource,
                        Items = {
                            new ShellContent {
                                Title = "TwoA",
                                ContentTemplate = new DataTemplate(() => new PageTwoA()),
                                Route = "PageTwoA"
                            }
                        }
                    },

                    new Tab {
                        Title = "TwoB",
                        Icon = resources["IconTwo"] as ImageSource,
                        Items = {
                            new ShellContent {
                                Title = "TwoB",
                                ContentTemplate = new DataTemplate(() => new PageTwoB()),
                                Route = "PageTwoB"
                            }
                        }
                    },
                    new Tab {
                        Title = "TwoC",
                        Icon = resources["IconThree"] as ImageSource,
                        Items = {
                            new ShellContent {
                                Title = "TwoC",
                                ContentTemplate = new DataTemplate(() => new PageTwoC()),
                                Route = "PageTwoC"
                            }
                        }
                    }
                }
            };
        }


        private FlyoutItem FlyoutItemThree() {

            var resources = App.Current?.Resources;

            return new FlyoutItem() {
                Title = "Three",
                FlyoutIcon = resources["IconThree"] as ImageSource,
                Route = "Three",
                Items = {
                    new Tab {
                        Title = "ThreeA",
                        Icon = resources["IconOne"] as ImageSource,
                        Items = {
                            new ShellContent {
                                Title = "ThreeA",
                                ContentTemplate = new DataTemplate(() => new PageThreeA()),
                                Route = "PageThreeA"
                            }
                        }
                    },
                    new Tab {
                        Title = "ThreeB",
                        Icon = resources["IconTwo"] as ImageSource,
                        Items = {
                            new ShellContent {
                                Title = "ThreeB",
                                ContentTemplate = new DataTemplate(() => new PageThreeB()),
                                Route = "PageThreeB"
                            }
                        }
                    },
                }
            };
        }

    }
}

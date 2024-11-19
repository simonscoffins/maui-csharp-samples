namespace ShellFlyout.Pages;

public static class PageLayout {


    // vertcal stack layout
    public static VerticalStackLayout VerticalStackLayout(string headlineText, EventHandler btnHandler) {
        var layout = new VerticalStackLayout {
            Children = { ImageBot(), Headline(headlineText), CounterButton(btnHandler) },
            AutomationId = "MainStackLayout",
            Padding = new Thickness(30, 0),
            Spacing = 25,
        };

        SemanticProperties.SetDescription(layout, "Main stack layout with dot net bot image, headline, subheadline, and counter button");
        return layout;
    }

    // image
    private static Image ImageBot() {
        var img = new Image {
            Source = "dotnet_bot.png",
            AutomationId = "MauiImg",
            HeightRequest = 185,
            Aspect = Aspect.AspectFit,
        };

        SemanticProperties.SetDescription(img, "dot net bot in race car number eight");
        return img;
    }


    // Headline
    private static Label Headline(string headlingText) {

        var style = App.Current?.Resources["Headline"] as Style;

        var lbl = new Label {
            Text = headlingText,
            AutomationId = "LvlOneLbl",
            Style = style!
        };

        return lbl;
    }



    // Add the following code to the MainPage class
    private static Button CounterButton(EventHandler btnHandler) {

        var btn = new Button {

            Text = "Click me",
            AutomationId = "CounterBtn",
            HorizontalOptions = LayoutOptions.Center
            //HorizontalOptions = LayoutOptions.Fill,

        };

        // set the click event handler
        //btn.Clicked += (f, f2) => OnCounterClicked(f!, f2);

        btn.Clicked += (f, f2) => btnHandler(f, f2);

        SemanticProperties.SetHint(btn, "Click me to increment the counter");
        return btn;
    }

}

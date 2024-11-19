namespace ShellFlyout;

public class MainPage : BasePage {
    int count = 0;

    public MainPage() {

        this.Build();
    }

    public override void Build() {

        var sv = new ScrollView {
            Content = VerticalStackLayout()
        };

        Content = sv;
    }


    // vertcal stack layout
    private VerticalStackLayout VerticalStackLayout() {
        var layout = new VerticalStackLayout {
            Children = { ImageBot(), Headline(), SubHeadline(), CounterButton() },
            AutomationId = "MainStackLayout",
            Padding = new Thickness(30, 0),
            Spacing = 25,
        };

        SemanticProperties.SetDescription(layout, "Main stack layout with dot net bot image, headline, subheadline, and counter button");
        return layout;
    }


    // image
    private Image ImageBot() {
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
    private Label Headline() {

        var style = App.Current?.Resources["Headline"] as Style;

        var lbl = new Label {
            Text = "Hello, World!",
            AutomationId = "LvlOneLbl",
            Style = style!
        };

        return lbl;
    }

    // SubHeadline
    private Label SubHeadline() {

        var style = App.Current?.Resources["SubHeadline"] as Style;

        var lbl = new Label {
            Text = "Welcome to \n .NET Multi-platform App UI",
            AutomationId = "LvlTwoLbl",
            Style = style!
        };

        SemanticProperties.SetHeadingLevel(lbl, SemanticHeadingLevel.Level2);
        SemanticProperties.SetDescription(lbl, "Welcome to dot net Multi platform App U I");
        return lbl;
    }



    // Add the following code to the MainPage class
    private Button CounterButton() {

        var btn = new Button {

            Text = "Click me",
            AutomationId = "CounterBtn",
            HorizontalOptions = LayoutOptions.Center,

        };

        // set the click event handler
        btn.Clicked += (f, f2) => OnCounterClicked(f!, f2);

        SemanticProperties.SetHint(btn, "Click me to increment the counter");
        return btn;
    }


    private void OnCounterClicked(object sender, EventArgs e) {
        count++;

        var btn = (Button)sender;

        if(count == 1)
            btn.Text = $"Clicked {count} time";
        else
            btn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(btn.Text);
    }


}


namespace ShellMixed.Pages;

public class PageThreeB : BasePage {

    int count = 0;

    public PageThreeB() {

        this.Build();
    }

    public override void Build() {

        var sv = new ScrollView {
            Content = PageLayout.VerticalStackLayout("Page Three B!", OnCounterClicked)
        };

        Content = sv;
    }


    private void OnCounterClicked(object? sender, EventArgs e) {
        count++;

        var btn = (Button)sender!;
        var times = (count == 1) ? "time" : "times";
        btn.Text = $"Clicked {count} {times}";

        SemanticScreenReader.Announce(btn.Text);
    }


}


namespace ShellMixed.Pages;

public class PageTwoC : BasePage {

    int count = 0;

    public PageTwoC() {

        this.Build();
    }

    public override void Build() {

        var sv = new ScrollView {
            Content = PageLayout.VerticalStackLayout("Page Two C!", OnCounterClicked)
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


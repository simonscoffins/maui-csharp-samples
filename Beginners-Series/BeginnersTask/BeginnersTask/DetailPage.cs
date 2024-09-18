using BeginnersTask.ViewModels;

namespace BeginnersTask;

//[QueryProperty("Text", "Text")]
public class DetailPage : BasePage {



    public DetailPage(DetailViewModel vm) {


        // set the binding context of the page to the view model
        BindingContext = vm;


        // build the page
        Build();

    }

    public override void Build() {

        Title = "Detail Page";

        // create the content ui
        Content = new StackLayout {
            Padding = new Thickness(20),
            Children = {
                CreateLabel(),
                CreateButton()
            }
        };

    }


    // create label method

    private Label CreateLabel() {
        var lbl = new Label {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            FontSize = 25
        };

        //lbl.Text = "Hello from DetailPage";

        lbl.SetBinding(Label.TextProperty, nameof(DetailViewModel.Text));
        return lbl;
    }


    // create button method
    private Button CreateButton() {
        var btn = new Button {
            Text = "Go Back",
        };

        btn.SetBinding(Button.CommandProperty, nameof(DetailViewModel.GoBackCommand));
        return btn;
    }



}
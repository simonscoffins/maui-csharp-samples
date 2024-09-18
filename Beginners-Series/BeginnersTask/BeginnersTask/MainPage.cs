using BeginnersTask.ViewModels;

namespace BeginnersTask;

public class MainPage : BasePage {


    public MainPage(MainViewModel vm) {

        BindingContext = vm;

        this.Build();
    }


    public override void Build() {

        Content = CreateGrid();
    }


    // create grid method
    private Grid CreateGrid() {

        var grid = new Grid {

            // define rows
            RowDefinitions = {
                new RowDefinition { Height = new GridLength(100) },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Star }
            },

            // define columns
            ColumnDefinitions = {
                new ColumnDefinition { Width = new GridLength(0.75, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(0.25, GridUnitType.Star) }
            },

            Padding = new Thickness(10),
            RowSpacing = 10,
            ColumnSpacing = 10
        };

        var image = CreateImage();
        grid.Add(image, column: 0, row: 0);
        Grid.SetColumnSpan(image, 2);


        // add entry to the grid
        grid.Add(CreateEntry(), column: 0, row: 1);

        // add button to the grid
        grid.Add(CreateButton(), column: 1, row: 1);


        // add collection view to the grid
        var collectionView = CreateCollectionView();
        grid.Add(collectionView, column: 0, row: 2);
        Grid.SetColumnSpan(collectionView, 2);

        return grid;
    }


    // create image method
    private Image CreateImage() {

        var image = new Image {
            Source = "logo.png",
            BackgroundColor = App.Current?.Resources["Transparent"] as Color

        };

        return image;
    }


    // create entry method
    private Entry CreateEntry() {

        var entry = new Entry {
            Placeholder = "Enter task"
        };
        entry.SetBinding(Entry.TextProperty, nameof(MainViewModel.Text));

        return entry;
    }


    // create button method
    private Button CreateButton() {

        var button = new Button {
            Text = "Add"
        };

        button.SetBinding(Button.CommandProperty, nameof(MainViewModel.AddCommand));

        return button;
    }


    // create collection view method
    private CollectionView CreateCollectionView() {

        var cv = new CollectionView {
            SelectionMode = SelectionMode.None
        };

        cv.ItemTemplate = CreateDataTemplate();

        cv.SetBinding(CollectionView.ItemsSourceProperty, nameof(MainViewModel.Items));
        return cv;
    }



    // create data template method
    private DataTemplate CreateDataTemplate() {

        var dataTemplate = new DataTemplate(() => {

            var swipeView = new SwipeView();

            // create swipe items
            var swipeItems = CreateSwipeItems();
            swipeView.RightItems = swipeItems;


            var grid = new Grid { Padding = new Thickness(0, 5) };
            var frame = new Frame();

            // create tap gesture recognizer
            var tapGestureRecognizer = CreateTapGestureRecognizer();
            frame.GestureRecognizers.Add(tapGestureRecognizer);

            // create label for frame
            var label = new Label { FontSize = 24 };
            label.SetBinding(Label.TextProperty, ".");

            frame.Content = label;


            grid.Add(frame);

            swipeView.Content = grid;

            return swipeView;
        });

        return dataTemplate;

    }


    // create swipe item method
    private SwipeItems CreateSwipeItems() {

        var swipeItems = new SwipeItems();

        var swipeItem = new SwipeItem {
            Text = "Delete",
            BackgroundColor = App.Current?.Resources["Red"] as Color
        };

        swipeItem.SetBinding(SwipeItem.CommandProperty,
            new Binding(nameof(MainViewModel.DeleteCommand),
            source: new RelativeBindingSource(RelativeBindingSourceMode.FindAncestorBindingContext,
            ancestorType: typeof(MainViewModel))));


        swipeItem.SetBinding(SwipeItem.CommandParameterProperty, ".");

        swipeItems.Add(swipeItem);
        return swipeItems;
    }



    // create tap gesture recognizer method
    private TapGestureRecognizer CreateTapGestureRecognizer() {

        var tgr = new TapGestureRecognizer();

        tgr.SetBinding(TapGestureRecognizer.CommandProperty,
            new Binding(nameof(MainViewModel.TapCommand),
            source: new RelativeBindingSource(RelativeBindingSourceMode.FindAncestorBindingContext,
            ancestorType: typeof(MainViewModel))));

        tgr.SetBinding(TapGestureRecognizer.CommandParameterProperty, ".");

        return tgr;
    }


}


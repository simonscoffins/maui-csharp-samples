namespace Calculator;

public class MainPage : ContentPage {

    string _currentEntry = string.Empty;
    int _currentState = 1;
    string _mathOperator = string.Empty;
    double _firstNumber, secondNumber;
    string _decimalFormat = "N0";

    private Label _resultText;
    private Label _currentCalculation;

    public MainPage() {
        var grid = new Grid {
            Padding = new Thickness(16),
            RowSpacing = 2,
            ColumnSpacing = 2,
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Star }
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star }
            }
        };

        // Current calculation
        _currentCalculation = new Label {
            FontSize = 22,
            LineBreakMode = LineBreakMode.NoWrap,
            Text = "",
            TextColor = Application.Current?.Resources["Light"] as Color,
            HorizontalTextAlignment = TextAlignment.End,
            VerticalTextAlignment = TextAlignment.Start
        };


        Grid.SetColumnSpan(_currentCalculation, 4);
        grid.Add(_currentCalculation);


        // Result text
        this._resultText = new Label {
            FontSize = 64,
            FontAttributes = FontAttributes.Bold,
            Text = "0",
            HorizontalTextAlignment = TextAlignment.End,
            VerticalTextAlignment = TextAlignment.End,
            TextColor = Application.Current?.Resources["Light"] as Color,
            LineBreakMode = LineBreakMode.NoWrap
        };

        Grid.SetColumnSpan(_resultText, 4);
        grid.Add(_resultText);

        // Separator
        var boxView = new BoxView {
            BackgroundColor = Application.Current?.Resources["LightGray"] as Color,
            HeightRequest = 1,
            VerticalOptions = LayoutOptions.End
        };
        Grid.SetRow(boxView, 0);
        Grid.SetColumnSpan(boxView, 4);
        grid.Add(boxView);


        // Buttons
        AddButton(grid, "C", 1, 0, OnClear!);
        AddButton(grid, "+/-", 1, 1, OnNegative!);
        AddButton(grid, "%", 1, 2, OnPercentage!);

        for(int i = 0; i < 3; i++) {
            for(int j = 0; j < 3; j++) {
                int number = 7 - (i * 3) + j;
                AddButton(grid, number.ToString(), i + 2, j, OnSelectNumber!);
            }
        }

        AddButton(grid, "00", 5, 0, OnSelectNumber!);
        AddButton(grid, "0", 5, 1, OnSelectNumber!);
        AddButton(grid, ".", 5, 2, OnSelectNumber!);

        AddButton(grid, "÷", 1, 3, OnSelectOperator!);
        AddButton(grid, "×", 2, 3, OnSelectOperator!);
        AddButton(grid, "-", 3, 3, OnSelectOperator!);
        AddButton(grid, "+", 4, 3, OnSelectOperator!);

        AddButton(grid, "=", 5, 3, OnCalculate!);


        // Set the content of the page
        Content = grid;
    }

    private void AddButton(Grid grid, string text, int row, int column, EventHandler clicked) {
        var button = new Button { Text = text };
        button.Clicked += clicked;
        grid.Add(button);
        Grid.SetRow(button, row);
        Grid.SetColumn(button, column);
    }

    void OnSelectNumber(object sender, EventArgs e) {
        var button = (Button)sender;
        var pressed = button.Text;

        _currentEntry += pressed;

        if((_resultText.Text == "0" && pressed == "0")
            || (_currentEntry.Length <= 1 && pressed != "0")
            || _currentState < 0) {
            _resultText.Text = "";
            if(_currentState < 0)
                _currentState *= -1;
        }

        if(pressed == "." && _decimalFormat != "N2") {
            _decimalFormat = "N2";
        }

        _resultText.Text += pressed;
    }

    void OnSelectOperator(object sender, EventArgs e) {
        LockNumberValue(_resultText.Text);

        _currentState = -2;
        var button = (Button)sender;
        _mathOperator = button.Text;
    }

    private void LockNumberValue(string text) {
        double number;
        if(double.TryParse(text, out number)) {
            if(_currentState == 1) {
                _firstNumber = number;
            }
            else {
                secondNumber = number;
            }

            _currentEntry = string.Empty;
        }
    }

    void OnClear(object sender, EventArgs e) {
        _firstNumber = 0;
        secondNumber = 0;
        _currentState = 1;
        _decimalFormat = "N0";
        _resultText.Text = "0";
        _currentEntry = string.Empty;
    }

    void OnCalculate(object sender, EventArgs? e) {
        if(_currentState == 2) {
            if(secondNumber == 0)
                LockNumberValue(_resultText.Text);

            var result = Calculator.Calculate(_firstNumber, secondNumber, _mathOperator);

            _currentCalculation.Text = $"{_firstNumber} {_mathOperator} {secondNumber}";

            _resultText.Text = result.ToTrimmedString(_decimalFormat);
            _firstNumber = result;
            secondNumber = 0;
            _currentState = -1;
            _currentEntry = string.Empty;
        }
    }

    void OnNegative(object sender, EventArgs e) {
        if(_currentState == 1) {
            secondNumber = -1;
            _mathOperator = "×";
            _currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnPercentage(object sender, EventArgs e) {
        if(_currentState == 1) {
            LockNumberValue(_resultText.Text);
            _decimalFormat = "N2";
            secondNumber = 0.01;
            _mathOperator = "×";
            _currentState = 2;
            OnCalculate(this, null);
        }
    }
}
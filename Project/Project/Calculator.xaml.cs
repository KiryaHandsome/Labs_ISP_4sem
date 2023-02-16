namespace Project;

public partial class Calculator : ContentPage
{
    double firstValue = 0.0, secondValue = 0.0;
    string op;
    string entry = "";

    enum States
    {
        InputedFirstValue,
        InputedOperator,
        InputedSecondValue,
        InputedShowingResult
    };

    States state = States.InputedShowingResult;

    public Calculator()
    {
        InitializeComponent();
    }

    private void OnDigitClicked(object sender, EventArgs e)
    {
        Button ClickedButton = sender as Button;
        if (state == States.InputedShowingResult)
        {
            OperationLabel.Text = "";
            entry = "";

            firstValue = 0;
            secondValue = 0;
            op = "";

            state = States.InputedFirstValue;
        }
        else if (state == States.InputedOperator)
        {
            state = States.InputedSecondValue;
        }
        if (entry == "0" && ClickedButton.Text != ",") entry = "";

        if (entry.Length < 10)
        {
            entry += ClickedButton.Text;
            EntryAndResultLabel.Text = entry;
        }
    }


    private void OnDelClicked(object sender, EventArgs e)
    {
        if (!(state == States.InputedOperator && entry == "") && state != States.InputedShowingResult)
        {
            if (entry.Length == 1)
            {
                entry = "0";
            }
            else
            {
                entry = entry.Substring(0, entry.Length - 1);
            }
            EntryAndResultLabel.Text = entry;
        }
    }


    private void OnOperatorClicked(object sender, EventArgs e)
    {
        Button ClickedButton = sender as Button;
        op = ClickedButton.Text;
        if (state == States.InputedOperator)
        {
            OperationLabel.Text = OperationLabel.Text.Substring(0, OperationLabel.Text.Length - 1);
        }
        state = States.InputedOperator;
        OperationLabel.Text = entry + op;
        firstValue = Convert.ToDouble(entry);
        entry = "";
    }

    static double Calculate(double first, double second, string op)
    {
        switch (op)
        {
            case "+":
                return first + second;
            case "-":
                return first - second;
            case "*":
                return first * second;
            case "/":
                return first / second;
            default: throw new NotImplementedException();
        }
    }


    private void OnCalculateClicked(object sender, EventArgs e)
    {

        if (state == States.InputedFirstValue || state == States.InputedShowingResult && op == "")
        {
            OperationLabel.Text = entry;
        }
        else
        {
            if (state == States.InputedOperator)
            {
                OperationLabel.Text = firstValue.ToString() + op + firstValue.ToString();
                secondValue = firstValue;
            }
            else if (state == States.InputedSecondValue)
            {
                OperationLabel.Text += entry;
                secondValue = Convert.ToDouble(entry);
            }
            else
            {
                OperationLabel.Text = entry + op + secondValue.ToString("");
            }

            firstValue = Calculate(firstValue, secondValue, op);
            Console.WriteLine(firstValue.ToString());
            if (Math.Abs(firstValue - Convert.ToInt32(firstValue)) == 0)
            {
                entry = Convert.ToInt32(firstValue).ToString("F0");
            }
            else
            {
                entry = firstValue.ToString("F");
                if (entry[entry.Length - 1] == '0')
                {
                    while (entry.Length != 0 && entry[entry.Length - 1] == '0')
                    {
                        entry = entry.Substring(0, entry.Length - 1);
                    }
                }
            }
        }
        OperationLabel.Text += "=";
        state = States.InputedShowingResult;
        EntryAndResultLabel.Text = entry;
    }


    private void OnCClicked(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue)
        {
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            OperationLabel.Text = "";
        }
        else if (state == States.InputedSecondValue)
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            secondValue = 0;
            OperationLabel.Text = "";
        }
        else
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            secondValue = 0;
            OperationLabel.Text = "";
        }
        entry = "0";
        EntryAndResultLabel.Text = "0";
    }


    private void OnCEClicked(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue)
        {
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator || state == States.InputedSecondValue)
        {
            state = States.InputedSecondValue;
        }
        else
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            secondValue = 0;
            OperationLabel.Text = "";
        }
        entry = "0";
        EntryAndResultLabel.Text = "0";
    }


    private void OnChangeSignClicked(object sender, EventArgs e)
    {
        if (entry.Length > 0 && entry[0] == '-')
        {
            entry = entry.Substring(1);
        }
        else
        {
            entry = "-" + entry;
        }
        EntryAndResultLabel.Text = entry;

        if (state == States.InputedShowingResult)
        {
            OperationLabel.Text = $"negate({entry})";
        }
    }


    private void OnDivisionByXClicked(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = "1/" + entry + "=";
            entry = (1 / Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = (1 / firstValue);
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = (1 / Convert.ToDouble(EntryAndResultLabel.Text));
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }


    private void OnSquareXClicked(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = entry + "^2=";
            entry = (Convert.ToDouble(entry) * Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = (firstValue * firstValue);
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = Convert.ToDouble(EntryAndResultLabel.Text) * Convert.ToDouble(EntryAndResultLabel.Text);
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }


    private void OnSqrtXClicked(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = "sqrt(" + entry + ")=";
            entry = Math.Sqrt(Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = Math.Sqrt(firstValue);
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = Math.Sqrt(Convert.ToDouble(EntryAndResultLabel.Text));
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }


    private void OnPercentClicked(object sender, EventArgs e)
    {
        if (state == States.InputedOperator)
        {
            secondValue = firstValue * firstValue / 100;
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
        else if (state == States.InputedSecondValue)
        {
            secondValue = Convert.ToDouble(entry) * firstValue / 100;
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }


    private void OnLog10Clicked(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = "lg(" + entry + ")=";
            entry = Math.Log10(Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = Math.Log10(firstValue);
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = Math.Log10(Convert.ToDouble(EntryAndResultLabel.Text));
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }
}
using Project.Services;
using Project.Entities;

namespace Project;

public partial class CurrencyConventer : ContentPage
{
    List<String> _currencies = new List<string> { "Russian Ruble", "EURO",
        "US Dollar", "Swiss Franc", "Yuan China", "Pound Sterling" };

    List<String> _currenciesAbreviations = new List<String> { "RUB", "EUR", "USD", "CHF", "CNY", "GBP" };

    private IRateService _rateService;
    private Rate _currentCurrency = null;

    public CurrencyConventer(IRateService rateService)
    {
        InitializeComponent();
        _rateService = rateService;
    }

    void WhenLoaded(object sender, EventArgs e)
    {
        CurrencyPicker.ItemsSource = _currencies;
        CurrencyPicker.ItemsSource = CurrencyPicker.GetItemsAsArray();
    }

    void GetCurrencyRate(object sender, EventArgs e)
    {
        if (CurrencyPicker.SelectedItem != null)
        {
            ErrorMessageLabel.Text = "";
            int index = CurrencyPicker.SelectedIndex;
            if (DatePicker.Date > DateTime.Now)
            {
                ErrorMessageLabel.Text = "Incorrect date chosen!";
                _currentCurrency = null;
            }
            else
            {
                _currentCurrency = _rateService.GetRates(DatePicker.Date)
                    .Where(r => r.Cur_Abbreviation.Equals(_currenciesAbreviations[index]))
                    .First();
                CurrencyLabel.Text = ((double)(_currentCurrency.Cur_Scale / _currentCurrency.Cur_OfficialRate)).ToString("F2") + " " + _currentCurrency.Cur_Abbreviation;

                ToCurrencyValue.Text = "??? " + _currentCurrency.Cur_Abbreviation;
                CurrencyAbreviationLabel.Text = _currentCurrency.Cur_Abbreviation;
            }
        }
        else
        {
            ErrorMessageLabel.Text = "Choose the currency first!";
            _currentCurrency = null;
        }

    }


    void OnConvertToCurrencyValueClicked(object sender, EventArgs e)
    {
        if (_currentCurrency != null)
        {
            try
            {
                if (ByEntry.Text.Contains(',')) ByEntry.Text = ByEntry.Text.Replace(',', '.');
                var sum = double.Parse(ByEntry.Text);
                ToCurrencyValue.Text = (sum / decimal.ToDouble(_currentCurrency.Cur_OfficialRate.Value) *
                    _currentCurrency.Cur_Scale).ToString("F2") + " " + _currentCurrency.Cur_Abbreviation;
                ErrorMessageLabel.Text = "";
            }
            catch
            {
                ErrorMessageLabel.Text = "Incorrect value in input of by sum!";
            }
        }
    }


    void OnConvertToByValueClicked(object sender, EventArgs e)
    {
        if (_currentCurrency != null)
        {
            try
            {
                if (CurrencyEnry.Text.Contains(',')) CurrencyEnry.Text = CurrencyEnry.Text.Replace(',', '.');
                var sum = double.Parse(CurrencyEnry.Text);
                ToByValue.Text = (sum * decimal.ToDouble(_currentCurrency.Cur_OfficialRate.Value) / _currentCurrency.Cur_Scale).ToString("F2") + " BY";
                ErrorMessageLabel.Text = "";
            }
            catch
            {
                ErrorMessageLabel.Text = "Incorrect value in input of currency sum!";
            }
        }
    }
}
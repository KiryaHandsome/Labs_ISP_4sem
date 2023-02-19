using System.Text.Json;
using System;
using Project.Services;

namespace Project;

public partial class CurrencyConventer : ContentPage
{
    List<String> _currencies = new List<string> { "Russian Ruble", "EURO",
        "US Dollar", "Swiss Franc", "Yuan China", "Pound Sterling" };
    List<int> ids = new List<int> { 141, 19, 145, 130, 28, 143 };

    List<String> _currenciesAbreviations = new List<String> { "RUB", "EUR", "USD", "CHF", "CNY", "GBP" };
    private IRateService _rateService;


    public CurrencyConventer(IRateService rateService)
    {
        InitializeComponent();
        _rateService = rateService;
    }

    void WhenLoaded(object sender, EventArgs e)
    {
        CurrencyPicker.ItemsSource = _currencies;
        CurrencyPicker.ItemsSource = CurrencyPicker.GetItemsAsArray();

        //_rateService.GetRates(DateTime.Now);
    }

    void OnGetCurrencyClicked(object sender, EventArgs e)
    {
        if (CurrencyPicker.SelectedItem != null) 
        {
            ErrorMessageLabel.Text = "";
            int index = CurrencyPicker.SelectedIndex;
            var item = _rateService.GetRates(DatePicker.Date).Where(r => r.Cur_Abbreviation.Equals(_currenciesAbreviations[index])).First();
            CurrencyLabel.Text = item.Cur_OfficialRate.ToString() + " " + item.Cur_Abbreviation;

            ToCurrencyValue.Text = "??? " + item.Cur_Abbreviation;
            CurrencyAbreviationLabel.Text = item.Cur_Abbreviation;
        } else
        {
            ErrorMessageLabel.Text = "Choose the currency first !";
        }
        
    }


    void OnCurrencyChosen(object sender, EventArgs e)
    {

    }
}
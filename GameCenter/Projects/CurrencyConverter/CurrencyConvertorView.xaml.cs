using GameCenter.Projects.CurrencyConverter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameCenter.Projects.CurrencyConverter
{
    /// <summary>
    /// Interaction logic for CurrencyConvertorView.xaml
    /// </summary>
    public partial class CurrencyConvertorView : Window
    {
        private CurrencyService _currencyService;
        private Dictionary<string,double> _exchangeRates;
        public CurrencyConvertorView()
        {
            InitializeComponent();
            _currencyService = new CurrencyService();
        }

        public async Task InitializeAsync()
        {
            await LoadCurrencies();
        }
        private async Task LoadCurrencies()
        {
            try
            {
                _exchangeRates = await _currencyService.GetExchangeRatesAsync();
                string[] currencies = _exchangeRates.Keys.ToArray();
                FromCurrencyComboBox.ItemsSource = currencies;
                ToCurrencyComboBox.ItemsSource = currencies;
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Error loading currencies: {ex.Message}");
            }
        }

        private double? ConvertCurrencyAmount(string? fromCurrency, string? toCurrency, double amount)
        {
            if(fromCurrency != null && toCurrency != null && _exchangeRates.ContainsKey(fromCurrency) && _exchangeRates.ContainsKey(toCurrency))
            {
                double baseToFromRate = _exchangeRates[fromCurrency];
                double baseToToRate = _exchangeRates[toCurrency];
                return (amount / baseToFromRate) * baseToToRate;
            }
            return null;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ? fromCurrency = FromCurrencyComboBox.SelectedItem.ToString();
                string ? toCurrency = ToCurrencyComboBox.SelectedItem.ToString();
                double amount;
                if (string.IsNullOrEmpty(AmountTextBox.Text) || !double.TryParse(AmountTextBox.Text, out amount))
                {
                    MessageBox.Show("Please enter a valid amount.");
                    return;
                }
                double ? convertedAmount = ConvertCurrencyAmount(fromCurrency, toCurrency, amount);
                if (convertedAmount.HasValue)
                {
                    txtResult.Text = $"Converted Amount: {amount} {fromCurrency} is {convertedAmount:0.00} {toCurrency}";
                }
                else
                {
                    MessageBox.Show("Selected Currency not available in the exchange rates.");
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show($"Error converting currencies: {ex.Message}");
            }

        }
    }
}

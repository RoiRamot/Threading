using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> primeList = new List<int>();
        private CancellationTokenSource cancelPrimeCalculationToken;
        private CancellationToken ct;


        private async void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            cancelPrimeCalculationToken = new CancellationTokenSource(); 
            ct = cancelPrimeCalculationToken.Token;
            CalculateButton.IsEnabled = false;
            int maxPrime;
            if (int.TryParse(PrimeTextBox.Text, out maxPrime))
            {
               var primes = await Task.Run(() => CalcPrimes(maxPrime), ct);
               if (primes != null)
                {
                    PrimeListBox.ItemsSource = primes;
                }
            }
            CalculateButton.IsEnabled = true;
        }

        private async void RunCalcPrimeAsync(int maxPrime)
        {
            await Task.Run(() => CalcPrimes(maxPrime), ct);
        }

        private IEnumerable<int> CalcPrimes(int maxPrime)
        {
            bool isPrime = true;
            var primes = new List<int> ();
            for (int i = 1; i <= maxPrime; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (ct.IsCancellationRequested)
                    {
                        return null;
                    }
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    primes.Add(i);
                }
                isPrime = true;
            }
            return primes;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            cancelPrimeCalculationToken.Cancel();
        }
    }

}

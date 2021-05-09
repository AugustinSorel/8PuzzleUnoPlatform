using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MagicSquare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int[] numbers;

        public MainPage()
        {
            this.InitializeComponent();

            foreach (var item in container.Children.Cast<Button>())
                item.Click += new RoutedEventHandler(Buttons_Click);

            SetUpNewGame();
        }

        private void SetUpNewGame()
        {
            // SetUp array
            numbers = new int[9];
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                while (true)
                {
                    int x = random.Next(0, 10);

                    if (!numbers.Contains(x))
                    {
                        numbers[i] = x;
                        break;
                    }
                }
            }

            // Display array
            int index = -1;
            foreach (var item in container.Children.Cast<Button>())
            {
                index++;
                item.Content = numbers[index] == 9 ? string.Empty : (object)numbers[index];
            }

        }

        private void Buttons_Click(object sender, RoutedEventArgs e)
        {
            SetUpNewGame();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace MagicSquare
{
    class GameEngine
    {
        private int[] numbers;

        public GameEngine()
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
    }
}

using System;
using System.Linq;

namespace MagicSquare
{
    class GameEngine
    {
        private int[] numbers;

        public int[] Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        public GameEngine()
        {
            PopulateArray();
        }

        private void PopulateArray()
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
        }
    }
}

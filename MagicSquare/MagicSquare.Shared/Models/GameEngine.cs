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

        internal bool CheckMove(int emptyCellTag, int buttonClickedTag, string buttonClickedContent)
        {
            if (buttonClickedContent == string.Empty)
                return false;

            if (buttonClickedTag == 2 && emptyCellTag == 3 || buttonClickedTag == 3 && emptyCellTag == 2)
                return false;

            if (buttonClickedTag == 5 && emptyCellTag == 6 || buttonClickedTag == 6 && emptyCellTag == 5)
                return false;

            if (Math.Abs(emptyCellTag - buttonClickedTag) == 3 || Math.Abs(emptyCellTag - buttonClickedTag) == 1)
                return true;

            return false;
        }
    }
}

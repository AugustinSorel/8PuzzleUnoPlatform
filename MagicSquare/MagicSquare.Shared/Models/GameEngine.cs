using System;
using System.Linq;

namespace MagicSquare
{
    class GameEngine
    {
        private int[] arrayOfRandomInegers;

        public int[] ArrayOfRandomIntegers
        {
            get { return arrayOfRandomInegers; }
            set { arrayOfRandomInegers = value; }
        }

        public GameEngine()
        {
            PopulateArray();
        }

        private void PopulateArray()
        {
            arrayOfRandomInegers = new int[9];
            Random random = new Random();

            for (int i = 0; i < arrayOfRandomInegers.Length; i++)
            {
                while (true)
                {
                    int x = random.Next(0, 10);

                    if (!arrayOfRandomInegers.Contains(x))
                    {
                        arrayOfRandomInegers[i] = x;
                        break;
                    }
                }
            }

            //for (int i = 1; i < arrayOfRandomInegers.Length; i++)
            //    ArrayOfRandomIntegers[i - 1] = i;
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

        internal void UpdateArray(int emptyCellTag, int buttonClickedTag, int value)
        {
            ArrayOfRandomIntegers[emptyCellTag] = value;
            ArrayOfRandomIntegers[buttonClickedTag] = 9;
        }

        internal bool CheckEndGame()
        {
            for (int i = 1; i < arrayOfRandomInegers.Length; i++)
                if (arrayOfRandomInegers[i-1] != i)
                    return false;

            return true;
        }
    }
}

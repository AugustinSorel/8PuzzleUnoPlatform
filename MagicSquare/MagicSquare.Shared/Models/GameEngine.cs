using System;
using System.Diagnostics;
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
                arrayOfRandomInegers[i] = -1;
                while (true)
                {
                    int x = random.Next(0, 9);

                    if (!arrayOfRandomInegers.Contains(x))
                    {
                        arrayOfRandomInegers[i] = x;
                        break;
                    }
                }
            }

            if (!Solvable())
            {
                PopulateArray();
            }

            for (int i = 0; i < arrayOfRandomInegers.Length; i++)
                ArrayOfRandomIntegers[i] = i;
        }

        private bool Solvable()
        {
            var inversions = 0;

            for (var i = 0; i < ArrayOfRandomIntegers.Length; i++){
                for (var j = i + 1; j < ArrayOfRandomIntegers.Length; j++){
                    if (ArrayOfRandomIntegers[j] > ArrayOfRandomIntegers[i])
                    {
                        inversions++;
                    }
                }
            }

            if (inversions % 2 == 1)
            {
                Debug.WriteLine("It's Unsolvable");
                return false;
            }
            else
            {
                Debug.WriteLine("It's Solvable");
                return true;
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

        internal void UpdateArray(int emptyCellTag, int buttonClickedTag, int value)
        {
            ArrayOfRandomIntegers[emptyCellTag] = value;
            ArrayOfRandomIntegers[buttonClickedTag] = 8;
        }

        internal bool CheckEndGame()
        {
            for (int i = 0; i < arrayOfRandomInegers.Length; i++)
                if (arrayOfRandomInegers[i] != i)
                    return false;// 0 -> empty string.

            return true;
        }
    }
}

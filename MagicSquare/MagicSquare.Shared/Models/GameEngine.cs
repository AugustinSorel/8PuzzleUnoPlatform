using System;
using System.Diagnostics;
using System.Linq;

namespace MagicSquare
{
    class GameEngine
    {
        private History History { get; set; }
        private int[] arrayOfRandomInegers;

        public int[] ArrayOfRandomIntegers
        {
            get { return arrayOfRandomInegers; }
            set { arrayOfRandomInegers = value; }
        }

        public GameEngine()
        {
            History = new History();
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

            ArrayOfRandomIntegers = new int[] { 1, 2, 3, 4, 5, 6, 7, 0, 8 };
            
            if (!Solvable())
            {
                PopulateArray();
            }
        }

        private bool Solvable()
        {
            int inversions = 0;

            for (int i = 0; i < ArrayOfRandomIntegers.Length - 1; i++)
            {
                for (int j = i + 1; j < ArrayOfRandomIntegers.Length; j++)
                    if (ArrayOfRandomIntegers[i] > ArrayOfRandomIntegers[j]) inversions++;

                if (ArrayOfRandomIntegers[i] == 0 && i % 2 == 1) 
                    inversions++;
            }

            return inversions % 2 != 1;
        }

        internal void AddHistory(MoveDetailStruct moveDetailStruct)
        {
            History.AddToUndoStack(moveDetailStruct);
        }

        internal bool CheckCanUndo()
        {
            return History.HandleUndo();
        }

        internal string GetCode()
        {
            return History.StackPop();
        }

        internal bool CheckMove(MoveDetailStruct moveDetailStruct)
        {
            if (moveDetailStruct.ButtonClickedContent == string.Empty)
                return false;

            if (moveDetailStruct.ButtonClickedTag == 2 && moveDetailStruct.EmptyCellTag == 3 || moveDetailStruct.ButtonClickedTag == 3 && moveDetailStruct.EmptyCellTag == 2)
                return false;

            if (moveDetailStruct.ButtonClickedTag == 5 && moveDetailStruct.EmptyCellTag == 6 || moveDetailStruct.ButtonClickedTag == 6 && moveDetailStruct.EmptyCellTag == 5)
                return false;

            if (Math.Abs(moveDetailStruct.EmptyCellTag - moveDetailStruct.ButtonClickedTag) == 3 || Math.Abs(moveDetailStruct.EmptyCellTag - moveDetailStruct.ButtonClickedTag) == 1)
                return true;

            return false;
        }

        internal void UpdateArray(MoveDetailStruct moveDetailStruct)
        {
            ArrayOfRandomIntegers[moveDetailStruct.EmptyCellTag] = int.Parse(moveDetailStruct.ButtonClickedContent);
            ArrayOfRandomIntegers[moveDetailStruct.ButtonClickedTag] = 0;

            foreach (var item in ArrayOfRandomIntegers)
            {
                Debug.Write(item + " ");
            }
            Debug.WriteLine("");
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

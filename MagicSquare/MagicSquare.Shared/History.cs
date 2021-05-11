using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MagicSquare
{
    internal class History
    {
        Stack<string> UndoStack { get; set; }

        public History()
        {
            UndoStack = new Stack<string>();
        }

        internal void AddToUndoStack(MoveDetailStruct moveDetailStruct)
        {
            string code = moveDetailStruct.ButtonClickedTag.ToString() + "," + moveDetailStruct.EmptyCellTag.ToString() + "," + moveDetailStruct.ButtonClickedContent;
            Debug.WriteLine(code);
            UndoStack.Push(code);
        }

        internal bool HandleUndo()
        {
            if (UndoStack.Count < 1)
                return false;

            return true;   
        }
    }
}
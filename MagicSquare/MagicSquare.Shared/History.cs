using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MagicSquare
{
    internal class History
    {
        Stack<string> UndoStack { get; set; }
        Stack<string> RedoStack { get; set; }

        public History()
        {
            UndoStack = new Stack<string>();
            RedoStack = new Stack<string>();
        }

        internal void AddToUndoStack(MoveDetailStruct moveDetailStruct)
        {
            string code = moveDetailStruct.ButtonClickedTag.ToString() + "," + moveDetailStruct.EmptyCellTag.ToString() + "," + moveDetailStruct.ButtonClickedContent;
            UndoStack.Push(code);
        }

        internal bool HandleUndo()
        {
            if (UndoStack.Count < 1)
                return false;

            return true;   
        }

        internal string StackUndoPop()
        {
            return UndoStack.Pop();
        }

        internal bool HandleRedo()
        {
            if (RedoStack.Count < 1)
                return false;

            return true;
        }

        internal void AddRedoToStack(string code)
        {
            RedoStack.Push(code);
        }

        internal string StackRedoPop()
        {
            return RedoStack.Pop();
        }

        internal void ClearRedoStack()
        {
            RedoStack.Clear();
        }
    }
}
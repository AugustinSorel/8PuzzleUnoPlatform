using System;
using System.Collections.Generic;

namespace MagicSquare
{
    internal class History
    {
        Stack<string> UndoStack { get; set; }

        public History()
        {
            UndoStack = new Stack<string>();
        }

        internal void AddToUndoStack()
        {
            UndoStack.Push("n");
        }
    }
}
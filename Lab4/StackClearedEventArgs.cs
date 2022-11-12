using System;

namespace Lab4
{
    public class StackClearedEventArgs : EventArgs
    {
        public string Message { get; }

        public StackClearedEventArgs(string message)
        {
            Message = message;
        }
    }
}
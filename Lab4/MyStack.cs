using System;
using System.Collections.Generic;

namespace Lab4
{
    public class MyStack
    {
        public event EventHandler<StackClearedEventArgs> StackCleared;
        private readonly List<char> _chars;

        public MyStack()
        {
            _chars = new List<char>();
            Size = 0;
        }

        public int Size { get; private set; }

        public bool IsEmpty => Size == 0;

        public void Push(char item)
        {
            _chars.Add(item);
            Size++;
        }

        public void Push(string item)
        {
            foreach (var ch in item)
            {
                Push(ch);
            }
        }

        public char Peek()
        {
            return Size != 0 ? _chars[Size - 1] : default;
        }

        public char Pop()
        {
            if (Size == 0) return default;

            var item = Peek();
            _chars.RemoveAt(--Size);

            if (IsEmpty)
            {
                OnStackCleared(new StackClearedEventArgs("Стек було очищенно шляхом видалення останнього елементу"));
            }

            return item;
        }

        public void Clear()
        {
            _chars.Clear();
            OnStackCleared(new StackClearedEventArgs("Стек було очищенно комадою Clear"));
        }

        protected virtual void OnStackCleared(StackClearedEventArgs args)
        {
            StackCleared?.Invoke(this, args);
        }
    }
}
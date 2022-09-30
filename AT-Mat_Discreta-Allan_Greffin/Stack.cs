using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Mat_Discreta_Allan_Greffin
{
    public class Stack<T>
    {
        public int Max { get; set; }
        public int Top { get; set; }
        public T[] Items { get; set; }

        public Stack()
        {
            Max = 20;
            Items = new T[Max];
            Top = -1;
        }

        public bool IsEmpty()
        {
            return (Top < 0);
        }

        public bool Push(T data)
        {
            if (Top >= Max)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                Items[++Top] = data;
                return true;
            }
        }

        internal T? Pop()
        {
            if (Top < 0)
            {
                //Console.WriteLine("Stack Underflow");
                return default(T);
            }
            else
            {
                T value = Items[Top--];
                return value;
            }
        }

        public void Display()
        {
            if (Top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
            {
                Console.WriteLine("Items in the Stack are :");
                for (int i = Top; i >= 0; i--)
                {
                    Console.WriteLine(Items[i]);
                }
            }
        }
    }
}

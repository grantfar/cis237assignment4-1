using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Class that stores data; First in first out
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyQueue<T>
    {
        private Node<T> Head, End;
        private int count;

        public int Count
        {
            get { return count; }
        }
        public MyQueue()
        {
            count = 0;
        }
        public void Add(T data)
        {
            Node<T> tmp = new Node<T>(data);
            if(Head == null)
            {
                Head = tmp;
                End = tmp;
            }
            else
            {
                End.Next = tmp;
                End = End.Next;
            }
            count++;
        }
        public T Get()
        {
            T toReturn = Head.Data;
            Head = Head.Next;
            count--;
            return toReturn;
        }
    }
}

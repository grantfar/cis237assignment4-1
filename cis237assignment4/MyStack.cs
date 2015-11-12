using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Stores data. first in last out
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyStack<T>
    {
        private Node<T> Head;
        private int count;

        public int Count
        {
            get { return count; }
        }
        public MyStack()
        {
            count = 0;
        }
        public void Add(T data)
        {
            Node<T> tmp = new Node<T>(data);
            tmp.Next = Head;
            Head = tmp;
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

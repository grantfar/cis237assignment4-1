using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public Node<T> Next
        {
            get;
            set;
        }
        public T Data
        {
            get;
            set;
        }
    }
}

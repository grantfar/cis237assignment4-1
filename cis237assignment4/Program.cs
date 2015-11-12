using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu theMenu = new Menu();
            while(true)
            {
                theMenu.DisplayUI();
            }
        }
    }
}

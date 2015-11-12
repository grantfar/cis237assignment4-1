using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class ProtocolDroid:Droid
    {
        private int numOfLanguages;
        private const decimal costPerLanguage = 300m;

        public int NumOfLanguages
        {
            get { return numOfLanguages; }
            set { numOfLanguages = value; }
        }

        protected ProtocolDroid(int NumLanguages, String Material, String Model, String Color): base(Material,Model,Color)
        {
            numOfLanguages = NumLanguages;
        }

        public ProtocolDroid(int NumLanguages, String Material, String Color)
            : base(Material, "protocol", Color)
        {
            numOfLanguages = NumLanguages;
            CalculateTotalCost();
        }
        
        /// <summary>
        /// calculates the cost of the droid
        /// based on the features it has
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.totalCost = base.baseCost + (numOfLanguages * costPerLanguage);
        }

        public override string ToString()
        {
            return base.ToString() + " supporting " + numOfLanguages + " languages Costing " + TotalCost + " Credits";
        }

        /// <summary>
        /// returns an instance of ProtocolDroid based of the prompts
        /// </summary>
        /// <returns></returns>
        public static new Droid CreateDroid()
        {
            string material, color;
            int numOfLanguagesTmp;

            Console.WriteLine("Please input the droids material");
            material = Console.ReadLine();
            
            Console.WriteLine("Please input the droids color");
            color = Console.ReadLine();
            
            Console.WriteLine("number of supported languages");
            while (!int.TryParse(Console.ReadLine(), out numOfLanguagesTmp))
            {
                int currentLineInt = Console.CursorTop -1;
                Console.SetCursorPosition(0, Console.CursorTop -1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineInt);
            }
            
            return new ProtocolDroid(numOfLanguagesTmp,material, color);
        }
    }
}

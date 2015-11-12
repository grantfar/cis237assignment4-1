using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class AstromechDroid:UtilityDroid
    {
        private bool fireExtinquisher;
        private int numberOfShips;
        private const decimal pricePerShip = 100m;

        public AstromechDroid(String material, String color, bool Toolbox, bool ComputerConnection, bool Arm, bool FireExtinquisher, int NumberOfShips)
            : base(material, "astromech", color, Toolbox, ComputerConnection, Arm)
        {
            fireExtinquisher=FireExtinquisher;
            numberOfShips=NumberOfShips;
            CalculateTotalCost();
        }
        /// <summary>
        /// calculates the cost of the droid
        /// based on the features it has
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (fireExtinquisher)
                base.totalCost += 150m;
            base.totalCost += decimal.Multiply(pricePerShip, numberOfShips);
        }

        /// <summary>
        /// this is a methiod to create the part of the toString that
        /// lists all the equiped options
        /// </summary>
        /// <returns></returns>
        protected override string optionsString()
        {
            string returnString = base.optionsString();
            if (returnString.Equals("no options") && fireExtinquisher)
            {
                    returnString = "a fire extinquisher";
            }
            else if(returnString.Contains("and") && fireExtinquisher)
            {
                returnString = returnString.Remove(returnString.IndexOf("and"), 4) + ", and a fire extinquisher";
            }
            else if(fireExtinquisher)
            {
                returnString += ", and a fire extinquisher";
            }
            return returnString;
        }

        /// <summary>
        /// returns an instance of AstromechDroid based of the prompts
        /// </summary>
        /// <returns></returns>
        public static new Droid CreateDroid()
        {
            bool toolBoxTmp, computerConnectionTmp, armTmp, fireExtinquisherTmp;
            string material, color;
            int shipsSupportedTmp;
            
            Console.WriteLine("Please input the droids material");
            material = Console.ReadLine();
            
            Console.WriteLine("Please input the droids color");
            color = Console.ReadLine();
            
            Console.WriteLine("has a toolbox? (y/n)");
            toolBoxTmp = Droid.yesOrNo();
            
            Console.WriteLine("has a computer connection? (y/n)");
            computerConnectionTmp = Droid.yesOrNo();
            
            Console.WriteLine("has a arm? (y/n)");
            armTmp = Droid.yesOrNo();
            
            Console.WriteLine("has a fireExtinquisher? (y/n)");
            fireExtinquisherTmp = Droid.yesOrNo();
            
            Console.WriteLine("number of supported ships");
            //prevents bad input
            while(!int.TryParse(Console.ReadLine(),out shipsSupportedTmp))
            {
                //deletes bad input from the console
                int currentLineInt = Console.CursorTop - 1;
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineInt);
            }
            
            return new AstromechDroid(material, color, toolBoxTmp, computerConnectionTmp, armTmp,fireExtinquisherTmp,shipsSupportedTmp);
        }
        
        public override string ToString()
        {
            String returnString = base.ToString();
            //removes the base option string and adds its own
            return returnString.Substring(0, returnString.IndexOf("with") + 5) + optionsString() + ", suporting " + numberOfShips + " ships Costing " + TotalCost + " Credits";
        }
    }
}

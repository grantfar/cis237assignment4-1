using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class UtilityDroid : Droid
    {
        private bool toolBox, computerConnection, arm;
        public UtilityDroid(String material, String color, bool Toolbox, bool ComputerConnection, bool Arm) : base(material, "utility", color) 
        {
            toolBox = Toolbox;
            computerConnection = ComputerConnection;
            arm = Arm;
            CalculateTotalCost();
        }
        /// <summary>
        /// only for extending this class
        /// </summary>
        /// <param name="material"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="Toolbox"></param>
        /// <param name="ComputerConnection"></param>
        /// <param name="Arm"></param>
        protected UtilityDroid(String material, String model, String color, bool Toolbox, bool ComputerConnection, bool Arm): base(material, model, color) 
        {
            toolBox = Toolbox;
            computerConnection = ComputerConnection;
            arm = Arm;
        }

        /// <summary>
        /// calculates the cost of the droid
        /// based on the features it has
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.totalCost = base.baseCost;
            if(toolBox)
                base.totalCost += 500m;
            if(computerConnection)
                base.totalCost += 700m;
            if (arm)
                base.totalCost += 300m;
        }
        /// <summary>
        /// this is a methiod to create the part of the toString that
        /// lists all the equiped options
        /// </summary>
        /// <returns></returns>
        protected virtual string optionsString()
        {
            List<String> returnStrings = new List<string>();
            String returnString = "";
            if (!(toolBox || computerConnection || arm))
                return "no options";
            if (toolBox)
                returnStrings.Add("a toolbox");
            if (computerConnection)
                returnStrings.Add("a computer connections");
            if (arm)
                returnStrings.Add("an arm");
            for(int i = 0; i < returnStrings.Count-1; i++)
                returnString += returnStrings[i] + ", "; 
            if (returnStrings.Count != 1)
                returnString += "and ";
            returnString += returnStrings[returnStrings.Count - 1];
            return returnString;
        }
        public override string ToString()
        {
            return base.ToString() + " with " + optionsString() + " Costing " + TotalCost + " Credits";
        }

        /// <summary>
        /// returns an instance of UtilityDroid based of the prompts
        /// </summary>
        /// <returns></returns>
        public static new Droid CreateDroid()
        {
            bool toolBoxTmp, computerConnectionTmp, armTmp;
            string material, color;
            
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
            
            return new UtilityDroid(material, color, toolBoxTmp, computerConnectionTmp, armTmp);
        }
    }
}

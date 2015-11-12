using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class JanitorDroid:UtilityDroid
    {
        private bool vacuum, trashCompactor;
        public JanitorDroid(String material, String color, bool Toolbox, bool ComputerConnection, bool Arm, bool TrashCompacter, bool Vacuum)
            : base(material, "Janitor", color, Toolbox, ComputerConnection, Arm)
        {
            vacuum = Vacuum;
            trashCompactor = TrashCompacter;
            CalculateTotalCost();
        }
        /// <summary>
        /// Used for extending the class
        /// </summary>
        /// <param name="material"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="Toolbox"></param>
        /// <param name="ComputerConnection"></param>
        /// <param name="Arm"></param>
        /// <param name="TrashCompacter"></param>
        /// <param name="Vacuum"></param>
        protected JanitorDroid(String material,String model,String color, bool Toolbox, bool ComputerConnection, bool Arm, bool TrashCompacter, bool Vacuum)
            : base(material, model,color, Toolbox, ComputerConnection, Arm)
        {
            vacuum = Vacuum;
            TrashCompacter = trashCompactor;
        }
        
        /// <summary>
        /// calculates the cost of the droid
        /// based on the features it has
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (vacuum)
                base.totalCost += 50m;
            if (trashCompactor)
                base.totalCost += 200m;
        }
        /// <summary>
        /// this is a methiod to create the part of the toString that
        /// lists all the equiped options
        /// </summary>
        /// <returns></returns>
        protected override string optionsString()
        {
            List<String> returnStrings = new List<string>();
            string returnString = base.optionsString();
            bool moreThan1 = false;
            if (returnString.Equals("no options"))
            {
                returnString = "";
                
            }
            else if(returnString.Contains("and"))
            {
                returnString = returnString.Remove(returnString.IndexOf("and"), 4);
                moreThan1 = true;
            }
            moreThan1 = moreThan1 || (vacuum && trashCompactor);
            if (!(moreThan1 || vacuum || trashCompactor))
                return "no options";
            if (vacuum)
                returnStrings.Add("a Vacuum, ");
            if (trashCompactor)
                returnStrings.Add("a Trash Compacter");
            for (int i = 0; i < returnStrings.Count - 1; i++)
                returnString += returnStrings[i] + ", ";
            if (returnStrings.Count != 1 || moreThan1)
                returnString += "and ";
            returnString += returnStrings[returnStrings.Count - 1];
            return returnString;
        }
        public override string ToString()
        {
            String returnString = base.ToString();
            return returnString.Substring(0, returnString.IndexOf("with") + 5) + optionsString() + " Costing " + TotalCost + " Credits";
        }

        /// <summary>
        /// returns an instance of JanitorDroid based of the prompts
        /// </summary>
        /// <returns></returns>
        public static new Droid CreateDroid()
        {
            bool toolBoxTmp, computerConnectionTmp, armTmp, vacuumTmp, trashCompactorTmp;
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
            
            Console.WriteLine("has a vacuum? (y/n)");
            vacuumTmp = Droid.yesOrNo();
            
            Console.WriteLine("has a trash compactor? (y/n)");
            trashCompactorTmp = Droid.yesOrNo();
            
            return new JanitorDroid(material, color, toolBoxTmp, computerConnectionTmp, armTmp,trashCompactorTmp,vacuumTmp);
        }
    }
}

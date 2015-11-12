using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    abstract class Droid: IDroid,IComparable
    {
        private string material, model, color;
        protected decimal totalCost;
        protected decimal baseCost;
        public Droid(String Material, String Model, String Color)
        {
            CalculateBaseCost(new droidModelPrice[] { new droidModelPrice("astromech", 1100m), new droidModelPrice("protocol", 1500m), new droidModelPrice("janitor", 1000m), new droidModelPrice("utility", 800m) });
            material = Material;
            model = Model;
            color = Color;
        }
        
        protected void CalculateBaseCost(droidModelPrice[] droidCosts)
        {
            foreach(droidModelPrice d in droidCosts)
                if (d.model.Equals(model))
                    baseCost = d.price;
        }
        
        public abstract void CalculateTotalCost();
        
        public decimal TotalCost
        {
            get
            {
                return totalCost;
            }
            set
            {
                totalCost = value;
            }
        }
        
        public override string ToString()
        {
            return "a " + color + " " + material + " " + model + " droid";
        }
        
        /// <summary>
        /// A methiod for creating droids
        /// </summary>
        /// <returns></returns>
        
        public static Droid CreateDroid()
        {
            return null;
        }
        
        /// <summary>
        /// This is a methiod for yes or no inputs
        /// </summary>
        /// <returns></returns>
        protected static bool yesOrNo()
        {
            //random char
            char pressed = 'u';
            while(!(pressed == 'y' || pressed == 'Y' || pressed == 'n' || pressed == 'N'))
            {
                //deletes the previous keypress from the console
                int currentLineInt = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', 1));
                Console.SetCursorPosition(0, currentLineInt);
                
                pressed = Console.ReadKey().KeyChar;
            }
            Console.WriteLine("");
            //returns true if yes
            return pressed == 'y' || pressed == 'Y';
        }

        public int CompareTo(object obj)
        {
            return this.TotalCost.CompareTo(((Droid)obj).TotalCost);
        }
    }
}

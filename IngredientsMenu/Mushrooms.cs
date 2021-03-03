using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.IngredientsMenu
{
    class Mushrooms : Ingredient
    {
        public Mushrooms(double portion) : base(portion)
        {
            name = "Mushrooms";
            cost_portion = 5; //mxn pesos
            this.portion = portion;
        }

        public override double finalCost()
        {
            return cost_portion * portion;
        }

        public override string finalOrder()
        {
            return name + " (" + portion + " Portion(s)) $ "+finalCost() +" ";
        }
        public override double setCostPortion(double cost) => this.cost_portion = cost;
        public override double getCostPortion() => this.cost_portion;
    }
}

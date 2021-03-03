using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.IngredientsMenu
{
    class Bacon : Ingredient
    {
        public Bacon(double portion) : base(portion)
        {
            name = "Bacon";
            cost_portion = 10; //mxn pesos
            this.portion = portion;
        }

        public override double finalCost()
        {
            return cost_portion * portion;
        }

        public override string finalOrder()
        {
            return name + " (" + portion + " Portion(s)) $ " + finalCost() + " ";
        }

        public override double getCostPortion() => this.cost_portion;

        public override double setCostPortion(double cost) => this.cost_portion = cost;
       
    }
}

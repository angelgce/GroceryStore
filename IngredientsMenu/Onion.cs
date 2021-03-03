using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.IngredientsMenu
{
    class Onion : Ingredient
    {
        private String descount = " ";
        public Onion(double portion) : base(portion)
        {
            name = "Onion";
            cost_portion = 20; //mxn pesos
            this.portion = portion;
        }

        public override double finalCost()
        {
            if (portion > 5) { cost_portion = cost_portion / 3; descount = " \nyou got a discount on onions"; }
            return cost_portion * portion;
        }

        public override string finalOrder()
        {
            return name + " (" + portion + " Portion(s)) $ " + finalCost() + descount;
        }
        public override double setCostPortion(double cost) => this.cost_portion = cost;
        public override double getCostPortion() => this.cost_portion;
    }
}

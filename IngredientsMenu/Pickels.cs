using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.IngredientsMenu
{
    class Pickels : Ingredient
    {
        

        public Pickels(double portion) : base(portion)
        {
            name = "Pickels";
            cost_portion = 2; //mxn pesos
            this.portion = portion;
        }


        public override double finalCost()
        {
            return cost_portion * portion;
        }

        public override string finalOrder()
        {
           return name + " $" + finalCost() + "MXN (" + portion + " Portion(s)) \n" ;
        }
        public override double setCostPortion(double cost) => this.cost_portion = cost;
        public override double getCostPortion() => this.cost_portion;
    }
}

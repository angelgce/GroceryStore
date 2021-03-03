using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore
{
    abstract class Ingredient
    {
        protected String name;
        protected double cost_portion;
        protected double portion;
        protected double final_cost;
        

        public Ingredient(double portion)
        {
            this.portion = portion;
            this.final_cost = finalCost();
        }

        public abstract double setCostPortion(double cost);
        public abstract double getCostPortion();
        public abstract double finalCost();

        public abstract String finalOrder();
 
    }
}

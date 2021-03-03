using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.FoodMenu
{
    class Pizza : Food
    {
        private readonly int finalCost = 200;
        public Pizza(string name, double size) : base(name, size)
        {
            this.name = name;
            this.size = size;
            this.cost = finalCost;
        }

        public override string getName() => this.name;
        public override double getSize() => this.size;
        public override List<Ingredient> getIngredient() => this.ingredients;

        public override void addIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public override void removeIngredient()
        {
        }

        public override double ingredientCosts()
        {
            List<double> list_cost = new List<double>();
            ingredients.ForEach(ingredient => list_cost.Add(ingredient.finalCost()));
            return list_cost.Aggregate((x, y) => x + y);
        }


        public override StringBuilder myFinalOrder()
        {
            double extra = ingredientCosts();
            StringBuilder txt = new StringBuilder();
            txt.Append("Total : " +(my_cost() +extra));
            return txt;
        }

        public override double my_cost()
        {
            cost = finalCost;
            return cost+= size * 25 ;
        }

        
     
    }
}

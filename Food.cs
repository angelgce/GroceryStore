using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore
{
    abstract class Food
    {
        protected String name;
        protected double size;
        protected double cost;
        protected List<Ingredient> ingredients = new List<Ingredient>();

        protected Food(string name, double size)
        {
            this.name = name;
            this.size = size;
        }

        public abstract string getName() ;
        public abstract double getSize();
        public abstract List<Ingredient> getIngredient();
        public abstract double my_cost();
        public abstract void addIngredient(Ingredient ingrediet);
        public abstract void removeIngredient();
        public abstract double ingredientCosts();
        public abstract StringBuilder myFinalOrder();
    }
}

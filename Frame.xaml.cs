using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroceryStore
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean stop = false;
        private int my_select = -1;
        private Ingredient ingredient;
        private Food food;
        private List<Control> controls = new List<Control>();
        private StringBuilder order_txt = new StringBuilder();
        private StringBuilder ingre_txt = new StringBuilder();
        List<RadioButton> ingredients_list = new List<RadioButton>();
        private int size_checked;
        private String size_txt;
        private int ingredient_checked;
        private String ingredient_txt;
        private Boolean dish = false;
        public MainWindow()
        {

            InitializeComponent();
            food_combo.Items.Add("Pizza");
            food_combo.Items.Add("Hamburger");
            food_combo.Items.Add("Hotdog");
            controls.Add(small_box);
            controls.Add(medium_box);
            controls.Add(large_box);
            controls.Add(add_food);
            controls.Add(add_ingredient);
            controls.Add(ingredient_value);
            controls.Add(ingredient_group);
            controls.Add(bacon_radio);
            controls.Add(mushrooms_radio);
            controls.Add(onion_radio);
            controls.Add(pepperoni_radio);
            controls.Add(pickels_radio);
            controls.Add(pineApple_radio);
            controls.ForEach(item => item.Visibility = Visibility.Hidden);

            (new Thread(() =>
            {
                while (!stop)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (food_combo.SelectedIndex > -1 && food_combo.SelectedIndex != my_select)
                        {
                            restart();
                            if (!controls[0].IsVisible) { controls.ForEach(item => item.Visibility = Visibility.Visible); }
                            imageBox.Source = new BitmapImage(new Uri("/FoodMenu/" + food_combo.Text + ".png", UriKind.RelativeOrAbsolute));
                            my_select = food_combo.SelectedIndex;

                        }

                        addFood();
                        addIngredient();
                    });


                }
            })).Start();


        }

        private void restart()
        {
            total_label.Content = "";
            total_label.Visibility = Visibility.Hidden;
            dish = false;
            order_txt = new StringBuilder();
            ticket_box.Content = "";
            ingredient_value.Text = "0";
            ingredients_list.ForEach(ingredient => ingredient.IsChecked = false);


        }

        private void addFood()
        {
            Boolean ischecked = false;
            List<RadioButton> sizes = new List<RadioButton>();
            sizes.Add(small_box);
            sizes.Add(medium_box);
            sizes.Add(large_box);
            sizes.ForEach(radio => { if (radio.IsChecked == true) { ischecked = true; size_txt = radio.Content.ToString(); } });
            size_checked = sizes.FindIndex(radio => radio.IsChecked == true);
            if (ischecked && !dish) { add_food.IsEnabled = true; } else { add_food.IsEnabled = false; }

        }

        private void addIngredient()
        {

            ingredients_list = new List<RadioButton>();
            ingredients_list.Add(bacon_radio);
            ingredients_list.Add(mushrooms_radio);
            ingredients_list.Add(onion_radio);
            ingredients_list.Add(pepperoni_radio);
            ingredients_list.Add(pickels_radio);
            ingredients_list.Add(pineApple_radio);
            ingredients_list.ForEach(ingredient => { if (ingredient.IsChecked == true) { size_txt = ingredient.Content.ToString(); } });
            ingredient_checked = ingredients_list.FindIndex(ingredient => ingredient.IsChecked == true);

        }


        private void strategy()
        {

            switch (food_combo.SelectedIndex)
            {
                case 0:
                    food = new FoodMenu.Pizza("Pizza", size_checked);
                    break;
                case 1:
                    food = new FoodMenu.Hamburger("Burger", size_checked);
                    break;
                case 2:
                    food = new FoodMenu.Hotdog("Hotdog", size_checked);
                    break;
            }

            order_txt.Append(food.getName() + " " + size_txt + " $" + food.my_cost());
            ticket_box.Content = order_txt;
            add_food.IsEnabled = false;
            dish = true;
            add_ingredient.IsEnabled = true;


        }
        private double portions = 0;
        private Ingredient strategy2()
        {

            switch (ingredient_checked)
            {
                case 0:
                    ingredient = new IngredientsMenu.Bacon(portions);
                    break;
                case 1:
                    ingredient = new IngredientsMenu.Mushrooms(portions);
                    break;
                case 2:
                    ingredient = new IngredientsMenu.Onion(portions);
                    break;
                case 3:
                    ingredient = new IngredientsMenu.Pepperoni(portions);
                    break;
                case 4:
                    ingredient = new IngredientsMenu.Pickels(portions);
                    break;
                case 5:
                    ingredient = new IngredientsMenu.Pineapple(portions);
                    break;
            };
            return ingredient;
        }



        private void add_food_Click(object sender, RoutedEventArgs e) => strategy();

        private void add_ingredient_Click(object sender, RoutedEventArgs e)
        {
            try { portions = Convert.ToDouble(ingredient_value.Text); } catch { ingredient_value.Text = "0"; }

            if (portions > 0)
            {
                food.addIngredient(strategy2());
                ingre_txt = new StringBuilder();
                ingre_txt.Append(order_txt + "\n");
                food.getIngredient().ForEach(ingre => ingre_txt.Append(ingre.finalOrder() + "\n"));
                ticket_box.Content = ingre_txt;
                total_label.Visibility = Visibility.Visible;
                total_label.Content = food.myFinalOrder();
            }


        }


    }
}

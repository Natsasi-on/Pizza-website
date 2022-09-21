using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class ToppingsLists
    {
        public static List<Toppings> GetAvailableToppings()
        {
            List<Toppings> toppings = new List<Toppings>();

            Toppings mytoppings = new Toppings("TP001", "Mushrooms");
            mytoppings.Price = 3;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            mytoppings = new Toppings("TP002", "Green Olives");
            mytoppings.Price = 2;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            mytoppings = new Toppings("TP003", "Green Peppers");
            mytoppings.Price = 2;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            mytoppings = new Toppings("TP004", "Pineapple");
            mytoppings.Price = 3;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            mytoppings = new Toppings("TP005", "Bacon Strips");
            mytoppings.Price = 5;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            mytoppings = new Toppings("TP006", "Butter Chicken");
            mytoppings.Price = 8;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            mytoppings = new Toppings("TP007", "Pepperoni");
            mytoppings.Price = 3;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            mytoppings = new Toppings("TP008", "Italian Ham");
            mytoppings.Price = 4;
            mytoppings.getDiscount();
            toppings.Add(mytoppings);

            return toppings;
        }

        public static Toppings GetToppingsByCode(string code)
        {
            foreach (Toppings c in GetAvailableToppings())
            {
                if (c.Code == code)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
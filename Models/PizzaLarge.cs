using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class PizzaLarge : Customer
    {
        public static int MaxNumOfToppings { get; set; }
        public static double MaxToppingsPrice { get; set; }

        public static bool Discount { get; set; }




        public PizzaLarge(string name, string email, int distance)
            :base(name, email,distance)
        {

        }


        public override void ToppingsSelected(List<Toppings> selectedToppings)
        {
            base.ToppingsSelected(selectedToppings);

            if (selectedToppings.Count > MaxNumOfToppings)
            {
                throw new Exception("The Maximum number of toppings for Large size is : 4");
            }
            else if(TotalPrice() > MaxToppingsPrice)
            {
                throw new Exception("The Maximum price of toppings for Large size is : 15");
            }
            else
            {
                base.ToppingsSelected(selectedToppings);
            }
        }
       

        public override string ToString()
        {
            return string.Format("{0} - {1} (Large Pizza)", Id, Name);
        }
    }
}
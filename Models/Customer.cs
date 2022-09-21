using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public int Distance { get; }

        public List<Toppings> ConfirmToppings { get; }




        public Customer(string name, string email, int distance)
        {
            Name = name;

            Random randomNumber = new Random();
            string IDString = "4" + Convert.ToString(randomNumber.Next(1000000));
            int myid = Convert.ToInt32(IDString);
            Id = myid;

            ConfirmToppings = new List<Toppings>();

            Email = email;

            Distance = distance;
        }


        public virtual void ToppingsSelected(List<Toppings> selectedToppings)
        {
            ConfirmToppings.Clear();
            ConfirmToppings.AddRange(selectedToppings);
        }


        public int TotalPrice()
        {
            int totalPrice = 0;

            foreach (Toppings topping in ConfirmToppings)
            {
                var getToppings = ToppingsLists.GetToppingsByCode(topping.Code);

                totalPrice += getToppings.Price;
            }
            return totalPrice;
        }       
    }
}
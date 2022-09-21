using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Final.Models;

namespace Final
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            PizzaSmall.MaxNumOfToppings = 2;
            PizzaSmall.MaxToppingsPrice = 5;
            PizzaMedium.MaxNumOfToppings = 3;
            PizzaMedium.MaxToppingsPrice = 10;
            PizzaLarge.MaxNumOfToppings = 4;
            PizzaLarge.MaxToppingsPrice = 15;
            PizzaLarge.Discount = false;
            PizzaSmall.Discount = false;
            PizzaMedium.Discount = false;
        }
    }
}
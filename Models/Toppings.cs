using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Toppings
    {
        private string code;
        private string title;
        private int price;
        public bool Discount { get; }



        public Toppings(string code, string title)
        {
            this.code = code;
            this.title = title;
        }

        public string Code { get { return code; } }
        public string Title { get { return title; } }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public bool getDiscount()
        {
            return false;
        }
        
    }
}
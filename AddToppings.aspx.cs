using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final.Models;

namespace Final
{
    public partial class AddToppings : System.Web.UI.Page
    {
        int totalPrice = 0;
        List<Toppings> selectedToppings = new List<Toppings>();
        List<Toppings> selectedToppings1 = new List<Toppings>();
        List<Customer> customerList = new List<Customer>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                btnSubmit.Enabled = false;
                foreach (Toppings t in ToppingsLists.GetAvailableToppings())
                {
                    chklst.Items.Add(new ListItem($"{t.Title} - {t.Price} dollars", t.Code));
                }

                if (Session["customerSession"] != null)
                {
                    customerList = (List<Customer>)Session["customerSession"];
                    foreach (Customer theCustomer in customerList)
                    {
                        drpAddedCustomer.Items.Add(theCustomer.ToString());
                    }
                }
            }
        }


        protected void chklst_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSum.Visible = false;
            lblSumBottom.Visible = false;
            if (drpAddedCustomer.SelectedIndex == 0)
            {
                lblerrorMsg.Visible = false;
                lblsumMsg.Visible = false;
            }
            else
            {
                btnSubmit.Enabled = false;
                getSeletedToppings();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (drpAddedCustomer.SelectedIndex == 0)
            {
                lblerrorMsg.Visible = false;
                lblsumMsg.Visible = false;
                lblSumBottom.Visible = false;
                lblSum.Visible = false;
            }
            else
            {
                getSeletedToppings();
                btnSubmit.Enabled = true;

                Session.Add(drpAddedCustomer.SelectedValue, drpAddedCustomer.SelectedIndex);
                Session.Add("Toppings For" + drpAddedCustomer.SelectedValue, selectedToppings);
            }
        }


        protected void drpAddedCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerrorMsg.Visible = false;
            lblsumMsg.Visible = false;
            lblSumBottom.Visible = false;
            lblSum.Visible = false;

            if (drpAddedCustomer.SelectedIndex == 0)
            {
            }

            if (Session[drpAddedCustomer.SelectedValue] == null)
            {
                chklst.ClearSelection();
                btnSubmit.Enabled = false;
            }
            else
            {
                chklst.ClearSelection();
                btnSubmit.Enabled = true;

                int customerID = (int)Session[drpAddedCustomer.SelectedValue];
                if (drpAddedCustomer.SelectedIndex == customerID)
                {
                    selectedToppings1 = (List<Toppings>)Session["Toppings For" + drpAddedCustomer.SelectedValue];
                    foreach (ListItem lstItem in chklst.Items)
                    {
                        foreach (Toppings topping in selectedToppings1)
                        {
                            if (lstItem.Value == topping.Code)
                            {
                                lstItem.Selected = true;
                            }
                        }

                    }
                    getSeletedToppings();
                }
                
            }
        }

        public void getSeletedToppings()
        {
            foreach (ListItem lstItem in chklst.Items)
            {
                if (lstItem.Selected == true)
                {
                    Toppings myToppings = new Toppings(lstItem.Value, lstItem.Text);
                    selectedToppings.Add(myToppings);

                    Toppings myselectedToppings = ToppingsLists.GetToppingsByCode(myToppings.Code);

                    totalPrice += myselectedToppings.Price;
                }
            }
            lblerrorMsg.Visible = false;
            lblSumBottom.Visible = false;
            lblSum.Visible = false;
            lblsumMsg.Visible = true;
            lblsumMsg.Text = $"Seleted Customer has chosen {selectedToppings.Count} Toppings, and the price is {totalPrice} dollars.";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (drpAddedCustomer.SelectedIndex == 0)
            {
                lblerrorMsg.Visible = false;
                lblsumMsg.Visible = false;
                lblSumBottom.Visible = false;
                lblSum.Visible = false;
            }

            foreach (ListItem lstItem in chklst.Items)
            {
                if (lstItem.Selected == true)
                {
                    Toppings myToppings = new Toppings(lstItem.Value, lstItem.Text);
                    selectedToppings.Add(myToppings);
                }
            }

            if (selectedToppings.Count == 0)
            {
                lblsumMsg.Visible = false;
                lblerrorMsg.Visible = true;
                lblSumBottom.Visible = false;
                lblSum.Visible = false;
                lblerrorMsg.Text = "You must select at least one topping.";
            }
            else
            {
                try
                {
                    customerList = (List<Customer>)Session["customerSession"];
                    customerList[drpAddedCustomer.SelectedIndex - 1].ToppingsSelected(selectedToppings);

                    lblsumMsg.Visible = true;
                    lblsumMsg.Text = "The order is completed!!!" + "<br />" + $"Seleted Customer has chosen {selectedToppings.Count} Toppings, and the price is {customerList[drpAddedCustomer.SelectedIndex - 1].TotalPrice()} dollars.";
                    lblerrorMsg.Visible = false;


                    string sumToppings = "";
                    foreach (Toppings lstsum in customerList[drpAddedCustomer.SelectedIndex - 1].ConfirmToppings)
                    {
                        sumToppings += lstsum.Title + " ";
                    }
                    lblSumBottom.Visible = true;
                    lblSum.Visible = true;
                    lblSumBottom.Text =
                        "Customer : " + $" {customerList[drpAddedCustomer.SelectedIndex - 1]}" + "<br />" +
                        "Email : " + $" {customerList[drpAddedCustomer.SelectedIndex - 1].Email}" + "<br />" +
                        "Distance : " + $" {customerList[drpAddedCustomer.SelectedIndex - 1].Distance}" + " km" + "<br />" +
                        "Toppings Selected : " + $" {sumToppings}" + "<br />" +
                        "Toppings Price : " + $" {customerList[drpAddedCustomer.SelectedIndex - 1].TotalPrice()}" + " dollars";
                }
                catch (Exception ee)
                {
                    lblsumMsg.Visible = false;
                    lblerrorMsg.Visible = true;
                    lblerrorMsg.Text = ee.Message;
                    lblSumBottom.Visible = false;
                    lblSum.Visible = false;
                }
            }
        }
    }
}
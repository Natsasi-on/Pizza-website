using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final.Models;

namespace Final
{
    public partial class Register : System.Web.UI.Page
    {
        List<Customer> customerList = new List<Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            drpPizzaSize.Items.Add("Small");
            drpPizzaSize.Items.Add("Medium");
            drpPizzaSize.Items.Add("Large");
            rdbMemberType.Items.Add("Not a Member");
            rdbMemberType.Items.Add("Silver Member");
            rdbMemberType.Items.Add("Gold Member");

            if (Session["customerSession"] == null)
            {

            }
            else
            {
                mytblRow.Visible = false;
                customerList = (List<Customer>)Session["customerSession"];

                foreach (Customer myCustomer in customerList)
                {
                    TableRow newRow = null;
                    TableCell newCell = null;

                    newRow = new TableRow();
                    newRow = new TableRow();
                    tblCustomer.Rows.Add(newRow);

                    newCell = new TableCell();
                    newRow.Cells.Add(newCell);
                    newCell.Text = myCustomer.Id.ToString();

                    newCell = new TableCell();
                    newRow.Cells.Add(newCell);
                    newCell.Text = myCustomer.Name;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "")
            {

            }
            else
            {
                if (drpPizzaSize.SelectedValue == "Small")
                {
                    string nameCustomer = txtCustomerName.Text;
                    txtCustomerName.Text = "";
                    drpPizzaSize.SelectedIndex = 0;

                    customerList.Add(new PizzaSmall(nameCustomer, txtEmail.Text,Convert.ToInt32(txtDistance.Text)));

                }
                else if (drpPizzaSize.SelectedValue == "Medium")
                {
                    string nameCustomer = txtCustomerName.Text;
                    txtCustomerName.Text = "";
                    drpPizzaSize.SelectedIndex = 0;

                    customerList.Add(new PizzaMedium(nameCustomer, txtEmail.Text, Convert.ToInt32(txtDistance.Text)));
                }
                else if (drpPizzaSize.SelectedValue == "Large")
                {
                    string nameCustomer = txtCustomerName.Text;
                    txtCustomerName.Text = "";
                    drpPizzaSize.SelectedIndex = 0;

                    customerList.Add(new PizzaLarge(nameCustomer, txtEmail.Text, Convert.ToInt32(txtDistance.Text)));
                }
                Session["customerSession"] = customerList;
                Response.Redirect("Register.aspx");
            }
        }
    }
}
<%@ Page Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="True" CodeBehind="Register.aspx.cs" Inherits="Final.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/css/styles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Register</h2>
    <div class="grid-3-colum">
        <div><asp:Label runat="server" Text="Customer Name:"></asp:Label></div>
        <div><asp:TextBox ID="txtCustomerName" runat="server" CssClass="input"></asp:TextBox></div>
        <div>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtCustomerName"
                ForeColor="Red" Display="Dynamic">Required!</asp:RequiredFieldValidator>
        </div>


        <div><asp:Label runat="server" Text="Customer Email:"></asp:Label></div>
        <div><asp:TextBox ID="txtEmail" runat="server" class="input"></asp:TextBox></div>
        <div>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" ErrorMessage="Required!"></asp:RequiredFieldValidator>
        </div>
        
        <div><asp:Label runat="server" Text="Confirm Email:"></asp:Label></div>
        <div><asp:TextBox ID="txtConfirmEmail" runat="server" class="input"></asp:TextBox></div>
        <div>
            <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ControlToValidate="txtConfirmEmail"
                ForeColor="Red" Display="Dynamic" ErrorMessage="Required!"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvConfirmEmail" runat="server" ErrorMessage="Email addresses do not match!"
                ControlToValidate="txtConfirmEmail" ControlToCompare="txtEmail"
                Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
        </div>


        <div><asp:Label runat="server" Text="Pizza Size:"></asp:Label></div>
        <div>
            <asp:DropDownList ID="drpPizzaSize" runat="server" CssClass="input2">
                <asp:ListItem Value="-1" Text="Select ..."></asp:ListItem>     
            </asp:DropDownList>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="rfvPizzaSize" runat="server"
                ErrorMessage="Must select one!"
                ForeColor="Red" ControlToValidate="drpPizzaSize"
                InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>


        <div><asp:Label runat="server" Text="Restaurant Membership:"></asp:Label></div>
        <div><asp:RadioButtonList ID="rdbMemberType" runat="server"></asp:RadioButtonList></div>
        <div></div>


        <div><asp:Label runat="server" Text="Check for delivery?:"></asp:Label></div>
        <div><asp:TextBox ID="txtDistance" runat="server" CssClass="input" placeholder="2 km"></asp:TextBox></div>
        <div>
            <asp:RequiredFieldValidator ID="rfvDistance" runat="server" ControlToValidate="txtDistance"
                ForeColor="Red" Display="Dynamic">Can not be blank!</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvDistance" runat="server" ControlToValidate="txtDistance"
                Type="Integer" ErrorMessage="Sorry, we only deliver within a 3 km radius."
                MaximumValue="3"
                MinimumValue="0" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
        </div>


        <asp:Button ID="btnAdd" Text="Register" runat="server" CssClass="button" OnClick="btnAdd_Click" />

    </div>
    <asp:Table ID="tblCustomer" runat="server" CssClass="mytable" EnableViewState="False">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell HorizontalAlign="Center">Customer ID</asp:TableHeaderCell>
            <asp:TableHeaderCell HorizontalAlign="Center">Customer Name</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow ID="mytblRow">
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" ID="error" CssClass="error">No Customer Yet!</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div><a class="bottomLink" href="AddToppings.aspx">Select Toppings ...</a></div>
    <br />
    <br />
</asp:Content>

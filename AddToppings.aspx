<%@ Page Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="True" CodeBehind="AddToppings.aspx.cs" Inherits="Final.AddToppings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/css/styles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Choose Your Toppings</h2>
    <asp:Panel ID="pnlinlineBox" runat="server">
        <div class="grid-3-colum">
            <div><asp:Label runat="server" Text="Customer Name:"></asp:Label></div>
            <div>
                <asp:DropDownList ID="drpAddedCustomer" runat="server" CssClass="input2" OnSelectedIndexChanged="drpAddedCustomer_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" Value="-1">Select ... </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="rfvAddedCustomer" runat="server"
                    ErrorMessage="Must select one!"
                    ForeColor="Red" ControlToValidate="drpAddedCustomer"
                    InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
    </asp:Panel>


    <div id="mySumMsg"><asp:Label runat="server" ID="lblsumMsg" Visible="false" CssClass="emphsisComplete" /></div>
    <br />
    <asp:Label ID="lblToppings" runat="server" Text="Avalible Toppings" CssClass="Toppings"></asp:Label>
    <br />
    <br />
    <div><asp:Label runat="server" ID="lblerrorMsg" Visible="false" CssClass="emphsis" /></div>
    <br />
    <br />
    <div id="myToppingsList">
        <asp:CheckBoxList ID="chklst" runat="server" OnSelectedIndexChanged="chklst_SelectedIndexChanged" AutoPostBack="true"></asp:CheckBoxList>
    </div>

    <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="buttonIn" OnClick="btnSave_Click" />
    <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="buttonIn" OnClick="btnSubmit_Click"  Enable="false" />

    <br />
    <br />
    <br />
    <div id="mySum">
        <asp:Label ID="lblSum" runat="server" Text="Summary :" CssClass="Toppings1" Visible="false"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblSumBottom" runat="server" CssClass="mySum" Visible="false"></asp:Label></div>
    <br />
    <br />
    <div><a class="bottomLink" href="Register.aspx">Back to Register Page ...</a></div>
</asp:Content>

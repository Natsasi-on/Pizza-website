<%@ Page Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="Final.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/css/styles.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="myBgImage">
        <div class="myText">
            <h1 id="myH1">Create Your Own Pizza</h1>
            <p id="myP">(Deliverly Only)</p>
            <a href="Register.aspx" id="linkToRegis">Register</a>
        </div>
    </div>
    <br />
    <br />
    <div id="myContainer">
        <ul class="highlight">
                    <li class="highlightMenu"><img src="App_Themes/image/small.jpg" alt="smallPizza">
                        <p>Small $10</p>
                    </li>
                    <li class="highlightMenu"><img src="App_Themes/image/medium.jpg" alt="mediumPizza">
                        <p>Medium $15</p>
                    </li>
                    <li class="highlightMenu"><img src="App_Themes/image/big.jpg" alt="LargePizza">
                        <p>Large $25</p>
                    </li>
                </ul>
    </div>
</asp:Content>
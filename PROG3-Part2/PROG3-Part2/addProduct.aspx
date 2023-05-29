<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="PROG3_Part2.addProduct" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Farm Central</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <style type="text/css">
         .auto-style1 {
             width: 168px;
         }
         .auto-style2 {
             width: 484px;
         }
         .auto-style3 {
             width: 484px;
             height: 50px;
         }
         .auto-style4 {
             height: 50px;
         }
         .auto-style5 {
             width: 124px;
         }
     </style>
</head>
<body style="height:1200px">
    <form runat="server" style="background-color:lightblue; height:100%;">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/FarmerDashboard" style="font-size:36px;">Dashboard</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li style="margin-left:650px"><a runat="server" href="~/farmerProduct">My Products</a></li>
                        <li><a runat="server" href="~/Logout">Logout</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="container body-content">
        
            <div class="jumbotron">
                <table>
                    <tr>
                        <td class="auto-style2">
                            <p class="auto-style1">Create a Product</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="productTypelbl" runat="server" Text="Product Type: "></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <select runat="server" id="itemSelectType" class="auto-style5" >
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="productNamelbl" runat="server" Text="Product Name: "></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="productNametxt" runat="server" BorderStyle="None" ToolTip="Enter a product name"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="productQuantitylbl" runat="server" Text="Product Quantity (kg): "></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="productQuantitytxt" runat="server" BorderStyle="None" ToolTip="Enter the quantity of the product"></asp:TextBox>
                            <asp:RegularExpressionValidator style="color:red" ID="WholeNumberValidator" runat="server"
                                ErrorMessage="Only Whole Numbers are Valid." ControlToValidate="productQuantitytxt"
                                ValidationExpression="^\d+$"
                                ValidationGroup="numberValidation"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                      <tr>
                        <td class="auto-style3">
                            <asp:Label ID="productCostlbl" runat="server" Text="Product Cost (ZAR): "></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="productCosttxt" runat="server" BorderStyle="None" ToolTip="Enter the cost of your unit per kg"></asp:TextBox>
                            <asp:RegularExpressionValidator style="color:red" ID="DecimalNumberValidator" runat="server"
                                ErrorMessage="Only valid numbers with 2 decimals. (decimal with dot)." ControlToValidate="productCosttxt"
                                ValidationExpression="^\d+(\.\d{2})?$"
                                ValidationGroup="decimalValidation"
                                ></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Button ID="registerProductbtn" runat="server" Text="Register Product" OnClick="registerProductbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="Click here to register your product"/>
                        </td>
                        <td class="auto-style4">
                            <asp:Button ID="cancelProductbtn" runat="server" Text="Cancel" OnClick="cancelProductbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="Click here to cancel creating product" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label style="color:red" ID="errorlbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>      
            </div>
            <hr />
            <footer>
                <p style="color:grey;">&copy; <%: DateTime.Now.Year %> - Farm Central</p>
            </footer>
        </div>
    </form>
</body>
</html>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employeeProduct.aspx.cs" Inherits="PROG3_Part2.employeeProduct" %>

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
             width: 522px;
         }
         .auto-style2 {
             width: 224px;
         }
         .auto-style3 {
             width: 522px;
             height: 40px;
         }
         .auto-style4 {
             height: 40px;
         }
         .auto-style5 {
             width: 522px;
             height: 179px;
         }
         .auto-style6 {
             height: 179px;
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
                    <a class="navbar-brand" runat="server" href="~/EmployeeDashboard" style="font-size:36px;">Dashboard</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li style="margin-left:550px"><a runat="server" href="~/Farmers">Farmers</a></li>
                        <li><a runat="server" href="~/employeeProduct">Products</a></li>
                        <li><a runat="server" href="~/Logout">Logout</a></li>
                        
                    </ul>
                </div>
            </div>
        </div>
        <div class="container body-content">
            <div class="jumbotron">
                <p>Filter Search Farmer Products</p>
                <table>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="farmerlbl" runat="server" Text="Farmer: "></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <select runat="server" id="farmerSelect" class="auto-style2" >
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="fromDatelbl" runat="server" Text="From: "></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Calendar ID="fromCalendar" runat="server" Width="224px"></asp:Calendar>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style5">
                            <asp:Label ID="untilDatelbl" runat="server" Text="To: "></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Calendar ID="toCalendar" runat="server"></asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="searchbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="Click here to search for farmer products" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label style="color:red" ID="errorlbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <hr />
                <p>Farmer Products</p>
                <asp:GridView ID="farmerProductView" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="StockID" HeaderText="StockID" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="ItemType" HeaderText="ItemType" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="StockID" HeaderText="StockID" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="100px"/>
                        <asp:BoundField DataField="UnitCost" HeaderText="UnitCost" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="100px"/>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="NoResultlbl" runat="server" Text="No Results Found" Visible="false"></asp:Label>
            </div>
            <hr />
            <footer>
                <p style="color:grey;">&copy; <%: DateTime.Now.Year %> - Farm Central</p>
            </footer>
        </div>
    </form>
</body>
</html>



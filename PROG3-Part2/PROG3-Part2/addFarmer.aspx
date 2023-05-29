<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addFarmer.aspx.cs" Inherits="PROG3_Part2.addFarmer" %>


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
             width: 522px;
             height: 50px;
         }
         .auto-style3 {
             height: 50px;
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
                <table>
                    <tr>
                        <td>
                            <p>Create a Farmer</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="farmerUsernamelbl" runat="server" Text="Farmer Username: "></asp:Label>
                        </td>
                        <td class="auto-style3">
                            <asp:TextBox ID="farmerUsernametxt" runat="server" BorderStyle="None" ToolTip="Enter farmer username"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="farmerPasswordlbl" runat="server" Text="Farmer Password: "></asp:Label>
                        </td>
                        <td class="auto-style3">
                            <asp:TextBox ID="farmerPasswordtxt" runat="server" BorderStyle="None" ToolTip="Enter farmer password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="farmerCPasswordlbl" runat="server" Text="Confirm Password: "></asp:Label>
                        </td>
                        <td class="auto-style3">
                            <asp:TextBox ID="farmerCPasswordtxt" runat="server" BorderStyle="None" ToolTip="Confirm farmer password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Button ID="registerFarmerbtn" runat="server" Text="Register Farmer" OnClick="registerFarmerbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="Click here to register farmer" />
                        </td>
                        <td class="auto-style3">
                            <asp:Button ID="cancelFarmerbtn" runat="server" Text="Cancel" OnClick="cancelFarmerbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="Click here to cancel registration" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label style="color:red" ID="errorlbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>      
            </div>
            <hr />
            <footer>
                <p style="color:grey">&copy; <%: DateTime.Now.Year %> - Farm Central</p>
            </footer>
        </div>
    </form>
</body>
</html>



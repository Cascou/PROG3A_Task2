<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Farmers.aspx.cs" Inherits="PROG3_Part2.Farmers" %>

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
                <a runat="server" href="~/addFarmer">Add Farmer</a>
                <p> Farm Central Farmers</p>
                <asp:GridView ID="farmerView" runat="server" DataKeyNames="UserID" AutoGenerateColumns="false" OnRowEditing="FarmerViewEditing" OnRowUpdating="FarmerViewUpdate" OnRowCancelingEdit="FarmerViewCancel" OnRowDeleting="FarmerViewDelete">
                    <Columns >
                        <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="80px"/>

                        <asp:TemplateField HeaderText="Username" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="80px">
                            <ItemTemplate>
                                <%# Eval("Username") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="Usernametxt" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Password" HeaderText="Password" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="600px"/>
                        <asp:BoundField DataField="FarmerID" HeaderText="FarmerID" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="30px" ItemStyle-Width="80px"/>
                    
                    
                        <asp:CommandField  ShowEditButton="true" ButtonType="Button"/>
                        <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ItemStyle-Width="60px"/>
                       

                    </Columns>
                </asp:GridView>
                <asp:Label ID="NoResultlbl" runat="server" Text="No Results Found" Visible="false"></asp:Label>
            </div>
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Farm Central</p>
            </footer>
        </div>
    </form>
</body>
</html>


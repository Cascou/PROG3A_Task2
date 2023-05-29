<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROG3_Part2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <table>
            <tr>
                <td style="width: 522px">
                    <p> Employee or Farmer Login</p>
                </td>
            </tr>
           
            <tr>
                <td style="width: 522px; height: 50px">
                    <asp:Label ID="loginUsernamelbl" runat="server" Text="Username"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="loginUsernametxt" runat="server" BorderStyle="None" ToolTip="Enter your username"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 522px; height: 50px">
                    <asp:Label ID="loginPasswordlbl" runat="server" Text="Password"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="loginPasswordtxt" runat="server" BorderStyle="None" ToolTip="Enter your password"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="width: 522px; height: 50px">
                    <asp:Button ID="submitLoginbtn" runat="server" Text="Login" OnClick="submitLoginbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="Click here to login user" />
                </td>
                <td style="height: 50px">
                    <asp:Button ID="cancelLoginbtn" runat="server" Text="Cancel" OnClick="cancelLoginbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="Click here to cancel login" />
                </td>
            </tr>
            <tr>
                <td style="width: 522px">
                    <Label style="color:red" ID="errorlbl" runat="server" Text=""></Label>
                </td>
             </tr>
             <tr>
                <td style="width: 522px">
                    <p style="font-size: 14px">Employee without an account? <a runat="server" href="~/Register" style="font-size: 14px">please register.</a></p>
                </td>
            </tr>
        </table>
    </div>




</asp:Content>

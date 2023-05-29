<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PROG3_Part2.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="jumbotron">
        <table>
           <tr>
               <td style="width: 522px">
                   <p>Register an Employee</p>
               </td>
           </tr>
            <tr>
                <td style="width: 522px; height: 50px">
                    <asp:Label ID="registerUsernamelbl" runat="server" Text="Username"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="registerUsernametxt" runat="server" BorderStyle="None" ToolTip="Enter your username"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 522px; height: 50px">
                    <asp:Label ID="registerPasswordlbl" runat="server" Text="Password"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="registerPasswordtxt" runat="server" BorderStyle="None" ToolTip="Enter your password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 522px; height: 50px">
                    <asp:Label ID="confirmPasswordlbl" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="confirmPasswordtxt" runat="server" BorderStyle="None" ToolTip="Confirm your password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 522px; height: 50px">
                    <asp:Button ID="submitRegisterbtn" runat="server" Text="Register" OnClick="submitRegisterbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="click here to register employee" />
                </td>
                <td style="height: 50px">
                    <asp:Button ID="cancelRegisterbtn" runat="server" Text="Cancel" OnClick="cancelRegisterbtn_Click" BackColor="LightSkyBlue" BorderStyle="None" ToolTip="click here to cancel registration" />
                </td>
            </tr>
            <tr>
                <td style="width: 522px">
                    <Label style="color:red" ID="errorlbl" runat="server" Text=""></Label>
                </td>
             </tr>
            <tr>
                <td style="width: 522px">
                    <p style="font-size: 14px">Already have an account? <a runat="server" href="~/Login">login into existing account.</a></p>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

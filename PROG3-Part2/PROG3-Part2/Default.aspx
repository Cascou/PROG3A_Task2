<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PROG3_Part2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to Farm Central</h1>
        <p>A stock management website, tracking all inbound and outbound stock.</p>
    </div>

    <div class="row">
        <div style="width:100%;" class="col-md-4">
            <h2 style="color:white; font-weight:bold;">Getting started</h2>
            <p style="color:white;">
                Are you new here? <a style="color:grey; font-weight:bold;" runat="server" href="~/Register"> Register with us.</a>
            </p>
            <p style="color:white;">
               Are you already register? <a style="color:grey; font-weight:bold;" runat="server" href="~/Login"> Log in into your existing account.</a>
            </p>
        </div>
    </div>
</asp:Content>

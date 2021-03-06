﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AITSurvey._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <h1>Login</h1>
        <div runat="server" class="LoginForm">
            <div class="input-group">
                <span class="input-group-addon">Email</span>
                <asp:TextBox ID="emailTxt" class="form-control" placeholder="Username" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Password</span>
                <asp:TextBox ID="passwordTxt" TextMode="Password" class="form-control" placeholder="Password" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div>
                <h4>Login as</h4>
                <asp:RadioButtonList ID="loginAs" RepeatDirection="Horizontal"  runat="server">
                    <asp:listitem Value="U">User</asp:listitem>
                    <asp:listitem Value="S">Staff</asp:listitem>
                </asp:RadioButtonList>
            </div>
            <div class="column">
                <div class="row">
                    <asp:Button ID="LoginBtn" class="btn btn-primary" runat="server" Text="Login" OnClick="LoginBtn_Click" />
                    <asp:Button ID="RegisterBtn" class="btn btn-primary" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
                </div>
                <h2>OR</h2>
                <asp:Button ID="GuestBtn" runat="server" class="btn btn-success" Text="Continue as Guest" Onclick="GuestBtn_Click" />
                <asp:Label ID="LoginMessage" runat="server" Text=""></asp:Label>
            </div>


        </div>

    </div>
</asp:Content>

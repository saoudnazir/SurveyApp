<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AITSurvey.Pages.Search" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="SearchContent">
    <style>
        .form-control,.btn{
            margin-top:20px;
        }
        .btn {
            margin-left: 20px
        }

        .filter input[type="checkbox"] {
            margin-left: 20px;
            margin-top: 10px;
        }
    </style>
    <div class="container">
        <div class="row">
            <asp:TextBox ID="searchInput" class="form-control" runat="server"></asp:TextBox>
            <asp:Button runat="server" Text="Search" ID="SearchBtn" class="btn btn-primary" />
        </div>
        <div>
            <asp:CheckBoxList RepeatDirection="Horizontal" runat="server" ID="filter" CssClass="filter">
                <asp:ListItem>Bank</asp:ListItem>
                <asp:ListItem>Bank Service</asp:ListItem>
                <asp:ListItem>Post Code</asp:ListItem>
                <asp:ListItem>Suburb</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col">Email</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">1</th>
                    <td>Saoud</td>
                    <td>Nazir</td>
                    <td>mirzasaoud60@gmail.com</td>
                </tr>
                <tr>
                    <th scope="row">2</th>
                    <td>Santiago</td>
                    <td>Morales</td>
                    <td>Santiago@gmail.com</td>
                </tr>
                <tr>
                    <th scope="row">3</th>
                    <td>Marcus</td>
                    <td>V</td>
                    <td>marcus@gmail.com</td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
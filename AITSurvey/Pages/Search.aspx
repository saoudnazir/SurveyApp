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
            <asp:Button runat="server" Text="Search" ID="SearchBtn" class="btn btn-primary" OnClick="SearchBtn_Click" />
        </div>
        <asp:Label ID="searchMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
        <asp:GridView CssClass="table table-striped" ID="searchTable" AutoGenerateColumns="false" runat="server">
         <Columns>
             <asp:BoundField DataField="firstname" HeaderText="First name" />
             <asp:BoundField DataField="lastname" HeaderText="Last name" />
             <asp:BoundField DataField="rID" HeaderText="User ID" />
             <asp:BoundField DataField="answer" HeaderText="His Answer" />
         </Columns>
     </asp:GridView>
    </div>
</asp:Content>
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="AITSurvey.Pages.Survey" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="SurveyContent">

    <style>
        .question-card{
            width:80%;
            margin:20px auto;
            padding:30px;
            border:1px solid black;
        }
        .question-card #statementTxt{
            font-size:30px;
        }
    </style>

    <div class="container">
        <div class="question-card">
            <asp:Label ID="statementTxt" ClientIDMode="Static" runat="server" Text="Label"></asp:Label>
            <asp:PlaceHolder ID="choiceHolder" runat="server"></asp:PlaceHolder>
            <div class="row">
                <asp:Button ID="PrevBtn" class="btn btn-primary" runat="server" Text="Back" />
                <asp:Button ID="NextBtn" class="btn btn-success" runat="server" Text="Next" />
            </div>
        </div>
    </div>
</asp:Content>

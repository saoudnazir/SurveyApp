<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EndSurvey.aspx.cs" Inherits="AITSurvey.Pages.EndSurvey" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="EndSurveyContent">
    <div class="container">
        <div class="column">
            <h1>End of Survey</h1>
            <asp:Label ID="EOSMessage" runat="server" Text="Your Response"></asp:Label>
            <asp:GridView CssClass="table table-striped" ID="responseTable" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="qStatement" HeaderText="Question" />
                    <asp:BoundField DataField="answer" HeaderText="Your Response" />
                </Columns>
            </asp:GridView>

            <div class="row">
                <asp:Button ID="CancelBtn" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="CancelBtn_Click"/>
                <asp:Button ID="SubmitBtn" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />
            </div>
        </div>
    </div>
</asp:Content>

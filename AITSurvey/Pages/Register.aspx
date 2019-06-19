<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AITSurvey.Pages.Register" %>

<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .input-group {
            margin-bottom: 10px;
        }
    </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(document).ready(function () {
            $("#RegisterRBtn").click(function () {
                var isValid;
                $("input").each(function () {
                    var element = $(this);
                    if (element.val() == "") {
                        isValid = false;
                    }
                });
                alert(isValid);
            });

        });
        

        $(function () {
            $("#datepicker").datepicker({
                beforeShow: function () {
                    setTimeout(function () {
                        $('.ui-datepicker').css('z-index', 2);
                    }, 0);
                }
            });
        });
    </script>
    <div class="container">
        <h1>Register</h1>
        <div runat="server" class="RegisterForm">
            <div class="input-group">
                <span class="input-group-addon">First Name</span>
                <asp:TextBox ID="fNameTxt" class="form-control" placeholder="First Name" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Last Name</span>
                <asp:TextBox ID="lNameTxt" class="form-control" placeholder="Last Name" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group" id="DOBGroup" runat="server">
                <span class="input-group-addon">Date of Birth</span>
                <div class="CalenderGroup">
                    <asp:TextBox runat="server" ID="datepicker" class="form-control" ClientIDMode="Static" placeholder="Date of Birth" />
                </div>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Username</span>
                <asp:TextBox ID="userText" class="form-control" placeholder="Username" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Email</span>
                <asp:TextBox ID="emailRTxt" TextMode="Email" class="form-control" placeholder="Email" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Password</span>
                <asp:TextBox ID="passwordRTxt" TextMode="Password" class="form-control" placeholder="Password" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Gender</span>
                <asp:RadioButtonList RepeatDirection="Horizontal" ClientIDMode="Static" ID="genderTxt" runat="server">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="input-group">
                <span class="input-group-addon">State</span>
                <asp:DropDownList ID="stateTxt" class="form-control" runat="server">
                    <asp:ListItem>NSW</asp:ListItem>
                    <asp:ListItem>VIC</asp:ListItem>
                    <asp:ListItem>QLD</asp:ListItem>
                    <asp:ListItem>TAS</asp:ListItem>
                    <asp:ListItem>SA</asp:ListItem>
                    <asp:ListItem>NT</asp:ListItem>
                    <asp:ListItem>WA</asp:ListItem>
                    <asp:ListItem>ACT</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Suburb</span>
                <asp:TextBox ID="suburbTxt" class="form-control" placeholder="Suburb" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Post Code</span>
                <asp:TextBox ID="postCodeTxt" TextMode="Number" class="form-control" Text="0" placeholder="Post Code" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
                <asp:Label ID="requiredTxt" runat="server" Text="*All Fields are required !"></asp:Label>
            <div class="column">
                <div class="row">
                    <asp:Button ID="RegisterRBtn" class="btn btn-primary" runat="server" Text="Register" OnClick="RegisterRBtn_Click" />
                </div>
                <h2>OR</h2>
                <asp:Button ID="GuestRBtn" runat="server" class="btn btn-success" Text="Continue as Guest" />

            </div>


        </div>

    </div>
</asp:Content>

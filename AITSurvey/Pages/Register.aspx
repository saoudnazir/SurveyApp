<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AITSurvey.Pages.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .Calender{
            display:none;
            z-index:999;
            background:white;
            position:absolute;
        }
        .CalenderIcon{
            width:40px;
            height:40px
        }
        .CalenderGroup{
            display:flex;
        }
        
        
    </style>
    <script type="text/javascript">
        function showhide() {
            console.log()
            var div = document.getElementById("dobCalender");
            if (div.style.display !== "none") {
                div.style.display = "none";
            }
            else {
                div.style.display = "block";
            }
        }  
    </script>
    <div class="container">
        <h1>Register</h1>
        <div runat="server" class="RegisterForm">
            <div class="input-group">
                <span class="input-group-addon">First Name</span>
                <asp:TextBox ID="fNameTxt" TextMode="Password" class="form-control" placeholder="First Name" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Last Name</span>
                <asp:TextBox ID="lNameTxt" TextMode="Password" class="form-control" placeholder="Last Name" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group" ID="DOBGroup" runat="server">
                <span class="input-group-addon">Date of Birth</span>
                <div class="CalenderGroup">
                    <asp:TextBox ID="dobTxt" runat="server" placeholder="Date of Birth" />
                    <!--<asp:ImageButton ID="calenderBtn" CssClass="CalenderIcon" OnClick="ToggleCalender" ImageUrl="~/images/calender.jpg" runat="server" />-->
                    <asp:Button  runat="server"  Text="T"/>
                </div>
                <asp:Calendar ID="dobCalender" CssClass="Calender" runat="server"></asp:Calendar>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Username</span>
                <asp:TextBox ID="userText" TextMode="Password" class="form-control" placeholder="Username" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Email</span>
                <asp:TextBox ID="emailRTxt" class="form-control" placeholder="Email" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Password</span>
                <asp:TextBox ID="passwordRTxt" TextMode="Password" class="form-control" placeholder="Password" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <span class="input-group-addon">Gender</span>
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="genderTxt" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
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
                <asp:TextBox ID="postCodeTxt" TextMode="Number" class="form-control" placeholder="Post Code" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
            </div>
            
            <div class="column">
                <div class="row">
                    <asp:Button ID="LoginRBtn" class="btn btn-primary" runat="server" Text="Login"  />
                    <asp:Button ID="RegisterRBtn" class="btn btn-primary" runat="server" Text="Register" />
                </div>
                <h2>OR</h2>
                <asp:Button ID="GuestRBtn" runat="server" class="btn btn-success" Text="Continue as Guest" />

            </div>


        </div>

    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XMenAdventure.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="landing_body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section class="top">
        <h2 class="auto-style2">Sign In</h2>
        <div class="auto-style2">
            <span>Email: </span><asp:TextBox ID="txtSignEmail" runat="server"></asp:TextBox><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password: </span>
            <asp:TextBox ID="txtSignPass" runat="server" TextMode="Password"></asp:TextBox><br />
            <p><asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" /> </p><br />
            <asp:Button ID="SignIn" runat="server" Text="Sign In" OnClick="SignIn_Click"/>
            <p>
        <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid. Please try again."
            Visible="False"></asp:Label> </p>
        </div>
    </section>

    <asp:SqlDataSource ID="userSql" runat="server"></asp:SqlDataSource>
    <section class="bottom">
         <nav>
            <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="SignUp_Click" />
        </nav>
    </section>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="XMenAdventure.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="auto-style1">
        <h2 class="auto-style2">Sign Up</h2>
           <div class='container'>
               <asp:Label ID="lblRogueHidden" runat="server" Text="" Visible="False"></asp:Label>
              <div class='picture'><asp:ImageButton ID="btnRogue" runat="server" ImageUrl="images/rogue1.png" ClientIDMode="Static" Width="200px" Height="200px" style="margin-right: 5px" CssClass="rogue" OnClick="btnRogue_Click" OnClientClick="btnRogue_Click" />
                <div class='middle'>
                        <div class='text'>
                            <asp:Label ID="lblRogue" runat="server" Text="Rogue"></asp:Label></div>
                    </div>
                </div>
               <asp:Label ID="lblGambitHidden" runat="server" Text="" Visible="False"></asp:Label>
             <div class='picture'>
                <asp:ImageButton ID="btnGambit" runat="server" ImageUrl="images/gambit1.png" ClientIDMode="Static" Width="200px" Height="200px" style="margin-right: 5px" CssClass="gambit" OnClick="btnGambit_Click" OnClientClick="btnGambit_Click" />
            <div class='middle'>
                        <div class='text'><asp:Label ID="lblGambit" runat="server" Text="Gambit"></asp:Label></div>
                    </div>
                </div>
               <asp:Label ID="lblMagikHidden" runat="server" Text="" Visible="False"></asp:Label>
             <div class='picture'>
             <asp:ImageButton ID="btnMagik" runat="server" ImageUrl="images/magik1.png" ClientIDMode="Static" Width="200px" Height="200px" style="margin-right: 5px" CssClass="magik" OnClick="btnMagik_Click" OnClientClick="btnMagik_Click"/>
                 <div class='middle'>
                        <div class='text'><asp:Label ID="lblMagik" runat="server" Text="Magik"></asp:Label></div>
                    </div>
                </div>
               <asp:Label ID="lblColossusHidden" runat="server" Text="" Visible="False"></asp:Label>
             <div class='picture'>
                 <asp:ImageButton ID="btnColossus" runat="server" ImageUrl="images/colossus.png" ClientIDMode="Static" Width="200px" Height="200px"  CssClass="colossus" OnClick="btnColossus_Click" OnClientClick="btnColossus_Click"/>
        <div class='middle'>
                        <div class='text'><asp:Label ID="lblColossus" runat="server" Text="Colossus"></asp:Label></div>
                    </div>
                </div>
                <br/>Please select an item by clicking on it.
            </div>
        <div class="auto-style2">
        <br /><br />
        <span>First Name:</span><asp:TextBox ID="txtFName" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="Please enter in your first name." ControlToValidate="txtFName" Display="None"></asp:RequiredFieldValidator>
        <span>Last Name:</span><asp:TextBox ID="txtLName" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="Please enter in your last name." ControlToValidate="txtLName" Display="None"></asp:RequiredFieldValidator>
        <span>Email:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> </span><br />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please enter in your email." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
        <span>Password:</span><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please enter in a password." ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
        <span>Confirm Password:</span><asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:CompareValidator ID="cvMatchPass" runat="server" ErrorMessage="Your password doesn not match." ControlToValidate="txtConfirm" ControlToCompare="txtPassword" Display="None"></asp:CompareValidator>   
            <asp:Button ID="SignUp" runat="server" Text="Sign Up" OnClick="SignUp_Click"/>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    </section>


</asp:Content>

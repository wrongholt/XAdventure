<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="combat.aspx.cs" Inherits="XMenAdventure.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="top">
        <div class='container'>   
         <asp:TextBox ID="txtbattle" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
            <asp:TextBox ID="txtOther" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
            <asp:Button ID="btnAttack" runat="server" Text="Attack" OnClick="Attack_Click" /><asp:Button ID="btnSpecial" runat="server" Text="Special Attack" Visible="false" OnClick="Special_Click"/><asp:Button ID="btnRun" runat="server" Text="Run" OnClick="Run_Click"/><br />
       `
        
              <div class='picture'><asp:Image ID="imgEnemy" runat="server" CssClass="charPicture" ImageAlign="Right" Height="250px" Width="175px" />
                <div class='middle'>
                        <div class='text'>
                            <asp:Label ID="lblEnemy" runat="server" Text=""></asp:Label></div>
                    </div>
                </div>
            </div>
    </section>
    <section class="bottom">
        <div class="charMainStats">
            <span><asp:Image ID="imgChar" runat="server" CssClass="charPicture" ImageAlign="Left" Height="250px" Width="175px" /></span>
            <span>Character: </span><asp:Label ID="lblCharacter" runat="server" Text=""></asp:Label><br />
            <span>Attack: </span><asp:Label ID="lblAtk" runat="server" Text=""></asp:Label><br />
            <span>Speed: </span><asp:Label ID="lblSpeed" runat="server" Text=""></asp:Label><br />
            <span>Defense: </span><asp:Label ID="lblDefense" runat="server" Text=""></asp:Label><br />
            <span>Special: </span><asp:Label ID="lblSpecName" runat="server" Text=""></asp:Label><br />
            <span>Special:<asp:Label ID="lblSecial" runat="server" Text=""></asp:Label> <asp:Label ID="lblSpecial" runat="server" Text=""></asp:Label> </span><br />
            <span>Health: </span><asp:Label ID="lblHealth" runat="server" Text=""></asp:Label><br />
             <asp:Label ID="lblI" runat="server" Text=""/><br />
        </div>
            
        <nav>
            <asp:Button ID="btnRestart" runat="server" Text="Restart" OnClick="btnRestart_Click" Visible="false" CssClass="button"/>
            <asp:Button ID="btnRest" Visible = "false" runat="server" OnClick="btnRest_Click"  Text="Rest for 1 hour" CssClass ="button"/>
            <asp:Button ID="btnBack" Visible="false" runat="server" Text="Back to Story" OnClick="btnBack_Click" CssClass ="button"></asp:Button>
        </nav>
    </section>
</asp:Content>

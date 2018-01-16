<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="combat.aspx.cs" Inherits="XMenAdventure.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="top">
        <asp:TextBox ID="txtbattle" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
        <asp:TextBox ID="txtOther" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
        <asp:Button ID="btnAttack" runat="server" Text="Attack" OnClick="Attack_Click"/><asp:Button ID="btnSpecial" runat="server" Text="Special Attack" Visible="false" OnClick="Special_Click"/><asp:Button ID="btnRun" runat="server" Text="Run" OnClick="Run_Click"/>
     </section>
    <section class="bottom">
        <asp:Button ID="btnRestart" runat="server" Text="Restart" OnClick="btnRestart_Click" Visible="false" CssClass="button"/>
        <asp:Button ID="btnRest" Visible = "false" runat="server" OnClick="btnRest_Click"  Text="Rest for 1 hour" CssClass ="button"/>
        <div class="charMainStats">
            <span><asp:Image ID="imgChar" runat="server" CssClass="charPicture" ImageAlign="Left" /></span>
            <span>Character: </span><asp:Label ID="lblCharacter" runat="server" Text=""></asp:Label><br />
            <span>Attack: </span><asp:Label ID="lblAtk" runat="server" Text=""></asp:Label><br />
            <span>Speed: </span><asp:Label ID="lblSpeed" runat="server" Text=""></asp:Label><br />
            <span>Defense: </span><asp:Label ID="lblDefense" runat="server" Text=""></asp:Label><br />
            <span>Special: </span><asp:Label ID="lblSpecName" runat="server" Text=""></asp:Label><br />
            <span>Special: </span><asp:Label ID="lblSecial" runat="server" Text=""></asp:Label><br />
            <span>Health: </span><asp:Label ID="lblHealth" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblSpecial" runat="server" Text=""></asp:Label><br /><br />
        </div>
        <nav>
            <asp:Menu ID="MainMenu" runat="server" DataSourceID="XmenMaster" Orientation="Horizontal"></asp:Menu>
        </nav>
    </section>
</asp:Content>

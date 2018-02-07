<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LevelOne.aspx.cs" Inherits="XMenAdventure.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="top">
        <asp:TextBox ID="txtBegin"  runat="server" Width="100%" TextMode="MultiLine" CssClass="textBubble" BorderStyle="None"></asp:TextBox>
        <asp:Button ID="btnOption1" runat="server" Text="Option 1" OnClick="btnOption1_Click" /><asp:Button ID="btnOption2" runat="server" Text="Option 2" OnClick="btnOption2_Click" />
        <asp:TextBox ID="txt1" runat="server" Width="100%" TextMode="MultiLine" Enabled="True" Visible="False" CssClass="textBubble" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="txtEquip1" runat="server" Width="100%" TextMode="MultiLine" Enabled="True" Visible="False" CssClass="textBubble" AutoPostBack="True"></asp:TextBox>
        <asp:ImageButton ID="imgEquip" Height="150" Width="150" ImageAlign="Left" Visible="False" runat="server" OnClick="imgEquip_Click"/>
     
        <asp:TextBox ID="txt2" runat="server" Width="100%" TextMode="MultiLine" Enabled="True" Visible="False" CssClass="textBubble"></asp:TextBox>
        <asp:Button ID="btnOption111" runat="server" Text="Option 1" OnClick="btnOption111_Click" Visible="False" CssClass="button"/><asp:Button ID="btnOption112" runat="server" Text="Option 2" OnClick="btnOption112_Click" Visible="False"/>
        <asp:Button ID="btnOption121" runat="server" Text="Search Pyro" OnClick="btnOption121_Click" Visible="False" CssClass="button"/><asp:Button ID="btnOption122" runat="server" Text="Search Mansion" OnClick="btnOption122_Click" Visible="False"/>
        <asp:Button ID="btnOption131" runat="server" Text="Think" OnClick="btnOption131_Click" Visible="False" CssClass="button"/><asp:Button ID="btnOption132" runat="server" Text="Go Crazy" OnClick="btnOption132_Click" Visible="False"/>
        <asp:Button ID="btnOption141" runat="server" Text="Go North" OnClick="btnOption141_Click" Visible="False" CssClass="button"/><asp:Button ID="btnOption142" runat="server" Text="Randomly Pace" OnClick="btnOption142_Click" Visible="False"/>
                <asp:Button ID="btnOption151" runat="server" Text="Go North" OnClick="btnOption141_Click" Visible="False" CssClass="button"/><asp:Button ID="btnOption152" runat="server" Text="Do a Dance!" OnClick="btnOption142_Click" Visible="False"/>

        <asp:Button ID="btnOption221" runat="server" Text="Option 1" OnClick="btnOption221_Click" Visible="False" CssClass="button"/><asp:Button ID="btnOption22End" runat="server" Text="Option 2" OnClick="btnOption22End_Click" Visible="False"/>

        
        <asp:Image ID="imgEnemy1" runat="server" ImageAlign="Left" Height="250px" Width="175px" CssClass="charPicture" Visible="False"/>
        <asp:Button ID="btnCombat" runat="server" Text="Start Combat" OnClick="btnCombat_Click" Visible="false" CssClass="button"/>




    </section>
    <section class="bottom">
        <asp:Button ID="btnRestart" runat="server" Text="Restart" OnClick="btnRestart_Click" Visible="false" CssClass="button"/>
        <asp:Button ID="btnRest" Visible = "false" runat="server" OnClick="btnRest_Click"  Text="Rest for 1 hour" CssClass ="button"/>
        <div class="charMainStats">
            <span><asp:Image ID="imgChar" runat="server" ImageAlign="Left" Height="250px" Width="175px" CssClass="charPicture" /></span>
            <span>Character: </span><asp:Label ID="lblCharacter" runat="server" Text=""></asp:Label><br />
            <span>Attack: +</span><asp:Label ID="lblAtk" runat="server" Text=""></asp:Label><br />
            <span>Speed: +</span><asp:Label ID="lblSpeed" runat="server" Text=""></asp:Label><br />
            <span>Defense: +</span><asp:Label ID="lblDefense" runat="server" Text=""></asp:Label><br />
            <span>Special: <asp:Label ID="lblSpecName" runat="server" Text=""></asp:Label> +<asp:Label ID="lblSpecial" runat="server" Text=""></asp:Label></span><br />
            <span>Health: <asp:Label ID="lblCurrent" runat="server" Text=""/> / <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></span><br />
           
            <br />
        </div>
        <nav>
            <asp:Button ID="btnEquipment" runat="server" Text="To Equipment" OnClick="btnEquipment_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </nav>
    </section>
</asp:Content>

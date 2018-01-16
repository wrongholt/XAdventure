<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CharEquipment.aspx.cs" Inherits="XMenAdventure.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        text-decoration: underline;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="top">
        <div id="stick">
            <h3 class="auto-style4">Equipment</h3>
            <asp:Image ID="top" runat="server" CssClass="topStick" ImageUrl="images/stick2.png"  /><br />
            <asp:Image ID="middle" runat="server" CssClass="middleStick" ImageUrl="images/stick3.png" /><br />
            <asp:Image ID="bottom" runat="server" CssClass="bottomStick" ImageUrl="images/stick4.png"/><br /><br />
             <div id="backpack">
                 <div id="slot1" class="itemSlot"><asp:Image ID="imgSlot1" runat="server" /></div>
                 <asp:Button ID="btnEquip1" runat="server" Text="" OnClick="btnEquip_Click" Visible ="false"/>

                 <div id="slot2" class="itemSlot"><asp:Image ID="imgSlot2" runat="server" /></div>
                 <asp:Button ID="btnEquip2" runat="server" Text="" OnClick="btnEquip2_Click" Visible ="false"/>
            
                 <div id="slot3" class="itemSlot"><asp:Image ID="imgSlot3" runat="server" /></div>
                 <asp:Button ID="btnEquip3" runat="server" Text="" OnClick="btnEquip3_Click" Visible ="false"/>
               
             </div>
            </div>
            <div id="stats">
            <h3 class="auto-style4">Stats</h3>
            <br />
            <span>Character: </span><asp:Label ID="lblCharacter" runat="server" Text=""></asp:Label><br />
            <span>Attack: </span><asp:Label ID="lblAtk" runat="server" Text=""></asp:Label><br />
            <span>Speed: </span><asp:Label ID="lblSpeed" runat="server" Text=""></asp:Label><br />
            <span>Defense: </span><asp:Label ID="lblDefense" runat="server" Text=""></asp:Label><br />
            <span>Special: </span>
            <asp:Label ID="lblSpecName" runat="server" Text=""></asp:Label><br /><asp:Label ID="lblSpecial" runat="server" Text=""></asp:Label><br /><br />
            <span>Head Equipment:</span><asp:Label ID="lblHeadName" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblHeadDesc" runat="server" Text=""></asp:Label><br />
            <span>Belt Equipment:</span><asp:Label ID="lblBeltName" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblBeltDesc" runat="server" Text=""></asp:Label><br />
            <span>Feet Equipment:</span><asp:Label ID="lblFeetName" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblFeetDesc" runat="server" Text=""></asp:Label><br />
           </div>
            
    </section>
    <section class="bottom">
        <nav><%--<a href="javascript:history.go(-1)">Back</a>--%>
<asp:Button ID="btnBack" runat="server" Text="Back to Story" OnClick="btnBack_Click"></asp:Button>
        </nav>
    </section>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script >
    $(function () {
        $(".itemSlot img").draggable({
            snap: ".topStick",
            snap: ".middleStick",
            snap: ".bottomStick",
            revert: "invalid",
            refreshPositions: true,
            drag: function (event, ui) {
                ui.helper.addClass("draggable");
            },
            stop: function (event, ui) {
                ui.helper.removeClass("draggable");
                var image = this.src.split("/")[this.src.split("/").length - 1];
                console.log(image);
            }
        });
        $(".topStick").droppable({
            accept: '.itemSlot img',
            drop: function (event, ui) {
                ui.draggable.addClass("dropped");
                $(".topStick").attr("ImageUrl", "'" + image + "'");
                $(".topStick").append(ui.draggable);
            }
        });
        $(".middleStick").droppable({
            accept: '.itemSlot img',
            drop: function (event, ui) {
                $(".middleStick").addClass("dropped");
                $(".middleStick").attr("ImageUrl", "'" + image + "'");
                $(".middleStick").append(ui.draggable);
            }
        });
        $(".bottomStick").droppable({
            accept: '.itemSlot img',
            drop: function (event, ui) {
                $(".bottomStick").addClass("dropped");
                $(".bottomStick").attr("ImageUrl", image);
                $(".bottomStick").append(ui.draggable);
            }
        });
    });

</script>
</asp:Content>

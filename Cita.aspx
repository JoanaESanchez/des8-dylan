<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Cita.aspx.vb" Inherits="project_semestral_citas.Cita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div>
    <h1 style="text-align: center;">Control de citas</h1>
    <div>
        <table class="w-100">
        <tr>
            <td>
                <asp:Button ID="btnShow" runat="server" Text="Mostrar" />
                <asp:Button ID="btnPrint" runat="server" Text="Imprimir PDF" />
            </td>
        </tr>
        </table>
    </div>
    <div style="margin: 20px 0;">
        <h2>Registros de citas</h2>
        <asp:GridView ID="GridViewCitas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

    </div>
</div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Especialidades.aspx.vb" Inherits="project_semestral_citas.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1 style="text-align: center;">Control de especialidades</h1>
        <div>
            <table class="w-100">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Especialidad ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSpecialityId" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Tipo de Especialidad"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownSpeciality" runat="server" Width="100%">
                        <asp:ListItem>Medicina general</asp:ListItem>
                        <asp:ListItem>Odontologo</asp:ListItem>
                        <asp:ListItem>Cardiologo</asp:ListItem>
                        <asp:ListItem>Nutricionista</asp:ListItem>
                        <asp:ListItem>Pediatra</asp:ListItem>
                        <asp:ListItem>Otorrinolaringologo</asp:ListItem>
                        <asp:ListItem>Cirujano plastico</asp:ListItem>
                        <asp:ListItem>Ginecologo</asp:ListItem>
                        <asp:ListItem>Psicologo</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Agregar" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" />
                    <asp:Button ID="btnRemove" runat="server" Text="Eliminar" />
                    <asp:Button ID="btnShow" runat="server" Text="Mostrar" style="height: 29px" />
                    <asp:Button ID="btnPrint" runat="server" Text="Imprimir PDF" style="height: 29px" />
                </td>
            </tr>
            </table>
        </div>
        <div style="margin: 20px 0;">
            <h2>Registros de especialidades</h2>
            <asp:GridView ID="GridViewSpeciality" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Paciente.aspx.vb" Inherits="project_semestral_citas.Paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
    <h1 style="text-align: center;">Control de pacientes</h1>
    <div>
        <table class="w-100">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Paciente ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPacientId" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 27px">
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td style="height: 27px">
                <asp:TextBox ID="txtPacientFirstname" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPacientLastname" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Sintoma"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSintoma" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Doctor ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDoctorId" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 21px"></td>
            <td style="height: 21px">
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnAdd" runat="server" Text="Agregar" />
                <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" />
                <asp:Button ID="btnRemove" runat="server" Text="Eliminar" />
                <asp:Button ID="btnShow" runat="server" Text="Mostrar" />
                <asp:Button ID="btnPrint" runat="server" Text="Imprimir PDF" />
            </td>
        </tr>
        </table>
    </div>
    <div style="margin: 20px 0;">
        <h2>Registros de pacientes</h2>
        <asp:GridView ID="GridViewPacient" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
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

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Doctor.aspx.vb" Inherits="project_semestral_citas.Doctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <h1 style="text-align: center;">Control de doctores</h1>
        <div>
            <table class="w-100">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Doctor ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDoctorId" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDoctorFirstname" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDoctorLastname" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Especialidad ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSpecialityId" runat="server" Width="100%"></asp:TextBox>
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
            <h2>Registros de doctores</h2>
            <asp:GridView ID="GridViewDoctor" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>

        </div>
    </div>
</asp:Content>

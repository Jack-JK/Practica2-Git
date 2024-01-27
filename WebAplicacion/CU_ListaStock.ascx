<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CU_ListaStock.ascx.cs" Inherits="WebAplicacion.CU_ListaStock" %>
<asp:GridView ID="rgvListaStock" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="IdStock" HeaderText="IdStock" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        <asp:BoundField DataField="IdInsumo" HeaderText="IdInsumo" />
        <asp:BoundField DataField="IdAlmacen" HeaderText="IdAlmacen" />
        <asp:BoundField DataField="IdIngreso" HeaderText="IdIngreso" />
        <asp:BoundField DataField="FechaIngreso" HeaderText="FechaIngreso" />
        <asp:BoundField DataField="EstadoRegistra" HeaderText="EstadoRegistra" />
    </Columns>
</asp:GridView>
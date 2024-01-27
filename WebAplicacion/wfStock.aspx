<%@ Page Title="" Language="C#" MasterPageFile="~/mpPrincipal.Master" AutoEventWireup="true" CodeBehind="wfStock.aspx.cs" Inherits="WebAplicacion.wfStock" %>
<%@ Register src="CU_ListaStock.ascx" TagName="CU_ListaStock" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CU_ListaStock ID="CU_ListaStock1" runat="server" />
</asp:Content>

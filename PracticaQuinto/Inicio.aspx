<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PracticaQuinto.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Mensaje" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Contenido" runat="server">

    <asp:Label ID="lblNombreUsuario" runat="server" Text="Label"></asp:Label><br>
    <asp:Button ID="btnSalir" OnClick="btnSalir_Click" runat="server" Text="Cerrar Sesion" />

</asp:Content>

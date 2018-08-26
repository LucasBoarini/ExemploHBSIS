<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Página Principal</h2>
<p>Código Livro:
    <asp:TextBox ID="txtID" runat="server" Width="42px"></asp:TextBox>
&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
</p>
<p>Nome Livro:
    <asp:TextBox ID="txtNomeLivro" runat="server"></asp:TextBox>
</p>
<p>Autor Livro:
    <asp:TextBox ID="txtAutorLivro" runat="server"></asp:TextBox>
</p>
<p>&nbsp;&nbsp;<asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
&nbsp;<asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
&nbsp;<asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
</p>
    <p>
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
</p>
<p>
    <asp:GridView ID="gdvLivros" runat="server">
    </asp:GridView>
</p>
</asp:Content>

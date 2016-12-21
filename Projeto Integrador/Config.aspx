<%@ Page Title="Configurações | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="Projeto_Integrador.Config" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="config2 col-sm-10 col-sm-offset-1 col-md-10 col-md-offset-1">
        <div class="imgconfig col-sm-6 col-md-4 col-md-offset-2">
            <div class="conteudo">
                <asp:Image ID="FotoPerfil" runat="server" ImageUrl="~/Imagens/perfil/icon.png" width="65%" height="65%" class="img-rounded" />
            </div>
        </div>
        <div class="dados col-sm-6 col-md-4">
            <div class="conteudo">
                <h4><b>Nome completo:</b> <asp:Label ID="Nome" runat="server" Text=""></asp:Label></h4>
                <h4><b>Data de nascimento:</b> <asp:Label ID="DataNascimento" runat="server" Text=""></asp:Label></h4>
                <h4><b>Email:</b> <asp:Label ID="Email" runat="server" Text=""></asp:Label></h4>
                <h4><b>Nome de usuário:</b> <asp:Label ID="NomeUsuario" runat="server" Text=""></asp:Label></h4>
                <h4><b>Senha:</b> <asp:Label ID="Senha" runat="server" Text=""></asp:Label></h4>
            </div>
            <asp:Button ID="Button1" runat="server" Text="EDITAR" type="submit" name="submit" class="btn btn-submit2" PostBackUrl="~/Config2.aspx" />
        </div>
    </div>
</asp:Content>

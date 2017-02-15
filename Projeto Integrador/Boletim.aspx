<%@ Page Title="Boletins | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Boletim.aspx.cs" Inherits="Projeto_Integrador.Boletim" Theme="css" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="col-sm-12 col-md-10 col-md-offset-1">
        <asp:Button ID="ButtonCriarBoletim" runat="server" class="btn btn-submit" Text="Button" OnClick="ButtonCriarBoletim_Click" />
    </div>
</asp:Content>

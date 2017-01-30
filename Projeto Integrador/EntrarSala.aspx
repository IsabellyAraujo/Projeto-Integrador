<%@ Page Title="Entrar na Sala | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EntrarSala.aspx.cs" Inherits="Projeto_Integrador.EntrarSala" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="col-md-6 col-md-offset-4">
           <%--<img src="Imagens/pessoasimprove.png" height="200px">--%>
        </div>
        <div class="col-md-12">
            <div class="formulario col-md-4 col-md-offset-4 col-sm-10 col-sm-offset-1">
                <div class="contact-form bottom">
                     <div class="form-group">
                           <asp:TextBox ID="Nome" runat="server" type="username" class="form-control" required="required" placeholder="Nome da sala"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="Senha" runat="server" type="password" class="form-control" required="required" placeholder="Senha"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" Text="ENTRAR" type="submit" name="submit" class="btn btn-submit" OnClick="Button1_Click" /><br />
                        </div>
                        <a href="CriarSala.aspx">Ainda não possui uma sala? Clique aqui.</a>
          
                </div>
            </div>
        </div>
</asp:Content>

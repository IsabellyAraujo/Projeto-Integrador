<%@ Page Title="Criar Sala | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CriarSala.aspx.cs" Inherits="Projeto_Integrador.CriarSala" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="col-md-6 col-md-offset-4">
            <img src="Imagens/pessoasimprove2.png" height="200px">
        </div>
        <div class="formulario col-md-4 col-md-offset-4 col-sm-10 col-sm-offset-1">
            <div class="contact-form bottom">
                    <div class="form-group">
                        <asp:TextBox ID="Name" runat="server" type="username" class="form-control" required="required" placeholder="Nome da sala"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Password" runat="server" type="password" class="form-control" required="required" placeholder="Senha" ControlToCompare="TextBox2"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="ConfirmPassword" runat="server" type="password" class="form-control" required="required" placeholder="Confirmar senha"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="ConfirmPassword" ControlToCompare="Password"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="ButtonCriarSala" runat="server" Text="Criar sala" type="submit" name="submit" class="btn btn-submit" OnClick="ButtonCriarSala_Click" /><br />
                    </div>
                    <a href="Sala.aspx">Entre numa sala</a>

            </div>
        </div>
    </div>
</asp:Content>

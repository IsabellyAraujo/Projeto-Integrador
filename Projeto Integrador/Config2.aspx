<%@ Page Title="Configurações | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Config2.aspx.cs" Inherits="Projeto_Integrador.Config2" Theme="css" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="config col-sm-10 col-sm-offset-1 col-md-10 col-md-offset-1">
        <div class="edit col-sm-12 col-md-12">
            <div class="formularioaviso col-md-12">
                <div id="erro" runat="server" visible="false" class="col-md-10 col-md-offset-1  col-sm-12 alert alert-info fade in">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4 id="mensagem" runat="server">Algo está incorreto</h4>
                    <p>Por favor, verifique seus dados e tente novamente!</p>
                </div>
            </div>
        </div>
        <div class="imgconfig2 col-sm-6 col-md-4 col-md-offset-2">
            <div class="conteudo">
                <asp:Image ID="imagem_perfil" runat="server" Width="65%" Height="65%" class="img-rounded" />
                <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-xs btn-info"/>
                <!-- <button type="button" >FAZER UPLOAD</button> -->
            </div>
        </div>
        <div class="dados2 col-sm-6 col-md-4">
            <div class="conteudo">
                <div class="conteudo">
                    <form id="main-contact-form" name="contact-form" method="post" action="">
                        <h4>Nome completo</h4>
                        <div class="form-group">
                            <asp:TextBox ID="nome" runat="server" type="name" class="form-control" placeholder="Fulano da Silva"></asp:TextBox>
                        </div>
                        <h4>Data de nascimento:</h4>
                        <div class="form-group">
                            <asp:TextBox ID="data" runat="server" type="date" class="form-control" placeholder="Fulano da Silva"></asp:TextBox>
                        </div>
                        <h4>Email:</h4>
                        <div class="form-group">
                            <asp:TextBox ID="email" runat="server" type="email" class="form-control" placeholder="fulano@gmail.com"></asp:TextBox>
                        </div>
                    </form>
                </div>
            </div>
            <div class="edit col-sm-12 col-md-12">
                <asp:Button ID="Button1" runat="server" Text="SALVAR" type="submit" name="submit" class="btn btn-submit3" OnClick="Button1_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

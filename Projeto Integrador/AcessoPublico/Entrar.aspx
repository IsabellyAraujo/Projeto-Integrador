<%@ Page Title="Entrar | Improve" Language="C#" MasterPageFile="~/AcessoPublico/MasterPagePublica.Master" AutoEventWireup="true" CodeBehind="Entrar.aspx.cs" Inherits="Projeto_Integrador.Acesso_Público.Entrar1" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-breadcrumb">
        <div class="vertical-center sun">
            <div class="container">
                <div class="row">
                    <div class="action">
                        <div class="col-sm-12">
                            <h1 class="title">Entrar</h1>
                            <p>Bem-vindo de volta!</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="shortcodes">
        <div class="container">
            <div class="col-md-12">
                <div class="formulario col-md-4 col-md-offset-4 col-sm-12">
                    <div class="contact-form bottom">
                        <asp:Login ID="Login1" name="contact-form" runat="server" Width="100%" DestinationPageUrl="~/Home.aspx" OnAuthenticate="Login1_Authenticate" OnLoginError="Login1_LoginError">
                            <LayoutTemplate>
                                <div id="erro" runat="server" visible="false" class="col-md-12 col-sm-12 alert alert-info fade in">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                    <h4><asp:Label ID="mensagem_erro" runat="server"></asp:Label></h4>
                                    <p>Parece que há um erro! Por favor, tente novamente.</p>
                                    <!-- <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal> -->
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="UserName" runat="server" class="form-control" required="required" placeholder="Email ou Nome de usuário" autofocus></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control" required="required" placeholder="Senha"></asp:TextBox>
                                </div>
                                <!-- <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." /> -->
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" ValidationGroup="Login1" name="submit" class="btn btn-submit" Text="ENTRAR" />
                            </LayoutTemplate>
                        </asp:Login>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


<%@ Page Title="Cadastro | Improve" Language="C#" MasterPageFile="~/AcessoPublico/MasterPagePublica.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Projeto_Integrador.Acesso_Público.Cadastro1" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script runat="server">
        void Button_Click(Object sender, EventArgs e)
        {
            string senha = CreateUserWizard1.Password.ToString();
            string confirmacao = CreateUserWizard1.ConfirmPassword.ToString();
            if (senha != confirmacao)
            {
                CreateUserWizard1.Dispose();
                CreateUserWizard1_CreateUserError(sender, new CreateUserErrorEventArgs(MembershipCreateStatus.InvalidPassword));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="page-breadcrumb">
        <div class="vertical-center sun">
            <div class="container">
                <div class="row">
                    <div class="action">
                        <div class="col-sm-12">
                            <h1 class="title">Cadastrar</h1>
                            <p>Seja bem-vindo!</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="shortcodes">
        <div class="container">
            <div class="col-md-12">
                <div class="formulario col-md-4 col-md-offset-4 col-sm-10 col-sm-offset-1">
                    <div class="contact-form bottom">
                        <asp:CreateUserWizard ID="CreateUserWizard1" name="contact-form" runat="server" Width="100%" ContinueDestinationPageUrl="~/Home.aspx" OnCreatedUser="CreateUserWizard1_CreatedUser" OnCreateUserError="CreateUserWizard1_CreateUserError" InvalidPasswordErrorMessage="Os campos senha e confirmação de senha devem combinar. Tamanho mínimo da senha: {0}. Caracteres não alfanuméricos necessários: {1}.">
                            <WizardSteps>
                                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                    <ContentTemplate>
                                        <div id="erro" runat="server" visible="false" class="col-md-12 col-sm-12 alert alert-info fade in">
                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                            <asp:CompareValidator ID="PasswordCompare" runat="server" ErrorMessage="Os campos senha e confirmação de senha devem combinar." ControlToCompare="Password" ControlToValidate="ConfirmPassword" ValidationGroup="CreateUserWizard1" Display="Dynamic"></asp:CompareValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="UserName" runat="server" class="form-control" required="required" placeholder="Nome de usuário" autofocus></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="Email" runat="server" class="form-control" required="required" placeholder="Email" TextMode="Email"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="Password" runat="server" class="form-control" required="required" placeholder="Senha" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="ConfirmPassword" runat="server" class="form-control" required="required" placeholder="Confirmar senha" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </ContentTemplate>
                                    <CustomNavigationTemplate>
                                        <div class="form-group">
                                            <asp:Button ID="StepNextButton" class="btn btn-submit" runat="server" CommandName="MoveNext" Text="CADASTRAR" ValidationGroup="CreateUserWizard1" OnClick="Button_Click" />
                                        </div>
                                    </CustomNavigationTemplate>
                                </asp:CreateUserWizardStep>
                                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" OnActivate="CompleteWizardStep1_Activate"></asp:CompleteWizardStep>
                            </WizardSteps>
                        </asp:CreateUserWizard>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

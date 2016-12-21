<%@ Page Title="Alterar Senha" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="Projeto_Integrador.AlterarSenha" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" class="col-md-8 col-md-offset-2">
        <asp:ChangePassword ID="ChangePassword1" runat="server" OnChangePasswordError="ChangePassword1_ChangePasswordError" Width="50%">
            <ChangePasswordTemplate>
                <div id="erro" runat="server" visible="false" class="col-md-12 col-sm-12 alert alert-info fade in">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="Os campos confirmar senha e nova senha devem ser iguais." ValidationGroup="ChangePassword1"></asp:CompareValidator>
                </div>
                <h3 style="text-align: center;">Senha atual</h3>
                <div class="form-group">
                    <asp:TextBox ID="CurrentPassword" runat="server" class="form-control" TextMode="Password" required="required" placeholder="*******"></asp:TextBox>
                </div>
                <h3 style="text-align: center;">Nova senha</h3>
                <div class="form-group">
                    <asp:TextBox ID="NewPassword" runat="server" class="form-control" TextMode="Password" required="required" placeholder="*******"></asp:TextBox>
                </div>
                <h3 style="text-align: center;">Confirmar senha</h3>
                <div class="form-group">
                    <asp:TextBox ID="ConfirmNewPassword" runat="server" class="form-control" TextMode="Password" required="required" placeholder="*******"></asp:TextBox>
                </div>
                <div class="alterarsenha">
                    <asp:Button ID="ChangePasswordPushButton" runat="server" class="btn btn-submit" Style="width: 100%; margin-top: 25px;" CommandName="ChangePassword" Text="Alterar Senha" ValidationGroup="ChangePassword1" OnClick="ChangePassword1_Click"/>
                </div>
            </ChangePasswordTemplate>
            <SuccessTemplate>
                Senha alterada com sucesso!!!
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Voltar para a página inicial</asp:HyperLink>
            </SuccessTemplate>
        </asp:ChangePassword>
    </div>
</asp:Content>

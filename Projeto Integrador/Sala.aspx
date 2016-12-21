<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Sala.aspx.cs" Inherits="Projeto_Integrador.Sala" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="saladeestudo col-md-12">
        <div class="nomedasala">
            <text align="center"><h1>NOME DA SALA</h1></text>
        </div>
        <div class="componentes col-md-4">
            <div class="componentestitulo">
                <text align="center"><h2>COMPONENTES</h2></text>
            </div>
            <div class="nomecomponente">
                <img src="images/icon.png" class="img-circle" alt="Foto do perfil" height="80">
                <text align="center">FULANO</text>
            </div>
            <div class="nomecomponente">
                <img src="images/icon.png" class="img-circle" alt="Foto do perfil" height="80">
                <text align="center">FULANO2</text>
            </div>
            <input type="submit" value="sair" class="btn btn-submit" style="width: 20%; margin-left: 40%;" />
        </div>
        <div class="conversa col-md-8">
            <div class="balao">
                <div class="balaoconversanome">
                    <p>Amanda Alves</p>
                </div>
                <div class="balaoconversa">
                    oi
                </div>
            </div>
            <div class="balao">
                <div class="balaoconversausuarionome">
                    <p align="right">eu</p>
                </div>
                <div class="balaoconversausuario">
                    oi
                </div>
            </div>
        </div>
        <div class="digitar col-md-8">
            <textarea rows="3" cols="80"></textarea>
            <input type="submit" value="ENVIAR" class="btn btn-submit" style="width: 15%; height: 80%; margin-top: -9%;" />
        </div>
    </div>
</asp:Content>

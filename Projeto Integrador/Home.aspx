<%@ Page Title="Home | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Projeto_Integrador.Home" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-12 col-md-10 col-md-offset-1">
        <table class="table table-bordered text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
            <thead>
                <tr>
                    <th>MENSAGENS</th>
                    <th>EVENTOS</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Você tem x mensagens não lidas.<br>
                        <a href="salas.html">Clique aqui para visualizar</a></td>
                    <td>Você tem x eventos próximos para esta semana.<br>
                        <a href="agenda.html">Clique aqui para visualizar</a></td>
                </tr>
            </tbody>
        </table>
        <table class="table table-bordered text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="600ms">
            <thead>
                <tr>
                    <th>TAREFAS</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                         
                        
                    </td>
                </tr>
            </tbody>
        </table>

        <table class="table table-bordered text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="900ms">
            <thead>
                <tr>
                    <th>ANOTAÇÕES</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                       
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

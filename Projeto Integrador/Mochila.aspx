<%@ Page Title="Mochila | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mochila.aspx.cs" Inherits="Projeto_Integrador.Mochila" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="descricao" HeaderText="descricao" SortExpression="descricao" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo3ConnectionString %>" SelectCommand="SELECT [descricao] FROM [Arquivo] WHERE ([usuario_id] = @usuario_id)">
        <SelectParameters>
            <asp:SessionParameter Name="usuario_id" SessionField="userId" Type="Object" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

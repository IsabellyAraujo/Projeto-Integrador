<%@ Page Title="Mochila | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mochila.aspx.cs" Inherits="Projeto_Integrador.Mochila" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-sm-12 col-md-10 col-md-offset-1" class="table table-bordered text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
         <h1>MOCHILA</h1>
         <div id="upload">
             <asp:FileUpload ID="FileUploadMochila" runat="server" text="Escolha um arquivo" class="btn btn-submit2" />
            <asp:Button ID="ButtonEnviarArquivo" runat="server" Text="Enviar" class="btn btn-submit2" OnClick="ButtonEnviarArquivo_Click" />
        </div>
         <div id="seusarquivos">
         </div>
     </div>
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="descricao" HeaderText="descricao" SortExpression="descricao" />
        </Columns>
    </asp:GridView>--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo3ConnectionString %>" SelectCommand="SELECT [descricao] FROM [Arquivo] WHERE ([usuario_id] = @usuario_id)">
        <SelectParameters>
            <asp:SessionParameter Name="usuario_id" SessionField="userId" Type="Object" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

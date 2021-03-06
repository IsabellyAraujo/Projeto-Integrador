﻿<%@ Page Title="Mochila | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mochila.aspx.cs" Inherits="Projeto_Integrador.Mochila" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-sm-12 col-md-10 col-md-offset-1" class="table table-bordered text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
         <h1>MOCHILA</h1>
         <%--inserir--%>
         <div id="upload">
             <asp:FileUpload ID="FileUploadMochila" runat="server" text="Escolha um arquivo" class="btn btn-submit2" Visible="True" />
            <asp:Button ID="ButtonEnviarArquivo" runat="server" Text="Enviar" class="btn btn-submit2" OnClick="ButtonEnviarArquivo_Click" />
        </div>
         <div id="seusarquivos">
              <asp:TextBox ID="TextBoxDescricaoArquivoEditar" Visible="false" runat="server"  ></asp:TextBox>
              <asp:Button ID="ButtonSalvarDescricaoArquivo" Visible="false" runat="server" Text="Salvar" OnClick="ButtonSalvarDescricaoArquivo_Click" />

             <asp:DataList ID="DataListMochila" runat="server" DataSourceID="ObjectDataSourceMochila" OnItemCommand="DataListMochila_ItemCommand" OnItemDataBound="DataListMochila_ItemDataBound">
              
                 <ItemTemplate>
                     &nbsp;<asp:Label ID="LabelDescricaoArquivo" runat="server" Text='<%# Eval("descricao") %>' />
                     <br />
                     <asp:Image ID="ImageArquivoInserido" Width="250px" runat="server" ImageUrl='<%# Eval("endereco") %>' />
                     <br />
                     <asp:LinkButton ID="LinkButtonEditarDescricaoArquivo" OnClick="LinkButtonEditarDescricaoArquivo_Click" OnPreRender="LinkButtonEditarDescricaoArquivo_PreRender" runat="server">Editar</asp:LinkButton>
                     &nbsp;<asp:LinkButton ID="LinkButtonExcluirArquivo" OnPreRender="LinkButtonExcluirArquivo_PreRender" runat="server" OnClick="LinkButtonExcluirArquivo_Click">Excluir</asp:LinkButton>
                    &nbsp; <asp:LinkButton ID="LinkButtonDownloadArquivo" OnPreRender="LinkButtonDownloadArquivo_PreRender" runat="server" OnClick="LinkButtonDownloadArquivo_Click">Download</asp:LinkButton>
                     <br />
                     <br />
                 </ItemTemplate>
             </asp:DataList>
         </div>
     </div>
   
    <asp:ObjectDataSource ID="ObjectDataSourceMochila" runat="server" SelectMethod="SelectAll" TypeName="Projeto_Integrador.DAL.DALMochila">
        <SelectParameters>
            <asp:SessionParameter Name="user_id" SessionField="userId" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
   
</asp:Content>

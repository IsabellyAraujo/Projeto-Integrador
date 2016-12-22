<%@ Page Title="Anotações e Tarefas | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AnotacaoETarefa.aspx.cs" Inherits="Projeto_Integrador.AnotacoesETarefa" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6" style="text-align: center">
        <h1>TAREFAS</h1>
    </div>
    <div class="col-md-6" style="text-align: center">
        <h1>ANOTAÇÕES</h1>
    </div>
    <div class="tarefa col-sm-10 col-sm-offset-1 col-md-4 wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
        <div class="botaocriaranotacao col-sm-12 col-md-12">
            <asp:Button ID="Button1" runat="server" Text="CRIAR" class="btn btn-submitcriar" OnClick="Button1_Click" />
        </div>
        <div id="divum" style="display: none; padding-top: 2%;">
            <input type="text" class="form-control" id="textoanotacao">
            <button type="submit" class="btn btn-submitsalvar">SALVAR</button>
        </div>
        <div class="texto col-md-12 col-sm-12">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Digite sua anotação" Visible="False" Width="100%" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="BotaoSalvar1" runat="server" class="btn btn-submitsalvar" Text="Salvar" Visible="False" />
            <br>
        </div>
        <div class="configtexto col-md-12 col-sm-12">
            <a href="#">
                <img src="Imagens/fav.png" height="30"></a>&nbsp;&nbsp;&nbsp;
					
            <a href="#">RISCAR</a>&nbsp;&nbsp;&nbsp;
					
            <a href="#">EDITAR</a>&nbsp;&nbsp;&nbsp;
					
            <a href="#">EXCLUIR</a>
        </div>
        <div class="portfolio-pagination">
            <ul class="pagination">
                <li><a href="#">left</a></li>
                <li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li><a href="#">6</a></li>
                <li><a href="#">right</a></li>
            </ul>
        </div>
    </div>
    <div class="anotacao col-sm-12 col-md-4 col-md-offset-2 wow fadeIn" data-wow-duration="1000ms" data-wow-delay="600ms">
        <div class="botaocriaranotacao col-sm-12 col-md-12">
            <asp:Button ID="ButtonAnotacoes" runat="server" Text="CRIAR" class="btn btn-submitcriar" OnClick="ButtonAnotacoes_Click" />


            <div class="texto col-md-12 col-sm-12">
                &nbsp;<asp:Label ID="LabelAnotacoesTitulo" runat="server" Text="Titulo" Visible="False"></asp:Label>
                <asp:TextBox ID="TextBoxAnotacoesTitulo" runat="server" Visible="False"></asp:TextBox>
                <br />
                <asp:Label ID="LabelAnotacoesDescricao" runat="server" Text="Anotação" Visible="False"></asp:Label>
            </div>
            <asp:TextBox ID="TextBoxAnotacoesDescricao" runat="server" placeholder="Digite sua anotação" Visible="False" Width="100%" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonSalvarAnotacoes" runat="server" class="btn btn-submitsalvar" Text="Salvar" Visible="False" OnClick="ButtonSalvarAnotacoes_Click" />
            <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
                <ItemTemplate>
                    <asp:Label ID="LabelAnotacoesId" runat="server" OnPreRender="LabelAnotacoesId_PreRender" Text='<%# Eval("id") %>'></asp:Label>
                    <asp:Label ID="tituloLabel" runat="server" Text='<%# Eval("titulo") %>' Font-Bold="True" />
                    <br />
                    <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                    <br />
                    <asp:Label ID="LabelTituloAnotacoesEditar" runat="server" Text="Titulo" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBoxAnotacoesTituloEditar" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="LabelAnotacoesDescricaoEditar" runat="server" Text="Descrição" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBoxAnotacoesDescricaoEditar" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
                    <br />
                    <a href="#">
                        <asp:Image ID="ImageFavorito" runat="server" ImageUrl="~/Imagens/fav.png" Width="30" Height="30" OnPreRender="ImageFavorito_PreRender" />

                        <div class="configtexto col-md-12 col-sm-12">
                            &nbsp;<asp:ImageButton ID="ImageButtonFavoritarAnotacoes" runat="server" ImageUrl="~/Imagens/fav.png" OnClick="ImageButtonFavoritarAnotacoes_Click" OnPreRender="ImageButtonFavoritarAnotacoes_PreRender" Width="30px" />
                            &nbsp;&nbsp;
                                   
                            <asp:LinkButton ID="LinkButtonEditarAnotacoes" runat="server" OnPreRender="LinkButtonEditarAnotacoes_PreRender" OnClick="LinkButtonEditarAnotacoes_Click">EDITAR</asp:LinkButton>
                            &nbsp;
                                   
                            <asp:LinkButton ID="LinkButtonExcluirAnotacoes" runat="server" OnClick="LinkButtonExcluirAnotacoes_Click" OnPreRender="LinkButtonExcluirAnotacoes_PreRender">EXCLUIR</asp:LinkButton>
                        </div></div>
                           
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectAll" TypeName="Projeto_Integrador.DAL.DALAnotacao">
                <SelectParameters>
                    <asp:SessionParameter Name="user_id" SessionField="userId" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br>
        </div>
        <%--<div class="portfolio-pagination">
                    <ul class="pagination">
                      <li><a href="#">left</a></li>
                      <li class="active"><a href="#">1</a></li>
                      <li><a href="#">2</a></li>
                      <li><a href="#">3</a></li>
                      <li><a href="#">4</a></li>
                      <li><a href="#">5</a></li>
                      <li><a href="#">6</a></li>
                      <li><a href="#">right</a></li>
                    </ul>
					</div>--%>
</asp:Content>

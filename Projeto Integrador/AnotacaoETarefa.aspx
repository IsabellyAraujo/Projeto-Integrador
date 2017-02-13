<%@ Page Title="Anotações e Tarefas | Improve" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AnotacaoETarefa.aspx.cs" Inherits="Projeto_Integrador.AnotacoesETarefa" Theme="css" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- TAREFAS -->
    <div class="col-md-6" style="text-align: center">
        <h1>TAREFAS</h1>
        <p>&nbsp;</p>
        <div class="tarefa col-sm-10 col-sm-offset-1 col-md-4 wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
            <div class="botaocriaranotacao col-sm-12 col-md-12">
             <asp:Button ID="ButtonCriarTarefas" runat="server" Text="CRIAR" class="btn btn-submitcriar" OnClick="ButtonTarefas_Click" />
             </div>
            <div class="texto col-md-12 col-sm-12">
                <asp:Label ID="LabelTarefaDescricao" runat="server" Text="Descrição" Visible="False"></asp:Label>
                <asp:TextBox ID="TextBoxTarefaDescricao" runat="server" Visible="False" placeholder="Digite sua Tarefa"></asp:TextBox>
                <br />
                <asp:Button ID="ButtonSalvarTarefas" runat="server" class="btn btn-submitsalvar" Text="Salvar" Visible="False" OnClick="ButtonSalvarTarefa_Click" />
            </div>
            <asp:DataList ID="DataListTarefa" runat="server" DataSourceID="ObjectDataSourceTarefa">
                <ItemTemplate>
                    <%-- favoritar --%>
                    <asp:Label ID="LabelTarefasId" runat="server" OnPreRender="LabelTarefasId_PreRender" Text='<%# Eval("id") %>'></asp:Label>
                        <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                    <br />
                    
                    <%-- editar --%>
                    <asp:Label ID="LabelTarefasDescricaoEditar" runat="server" Text="Descrição" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBoxTarefasDescricaoEditar" runat="server" Height="21px" TextMode="MultiLine" Visible="False" Width="158px"></asp:TextBox>
                     <asp:Image ID="ImagePrioridade" runat="server" ImageUrl="~/Imagens/fav.png" Width="30" Height="30" OnPreRender="ImagePrioridade_PreRender" />
                    <%-- config --%>
                     <div class="configtexto col-md-12 col-sm-12">
                         <asp:ImageButton ID="ImageButtonFavoritarAnotacoes" runat="server" ImageUrl="~/Imagens/fav.png" OnClick="ImageButtonPriorizarTarefa_Click" OnPreRender="ImageButtonPriorizarTarefa_PreRender" Width="30px" />
                         <asp:LinkButton ID="LinkButtonEditarTarefas" runat="server" OnPreRender="LinkButtonEditarTarefas_PreRender" OnClick="LinkButtonEditarTarefas_Click">EDITAR</asp:LinkButton>
                         <asp:LinkButton ID="LinkButtonExcluirTarefas" runat="server" OnClick="LinkButtonExcluirTarefas_Click" OnPreRender="LinkButtonExcluirTarefas_PreRender">EXCLUIR</asp:LinkButton>
                     </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSourceTarefa" runat="server" SelectMethod="SelectAll" TypeName="Projeto_Integrador.DAL.DALTarefa">
                <SelectParameters>
                    <asp:SessionParameter Name="user_id" SessionField="userId" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
       
        </div>
     
    </div>
    <!-- ANOTAÇÕES -->
    <div class="col-md-6" style="text-align: center">
        <h1>ANOTAÇÕES</h1>
        <div class="anotacao col-sm-12 col-md-4 col-md-offset-2 wow fadeIn" data-wow-duration="1000ms" data-wow-delay="600ms">
            <div class="botaocriaranotacao col-sm-12 col-md-12">
                <asp:Button ID="ButtonAnotacoes" runat="server" Text="CRIAR" class="btn btn-submitcriar" OnClick="ButtonAnotacoes_Click" />
                <div class="texto col-md-12 col-sm-12">
                    &nbsp;<asp:Label ID="LabelAnotacoesTitulo" runat="server" Text="Titulo" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBoxAnotacoesTitulo" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="LabelAnotacoesDescricao" runat="server" Text="Anotação" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBoxAnotacoesDescricao" runat="server" placeholder="Digite sua anotação" Visible="False" Width="100%" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <asp:Button ID="ButtonSalvarAnotacoes" runat="server" class="btn btn-submitsalvar" Text="Salvar" Visible="False" OnClick="ButtonSalvarAnotacoes_Click" />
                </div>
               <!--Exibição de dados-->
                 <asp:DataList ID="DataListAnotacao" runat="server" DataSourceID="ObjectDataSourceAnotacao">
                <ItemTemplate>
                    <%-- inserir --%>
                    <asp:Label ID="LabelAnotacoesId" runat="server" OnPreRender="LabelAnotacoesId_PreRender" Text='<%# Eval("id") %>'></asp:Label>
                    <asp:Label ID="tituloLabel" runat="server" Text='<%# Eval("titulo") %>' Font-Bold="True" />
                    <br />
                    <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                    <br />
                    <%-- editar --%>
                    <asp:Label ID="LabelTituloAnotacoesEditar" runat="server" Text="Titulo" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBoxAnotacoesTituloEditar" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="LabelAnotacoesDescricaoEditar" runat="server" Text="Descrição" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBoxAnotacoesDescricaoEditar" runat="server" Height="21px" TextMode="MultiLine" Visible="False" Width="158px"></asp:TextBox>
                    &nbsp;<br /><a href="#">
                        <!--favorito-->
                    <asp:Image ID="ImageFavorito" runat="server" ImageUrl="~/Imagens/fav.png" Width="30" Height="30" OnPreRender="ImageFavorito_PreRender" />
                    <div class="configtexto col-md-12 col-sm-12">
                        &nbsp;<asp:ImageButton ID="ImageButtonFavoritarAnotacoes" runat="server" ImageUrl="~/Imagens/fav.png" OnClick="ImageButtonFavoritarAnotacoes_Click" OnPreRender="ImageButtonFavoritarAnotacoes_PreRender" Width="30px" />
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButtonEditarAnotacoes" runat="server" OnPreRender="LinkButtonEditarAnotacoes_PreRender" OnClick="LinkButtonEditarAnotacoes_Click">EDITAR</asp:LinkButton>
                            &nbsp;
                        <asp:LinkButton ID="LinkButtonExcluirAnotacoes" runat="server" OnClick="LinkButtonExcluirAnotacoes_Click" OnPreRender="LinkButtonExcluirAnotacoes_PreRender">EXCLUIR</asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSourceAnotacao" runat="server" SelectMethod="SelectAll" TypeName="Projeto_Integrador.DAL.DALAnotacao">
                <SelectParameters>
                    <asp:SessionParameter Name="user_id" SessionField="userId" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br/>
            </div>
        </div>
    </div>
</asp:Content>

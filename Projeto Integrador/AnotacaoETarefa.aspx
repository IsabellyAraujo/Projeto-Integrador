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
					<div id="divum" style="display:none; padding-top:2%;">
						<input type="text" class="form-control" id="textoanotacao">
						<button type="submit" class="btn btn-submitsalvar">SALVAR</button>
					</div>
					<div class="texto col-md-12 col-sm-12">
						<asp:TextBox ID="TextBox1" runat="server" placeholder="Digite sua anotação" Visible="False" Width="100%"></asp:TextBox>
                        <br />
                        <asp:Button ID="BotaoSalvar1" runat="server"  class="btn btn-submitsalvar" Text="Salvar" Visible="False" />
                        <br>		
					</div>
					<div class="configtexto col-md-12 col-sm-12">
						<a href="#"><img src="Imagens/fav.png" height="30"></a>&nbsp;&nbsp;&nbsp;
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
					<a href="#" onclick="abrefecha('divdois');">
					<button type="button" class="btn btn-submitcriar">CRIAR</button>
					</a>
					</div>
					<div id="divdois" style="display:none; padding-top:2%;">
						<input type="text" class="form-control" id="textoanotacao">
						<button type="submit" class="btn btn-submitsalvar">SALVAR</button>
					</div>
					<div class="texto col-md-12 col-sm-12">
						Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
						Etiam eget ligula eu lectus lobortis condimentum.<br>		
					</div>
					<div class="configtexto col-md-12 col-sm-12">
						<a href="#"><img src="Imagens/fav.png" height="30"></a>&nbsp;&nbsp;&nbsp;
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
</asp:Content>

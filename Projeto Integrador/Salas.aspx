<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salas.aspx.cs" Inherits="Projeto_Integrador.Salas" Theme="css" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<div class="col-sm-12 col-md-10 col-md-offset-1" class="table table-bordered text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
					  <h1 style="text-align:center;">SALAS</h1><br/>
					  <table>
						  <tr>
							  <th>
								<div class="entrarecriarsala">
                                    <asp:Button ID="ButtonCriarSalaRed" class="btn btn-submit" OnClick="ButtonCriarSalaRed_Click"    runat="server" Text="CRIAR" />
							  </div>	
							</th>
						  </tr>
					  </table>
					 <text align="center"><h2>SUAS SALAS</h2></text>
					  <table>
						  <tr>
							  <th>
								<div class="entrarecriarsala">
                              
								 <input type="submit" value="SALA 1" class="btn btn-submit" onclick="window.location='htmldasala.html';" />  
							  </div>	
							</th>
							  <th>
								  <div class="entrarecriarsala">
									   <input type="submit" value="SALA 2" class="btn btn-submit" onclick="window.location='htmldasala.html';" />  
								  </div>
							  </th>
						  </tr>
					  </table>
						<br/>
						
				</div>
 
</asp:Content>

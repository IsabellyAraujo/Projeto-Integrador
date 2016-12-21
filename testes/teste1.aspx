<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teste1.aspx.cs" Inherits="testes.teste1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="CRIAR" />
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource1" Enabled="False" EnableModelValidation="False" Height="50px" OnPageIndexChanging="DetailsView1_PageIndexChanging" Width="125px">
            <Fields>
                <asp:BoundField DataField="titulo" HeaderText="titulo" SortExpression="titulo" />
                <asp:BoundField DataField="descricao" HeaderText="descricao" SortExpression="descricao" />
                <asp:CheckBoxField DataField="favorito" HeaderText="favorito" SortExpression="favorito" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo3ConnectionString %>" SelectCommand="SELECT [titulo], [descricao], [favorito] FROM [Anotacao]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>

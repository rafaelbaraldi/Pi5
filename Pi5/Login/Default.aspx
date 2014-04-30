<%@ Page Title="" Language="C#" MasterPageFile="~/eventos.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pi5.Login.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <br />
    <asp:Label ID="Label1" runat="server" Text="E-mail: " />
    <asp:TextBox ID="txtMail" runat="server" />
    
    <br />
    <asp:Label ID="Label2" runat="server" Text="Senha: " />
    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" /> 

    <br /><br />

    <asp:Button runat="server" ID="btnLogar" OnClick="btnLogar_Click" Text="Logar" />

    <br /><br />

    <asp:Literal ID="litMensagem" runat="server" Visible="false"></asp:Literal>
    <br />

    <br />
    <br />

    <asp:LinkButton runat="server" ID="lbtnSenha" Text="Esqueceu a senha" OnClick="lbtnSenha_Click" />

    <br />
    <br />
    <asp:Label runat="server" Text="Email: " ID="lblMail" Visible="false" />
    <asp:TextBox runat="server" ID="txtLostPass" Visible="false" /> 
    
    <br />

    <asp:Button runat="server" ID="btnRecuperar" Text="Recuperar" OnClick="btnRecuperar_Click" Visible="false" />

</asp:Content>

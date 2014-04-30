<%@ Page Title="" Language="C#" MasterPageFile="~/eventos.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pi5.Cadastrar.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" DataKeyNames="ID" OnPageIndexChanging="gvList_PageIndexChanging" OnRowCommand="gvList_RowCommand">

        <Columns>

            <asp:TemplateField HeaderText="Nome">
                    <HeaderStyle Width="120px" />
                    <ItemStyle HorizontalAlign="Center" />                
                    <ItemTemplate><asp:Label ID="lblPreco" runat="server" Text='<%# Eval("nome") %>'/></ItemTemplate>
                </asp:TemplateField>
            
                <asp:TemplateField HeaderText="E-mail">
                    <HeaderStyle Width="160px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate><asp:Label ID="lblSub" runat="server" Text='<%# Eval("email") %>' /></ItemTemplate>
                </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Telefone">
                    <HeaderStyle Width="160px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate><asp:Label ID="Label6" runat="server" Text='<%# Eval("telefone") %>' /></ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Endereco">
                    <HeaderStyle Width="160px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate><asp:Label ID="Label7" runat="server" Text='<%# Eval("endereco") %>' /></ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Editar">
                    <HeaderStyle Width="160px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate><asp:LinkButton runat="server" ID="lbnkEditar" Text="X" AutoPostBack="true" CommandName="Excluir" CommandArgument='<%# Eval("id") %>' /></ItemTemplate>
                </asp:TemplateField>

            </Columns>

    </asp:GridView>


    <br /><br />

    <asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" />

    <br /><br />


    <asp:Label runat="server" Text="Cadastro de usuario" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Nome: " Visible="false" />
    <asp:TextBox runat="server" ID="txtNome" Visible="false" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="E-mail: " Visible="false" />
    <asp:TextBox runat="server" ID="txtEmail" Visible="false" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Senha: " Visible="false" />
    <asp:TextBox runat="server" ID="txtSenha" Visible="false" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Telefone: " Visible="false" />
    <asp:TextBox runat="server" ID="txtTelefone" Visible="false" />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Endereço: " Visible="false" />
    <asp:TextBox runat="server" ID="txtEndereco" Visible="false" />
    <br />

    <br />

    <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" Visible="false" />

    <br />

    <br />
    <br />
    <asp:Label runat="server" Text="E-mail ja cadastrado" Visible="false" ID="lblValidaEmail" />
</asp:Content>

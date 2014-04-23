<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/eventos.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pi5._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
        DataKeyNames="ID" OnPageIndexChanging="gvList_PageIndexChanging">

        <Columns>

            <asp:TemplateField HeaderText="Evento">
                <HeaderStyle Width="120px" />
                <ItemStyle HorizontalAlign="Center" />                
                <ItemTemplate><asp:Label ID="lblPreco" runat="server" Text='<%# Eval("nome") %>'/></ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Descricao">
                <HeaderStyle Width="160px" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate><asp:Label ID="lblSub" runat="server" Text='<%# Eval("descricao") %>' /></ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Local">
                <HeaderStyle Width="160px" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate><asp:Label ID="lblSub" runat="server" Text='<%# Eval("local.nome") %>' /></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unidade">
                <HeaderStyle Width="160px" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate><asp:Label ID="lblSub" runat="server" Text='<%# Eval("local.unidade.nome") %>' /></ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
        

</asp:Content>

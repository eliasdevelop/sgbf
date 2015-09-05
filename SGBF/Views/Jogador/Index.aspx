<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGBF.Views.Jogador.Index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Jogadores</h3>
            </div>
            <div class="panel-body">
                <a href="Form.aspx" title="Novo Jogador" class="btn btn-primary">Novo Jogador</a>
                <br/><br/>
                <asp:GridView ID="JogadoresList" runat="server" DataKeyNames="id" OnRowDataBound="JogadoresList_RowDataBound"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Nome" DataField="nome" />
                        <asp:BoundField HeaderText="Apelido" DataField="apelido" />
                        <asp:HyperLinkField Text="Editar" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Remover" runat="server" Text="Remover"
                                    OnClick="Delete_Click" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

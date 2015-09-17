<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGBF.Views.Jogador.Index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Filtro</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <asp:Label Text="Nome" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="nome" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Apelido" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="apelido" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Equipe" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="equipe" />
                    </div>
                </div>
                <br/>
                <div>
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Pesquisar" OnClick="Pesquisar_Click" UseSubmitBehavior="true" />
                </div>
            </div>
        </div>
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
                        <asp:BoundField HeaderText="Equipe" DataField="equipe.nome" />
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

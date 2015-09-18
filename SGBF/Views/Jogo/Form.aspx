<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="SGBF.Views.Jogo.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Editar Jogo</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">     
                            <asp:Label Text="Campeonato" runat="server" />
                            <div>
                                <asp:DropDownList ID="campeonato" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="loadJogos">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>              
                            </div>            
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Jogos</h3>
            </div>
            <div class="panel-body">
                <asp:GridView ID="JogosList" runat="server" DataKeyNames="id" OnRowDataBound="JogosList_RowDataBound"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Campeonato" DataField="campeonato.nome" />
                        <asp:BoundField HeaderText="Equipe Casa" DataField="equipe.nome" />
                        <asp:BoundField HeaderText="Equipe Fora" DataField="equipe1.nome" />
                        <asp:BoundField HeaderText="Arbitro" DataField="arbitro.nome" />
                        <asp:HyperLinkField Text="Placar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <a href="Index.aspx" title="Voltar" class="btn btn-primary">Voltar</a>
    </div>
</asp:Content>

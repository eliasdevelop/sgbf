<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SGBF.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Filtro</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">     
                            <asp:Label Text="Campeonato" runat="server" />
                            <div>
                                <asp:DropDownList ID="campeonato" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="loadTabela">
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
                <h3 class="panel-title">Tabela</h3>
            </div>
            <div class="panel-body">
                <asp:GridView ID="TabelaList" runat="server"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="#"/>
                        <asp:BoundField HeaderText="Time" DataField="equipe.nome"/>
                        <asp:BoundField HeaderText="P" DataField="num_pontuacao" />
                        <asp:BoundField HeaderText="J" DataField="quant_jogos"/>
                        <asp:BoundField HeaderText="V" DataField="vitorias" />
                        <asp:BoundField HeaderText="D"  DataField="derrotas"/>
                        <asp:BoundField HeaderText="E"  DataField="empates"/>
                        <asp:BoundField HeaderText="GP" DataField="gols_pro" />
                        <asp:BoundField HeaderText="GC" DataField="gols_contra"/>
                    </Columns>
                </asp:GridView>
            </div>
            
        </div>
    </div>
</asp:Content>

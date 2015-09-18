<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGBF.Views.Jogo.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <a href="Form.aspx" title="Editar Jogos" class="btn btn-primary">Editar Jogos</a>
        <br /><br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Novo Jogo</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">     
                            <asp:Label Text="Campeonato" runat="server" />
                            <div>
                                <asp:DropDownList ID="campeonato" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="populateEquipes">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>              
                            </div>            
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">     
                            <asp:Label Text="Equipe Casa" runat="server" />
                            <div>
                                <asp:DropDownList ID="equipeCasa" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>              
                            </div>            
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">     
                            <asp:Label Text="Equipe Fora" runat="server" />
                            <div>
                                <asp:DropDownList ID="equipeFora" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>              
                            </div>            
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">     
                            <asp:Label Text="Arbitro" runat="server" />
                            <div>
                                <asp:DropDownList ID="arbitro" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>              
                            </div>            
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">     
                            <asp:Button CssClass="btn btn-success" runat="server" Text="Salvar" OnClick="Salvar_Click" UseSubmitBehavior="true" />        
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
                <asp:GridView ID="JogosList" runat="server" DataKeyNames="id"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Campeonato" DataField="campeonato.nome" />
                        <asp:BoundField HeaderText="Equipe Casa" DataField="equipe.nome" />
                        <asp:BoundField HeaderText="Equipe Fora" DataField="equipe1.nome" />
                        <asp:BoundField HeaderText="Arbitro" DataField="arbitro.nome" />
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

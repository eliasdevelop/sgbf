<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Times.aspx.cs" Inherits="SGBF.Views.Campeonato.Times" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                    <asp:Label Text="" runat="server" CssClass="panel-title" ID="nomeCampeonato" />
            </div>
            <div class="panel-body">
                <asp:GridView ID="TimesList" runat="server" DataKeyNames="id_equipe, id_campeonato"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Time" DataField="equipe.nome" /> 
                        <asp:BoundField HeaderText="Pontuação" DataField="num_pontuacao" /> 
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
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">     
                    <asp:Label Text="Equipe" runat="server" />
                    <div>
                        <asp:DropDownList ID="equipe" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Selecione</asp:ListItem>
                        </asp:DropDownList>              
                    </div>            
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group"> 
                    <asp:Button CssClass="btn btn-success" runat="server" Text="Add Time" OnClick="Save_Click" UseSubmitBehavior="true" />
                    <a href="/Views/Campeonato/Index.aspx" title="Voltar" class="btn btn-default">Voltar</a>
                </div>
            </div>  
        </div>
    </div>
</asp:Content>

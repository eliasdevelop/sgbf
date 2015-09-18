<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Placar.aspx.cs" Inherits="SGBF.Views.Jogo.Placar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Placar</h3>
            </div>
            <div class="panel-body">
                <asp:HiddenField ID="id" runat="server" />
                
                <div class="row">
                  <div class="col-md-6">
                      <div class="form-group">
                        <asp:Label Text="Campeonato" runat="server" />
                        <div>
                            <asp:TextBox runat="server" ID="campeonato" CssClass="form-control" ReadOnly="true" />     
                        </div>    
                       </div> 
                  </div>
                  <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label Text="Arbitro" runat="server" />
                        <div>
                            <asp:TextBox runat="server" ID="arbitro" CssClass="form-control" ReadOnly="true" />
                        </div>
                    </div>
                  </div>
                </div>

                <div class="row">
                  <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label Text="Equipe Casa" runat="server" />
                        <div>
                            <asp:TextBox runat="server" ID="equipeCasa" CssClass="form-control" ReadOnly="true" />
                        </div>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label Text="Equipe Casa" runat="server" />
                        <div>
                            <asp:TextBox runat="server" ID="equipeFora" CssClass="form-control" ReadOnly="true" />
                        </div>
                    </div>
                  </div>
                </div>

                <div class="row">
                  <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label Text="Gols - Equipe Casa" runat="server" />
                        <div>
                            <asp:TextBox runat="server" ID="gols_equipe_casa" CssClass="form-control" />
                            <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                        ControlToValidate="gols_equipe_casa" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label Text="Gols - Equipe Fora" runat="server" />
                        <div>
                            <asp:TextBox runat="server" ID="gols_equipe_fora" CssClass="form-control" />
                            <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                        ControlToValidate="gols_equipe_fora" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                        </div>  
                    </div>
                  </div>
                </div>
                
                <div>
                    <asp:Button CssClass="btn btn-success" runat="server" Text="Salvar" OnClick="Save_Click" UseSubmitBehavior="true" />
                    <a href="Form.aspx" title="Cancelar" class="btn btn-default">Cancelar</a>
                </div>
            </div>
        </div>
     </div>
</asp:Content>

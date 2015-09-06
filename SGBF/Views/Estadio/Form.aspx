<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="SGBF.Views.Estadio.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Estadio</h3>
            </div>
            <div class="panel-body">
                <asp:HiddenField ID="id" runat="server" />
                
                <div>
                    <asp:Label Text="Nome" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="nome" />
                        <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                    ControlToValidate="nome" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>    
                </div> 
                <div>
                    <asp:Label Text="Capacidade" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="capacidade" />
                        <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                    ControlToValidate="capacidade" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <asp:Label Text="Cidade" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="cidade" />
                        <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                    ControlToValidate="cidade" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div>
                    <asp:Button CssClass="btn btn-success" runat="server" Text="Salvar" OnClick="Save_Click" UseSubmitBehavior="true" />
                    <a href="Index.aspx" title="Cancelar" class="btn btn-default">Cancelar</a>
                </div>
            </div>
        </div>
     </div>
</asp:Content>

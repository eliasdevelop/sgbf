<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="SGBF.Views.Jogador.Form1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Jogador</h3>
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
                    <asp:Label Text="Apelido" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="apelido" />
                    </div>
                </div>
                <div>
                    <asp:Label Text="CPF" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="cpf" />
                        <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                    ControlToValidate="cpf" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <asp:Label Text="Posição" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="posicao" />
                        <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                    ControlToValidate="posicao" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <asp:Label Text="Camisa" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="num_camisa" />
                    </div>
                </div>
                <div>
                    <asp:Label Text="Nacionalidade" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="nacionalidade" />
                        <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                    ControlToValidate="nacionalidade" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>  
                </div>
                <div>
                    <asp:Label Text="Data de Nascimento" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="data_nasc" />
                        <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                    ControlToValidate="data_nasc" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <asp:Label Text="Email" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="email" />
                    </div>
                </div>
                <div>
                    <input id="foto" type="button" class="btn btn-default" value="Upload Foto" />   
                </div>
                <br/>
                <div>
                    <asp:Button CssClass="btn btn-success" runat="server" Text="Salvar" OnClick="Save_Click" UseSubmitBehavior="true" />
                    <a href="Index.aspx" title="Cancelar" class="btn btn-default">Cancelar</a>
                </div>
            </div>
        </div>
     </div>
</asp:Content>

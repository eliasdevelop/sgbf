<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="SGBF.Views.Jogador.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="medium-12 columns">
                <h2>Jogador</h2>
                <asp:HiddenField ID="id" runat="server" />
                <div>
                    <label>
                        <asp:Label Text="Nome" runat="server" />
                        <asp:TextBox runat="server" ID="nome" />
                    </label>
                    <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                        ControlToValidate="nome" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label>
                        <asp:Label Text="Apelido" runat="server" />
                        <asp:TextBox runat="server" ID="apelido" />
                    </label>
                </div>
                <div>
                    <label>
                        <asp:Label Text="CPF" runat="server" />
                        <asp:TextBox runat="server" ID="cpf" />
                    </label>
                    <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                        ControlToValidate="cpf" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label>
                        <asp:Label Text="Posição" runat="server" />
                        <asp:TextBox runat="server" ID="posicao" />
                    </label>
                    <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                        ControlToValidate="posicao" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label>
                        <asp:Label Text="Camisa" runat="server" />
                        <asp:TextBox runat="server" ID="num_camisa" />
                    </label>
                </div>
                <div>
                    <label>
                        <asp:Label Text="Nacionalidade" runat="server" />
                        <asp:TextBox runat="server" ID="nacionalidade" />
                    </label>
                    <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                        ControlToValidate="nacionalidade" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label>
                        <asp:Label Text="Data de Nascimento" runat="server" />
                        <asp:TextBox runat="server" ID="data_nasc" />
                    </label>
                    <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                        ControlToValidate="data_nasc" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label>
                        <asp:Label Text="Email" runat="server" />
                        <asp:TextBox runat="server" ID="email" />
                    </label>
                </div>
                <div>           
                    <input id="foto" type="button" value="Upload Foto" />                
                </div>
                <div>
                    <asp:Button CssClass="button" runat="server" Text="Salvar" OnClick="Save_Click" UseSubmitBehavior="true" />
                    <a href="Index.aspx" title="Cancelar" class="button info">Cancelar</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

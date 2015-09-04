<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGBF.Views.Jogador.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="medium-12 columns">
                <h2>Jogadores</h2>
                <a href="Form.aspx" title="Novo Jogador" class="button">Novo Jogador</a>
                <asp:GridView ID="JogadoresList" runat="server" DataKeyNames="id" OnRowDataBound="JogadoresList_RowDataBound"
                    AutoGenerateColumns="false" CssClass="table" >
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
    </form>
</body>
</html>

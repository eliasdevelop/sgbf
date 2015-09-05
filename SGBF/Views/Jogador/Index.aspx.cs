using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Jogador
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadJogadores();
        }

        protected void JogadoresList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Jogador jogador = (Models.Jogador)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[2].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Jogador/Form.aspx?id=" + jogador.id;
            }
        }

        private void loadJogadores()
        {
            JogadoresList.DataSource = controller().index();
            JogadoresList.DataBind();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int jogador_id = Int32.Parse(JogadoresList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(jogador_id))
            {
                Session["flash_message"] = "Jogador removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o jogador, tente novamente.";
            }

            loadJogadores();
        }

        private JogadorController controller()
        {
            return new JogadorController();
        }
    }
}
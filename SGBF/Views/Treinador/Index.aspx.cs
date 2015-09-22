using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Treinador
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTreinadores();
        }

        protected void TreinadoresList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Treinador treinador = (Models.Treinador)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[2].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Treinador/Form.aspx?id=" + treinador.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int treinador_id = Int32.Parse(TreinadoresList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(treinador_id))
            {
                Session["flash_message"] = "Treinador removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o treinador, tente novamente.";
            }

            loadTreinadores();
        }

        private void loadTreinadores()
        {
            TreinadoresList.DataSource = controller().index();
            TreinadoresList.DataBind();
        }

        private TreinadorController controller()
        {
            return new TreinadorController();
        }
    }
}
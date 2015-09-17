using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Equipe
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadEquipes();
        }

        protected void EquipesList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Equipe equipe = (Models.Equipe)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Equipe/Form.aspx?id=" + equipe.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int equipe_id = Int32.Parse(EquipesList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(equipe_id))
            {
                Session["flash_message"] = "Equipe removida com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o equipe, tente novamente.";
            }

            loadEquipes();
        }

        private void loadEquipes()
        {
            EquipesList.DataSource = controller().index();
            EquipesList.DataBind();
        }

        private EquipeController controller()
        {
            return new EquipeController();
        }
    }
}
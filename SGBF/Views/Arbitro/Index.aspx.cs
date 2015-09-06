using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Arbitro
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadArbitros();
        }

        protected void ArbitrosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Arbitro arbitro = (Models.Arbitro)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[2].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Arbitro/Form.aspx?id=" + arbitro.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int arbitro_id = Int32.Parse(ArbitrosList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(arbitro_id))
            {
                Session["flash_message"] = "Arbitro removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o arbitro, tente novamente.";
            }

            loadArbitros();
        }

        private void loadArbitros()
        {
            ArbitrosList.DataSource = controller().index();
            ArbitrosList.DataBind();
        }

        private ArbitroController controller()
        {
            return new ArbitroController();
        }
    }
}
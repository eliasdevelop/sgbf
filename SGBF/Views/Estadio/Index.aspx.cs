using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Estadio
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadEstadios();
        }

        protected void EstadiosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Estadio estadio = (Models.Estadio)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Estadio/Form.aspx?id=" + estadio.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int estadio_id = Int32.Parse(EstadiosList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(estadio_id))
            {
                Session["flash_message"] = "Estadio removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o estadio, tente novamente.";
            }

            loadEstadios();
        }

        private void loadEstadios()
        {
            EstadiosList.DataSource = controller().index();
            EstadiosList.DataBind();
        }

        private EstadioController controller()
        {
            return new EstadioController();
        }
    }
}
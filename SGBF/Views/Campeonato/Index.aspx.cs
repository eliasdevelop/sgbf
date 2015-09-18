using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Campeonato
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadCampeonatos();
        }

        protected void CampeonatosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Campeonato campeonato = (Models.Campeonato)e.Row.DataItem;

                HyperLink times = e.Row.Cells[2].Controls[0] as HyperLink;
                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                times.NavigateUrl = "~/Views/Campeonato/Times.aspx?id=" + campeonato.id;
                edit.NavigateUrl = "~/Views/Campeonato/Form.aspx?id=" + campeonato.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int campeonato_id = Int32.Parse(CampeonatosList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(campeonato_id))
            {
                Session["flash_message"] = "Campeonato removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o campeonato, tente novamente.";
            }

            loadCampeonatos();
        }

        private void loadCampeonatos()
        {
            CampeonatosList.DataSource = controller().index();
            CampeonatosList.DataBind();
        }

        private CampeonatoController controller()
        {
            return new CampeonatoController();
        }
    }
}
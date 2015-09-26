using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGBF.Models;
using SGBF.Helpers;
using SGBF.Controllers;

namespace SGBF.Views.Jogo
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CampeonatoHelper.populate(campeonato);
            }
        }

        protected void JogosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Jogo jogo = (Models.Jogo)e.Row.DataItem;

                HyperLink placar = e.Row.Cells[4].Controls[0] as HyperLink;
                placar.NavigateUrl = "~/Views/Jogo/Placar.aspx?id=" + jogo.id;
                HyperLink escalacao = e.Row.Cells[5].Controls[0] as HyperLink;
                escalacao.NavigateUrl = "~/Views/Jogo/Escalacao.aspx?id=" + jogo.id;
            }
        }

        protected void loadJogos(object sender, EventArgs e)
        {
            if(campeonato.Text == "")
            {
                JogosList.DataSource = controller().index();
            }
            else
            {
                JogosList.DataSource = controller().find_by_campeonato(Int32.Parse(campeonato.Text));
            }     
            JogosList.DataBind();
        }

        private JogoController controller()
        {
            return new JogoController();
        }
    }
}
using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using SGBF.Models;
using SGBF.Helpers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Campeonato
{
    public partial class Times : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                loadTimes();
                EquipeHelper.populate(equipe);
            }            
        }

        private void loadTimes()
        {
            String id_campeonato = Request.QueryString["id"];
            Models.Campeonato campeonato =  CampeonatoHelper.search(id_campeonato);

            nomeCampeonato.Text = campeonato.nome + " - " + campeonato.divisao;
            TimesList.DataSource = controller().find_by(Int32.Parse(id_campeonato));
            TimesList.DataBind();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String id_campeonato = Request.QueryString["id"];

            bool saved;

            saved = create();

            if (saved)
            {
                Session["flash_message"] = "Equipe associada ao campeonato com sucesso";
                Response.Redirect("~/Views/Campeonato/Times.aspx?id=" + id_campeonato);
            }
            else
            {
                Session["error_message"] = "Falha ao associar equipe, tente novamente.";
            }
        }

        private bool create()
        {
            String id_campeonato = Request.QueryString["id"];
            Models.Campeonato campeonato = CampeonatoHelper.search(id_campeonato);
            int id_equipe = Int32.Parse(equipe.Text);
            return controller().create(id_equipe, campeonato.id);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int id_campeonato = Int32.Parse(TimesList.DataKeys[row.RowIndex]["id_campeonato"].ToString());
            int id_equipe = Int32.Parse(TimesList.DataKeys[row.RowIndex]["id_equipe"].ToString());

            if (controller().delete(id_campeonato, id_equipe))
            {
                Session["flash_message"] = "Equipe desassociada com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao desassociar Equipe, tente novamente.";
            }

            loadTimes();
        }

        

        private EquipeCampeonatoController controller()
        {
            return new EquipeCampeonatoController();
        }
    }
}
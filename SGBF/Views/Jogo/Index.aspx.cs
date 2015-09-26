using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using SGBF.Models;
using SGBF.Helpers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Jogo
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CampeonatoHelper.populate(campeonato);
                ArbitroHelper.populate(arbitro);
                loadJogos();
            }
        }

        protected void populateEquipes(object sender, EventArgs e)
        {
            ListItem selecione = equipeCasa.Items[0];
            equipeCasa.Items.Clear();
            equipeFora.Items.Clear();
            equipeCasa.Items.Add(selecione);
            equipeFora.Items.Add(selecione);
            int id_camp = Int32.Parse(campeonato.Text);
            EquipeHelper.populate_by_camp(equipeCasa, id_camp);
            EquipeHelper.populate_by_camp(equipeFora, id_camp);
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            bool saved;

            if(campeonato.Text != "" && equipeCasa.Text != "" && equipeFora.Text != "" && arbitro.Text != "")
            {
                saved = create();

                if (saved)
                {
                    Session["flash_message"] = "Jogo salvo com sucesso";
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Session["error_message"] = "Falha ao salvar o jogo, tente novamente.";
                }
            }    
        }


        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int jogo_id = Int32.Parse(JogosList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(jogo_id))
            {
                Session["flash_message"] = "Jogo removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o jogo, tente novamente.";
            }

            loadJogos();
        }

        private void loadJogos()
        {
            JogosList.DataSource = controller().index();
            JogosList.DataBind();
        }

        private bool create()
        {
            return controller().create(Int32.Parse(campeonato.Text), Int32.Parse(equipeCasa.Text), Int32.Parse(equipeFora.Text), Int32.Parse(arbitro.Text));
        }

        private JogoController controller()
        {
            return new JogoController();
        }
    }
}
using System;
using SGBF.Controllers;
using SGBF.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Equipe
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateDropDown();

            if (!IsPostBack)
            {
                String equipe_id = Request.QueryString["id"];

                if (equipe_id != null)
                {
                    Models.Equipe equipe = controller().edit(Int32.Parse(equipe_id));

                    if (equipe == null)
                    {
                        Session["error_message"] = "Equipe não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = equipe_id;
                        nome.Text = equipe.nome;
                        nome_completo.Text = equipe.nome_completo;
                        data_fundacao.Text = equipe.data_fundacao.ToString("dd/MM/yyyy");
                        estadio.Text = equipe.id_estadio.ToString();
                        treinador.Text = equipe.id_treinador.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String equipe_id = id.Value;
            bool saved;

            saved = equipe_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Equipe salva com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar a equipe, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nome.Text, nome_completo.Text, DateTime.Parse(data_fundacao.Text), estadio.Text, treinador.Text);
        }

        private bool update()
        {
            int equipe_id = Int32.Parse(id.Value);
            return controller().update(equipe_id, nome.Text, nome_completo.Text, DateTime.Parse(data_fundacao.Text), estadio.Text, treinador.Text);
        }

        private EquipeController controller()
        {
            return new EquipeController();
        }

        private void populateDropDown()
        {
            EstadioHelper.populate(estadio);
            TreinadorHelper.populate(treinador);
        }
    }
}
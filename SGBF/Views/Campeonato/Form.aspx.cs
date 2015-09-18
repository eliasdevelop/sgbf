using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Campeonato
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String campeonato_id = Request.QueryString["id"];

                if (campeonato_id != null)
                {
                    Models.Campeonato campeonato = controller().edit(Int32.Parse(campeonato_id));

                    if (campeonato == null)
                    {
                        Session["error_message"] = "Campeonato não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = campeonato_id;
                        nome.Text = campeonato.nome;
                        divisao.Text = campeonato.divisao;
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String campeonato_id = id.Value;
            bool saved;

            saved = campeonato_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Campeonato salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o campeonato, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nome.Text, divisao.Text);
        }

        private bool update()
        {
            int campeonato_id = Int32.Parse(id.Value);
            return controller().update(campeonato_id, nome.Text, divisao.Text);
        }

        private CampeonatoController controller()
        {
            return new CampeonatoController();
        }
    }
}
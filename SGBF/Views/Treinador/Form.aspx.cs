using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Treinador
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String treinador_id = Request.QueryString["id"];

                if (treinador_id != null)
                {
                    Models.Treinador treinador = controller().edit(Int32.Parse(treinador_id));

                    if (treinador == null)
                    {
                        Session["error_message"] = "Treinador não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = treinador_id;
                        nome.Text = treinador.nome;
                        salario.Text = treinador.salario.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String treinador_id = id.Value;
            bool saved;

            saved = treinador_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Treinador salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o treinador, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nome.Text, float.Parse(salario.Text));
        }

        private bool update()
        {
            int treinador_id = Int32.Parse(id.Value);
            return controller().update(treinador_id, nome.Text, float.Parse(salario.Text));
        }

        private TreinadorController controller()
        {
            return new TreinadorController();
        }
    }
}
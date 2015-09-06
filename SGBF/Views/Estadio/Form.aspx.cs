using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Estadio
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String estadio_id = Request.QueryString["id"];

                if (estadio_id != null)
                {
                    Models.Estadio estadio = controller().edit(Int32.Parse(estadio_id));

                    if (estadio == null)
                    {
                        Session["error_message"] = "Estadio não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = estadio_id;
                        nome.Text = estadio.nome;
                        capacidade.Text = estadio.capacidade.ToString();
                        cidade.Text = estadio.cidade;
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String estadio_id = id.Value;
            bool saved;

            saved = estadio_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Estadio salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o estadio, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nome.Text, Int32.Parse(capacidade.Text), cidade.Text);
        }

        private bool update()
        {
            int estadio_id = Int32.Parse(id.Value);
            return controller().update(estadio_id, nome.Text, Int32.Parse(capacidade.Text), cidade.Text);
        }

        private EstadioController controller()
        {
            return new EstadioController();
        }
    }
}
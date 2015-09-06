using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Arbitro
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String arbitro_id = Request.QueryString["id"];

                if (arbitro_id != null)
                {
                    Models.Arbitro arbitro = controller().edit(Int32.Parse(arbitro_id));

                    if (arbitro == null)
                    {
                        Session["error_message"] = "Arbitro não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = arbitro_id;
                        nome.Text = arbitro.nome;
                        idade.Text = arbitro.idade.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String arbitro_id = id.Value;
            bool saved;

            saved = arbitro_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Arbitro salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o arbitro, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nome.Text, Int32.Parse(idade.Text));
        }

        private bool update()
        {
            int arbitro_id = Int32.Parse(id.Value);
            return controller().update(arbitro_id, nome.Text, Int32.Parse(idade.Text));
        }

        private ArbitroController controller()
        {
            return new ArbitroController();
        }
    }
}
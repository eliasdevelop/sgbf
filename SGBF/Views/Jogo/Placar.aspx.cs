using System;
using SGBF.Controllers;
using SGBF.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Jogo
{
    public partial class Placar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String jogo_id = Request.QueryString["id"];

                if (jogo_id != null)
                {
                    Models.Jogo jogo = controller().edit(Int32.Parse(jogo_id));

                    if (jogo == null)
                    {
                        Session["error_message"] = "Jogo não encontrado";
                        Response.Redirect("Form.aspx");
                    }
                    else
                    {
                        id.Value = jogo_id;
                        campeonato.Text = jogo.Campeonato.nome;
                        arbitro.Text = jogo.Arbitro.nome;
                        equipeCasa.Text = jogo.Equipe.nome;
                        equipeFora.Text = jogo.Equipe1.nome;
                        gols_equipe_casa.Text = jogo.num_gol_casa.ToString();
                        gols_equipe_fora.Text = jogo.num_gol_visitante.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String jogo_id = id.Value;
            bool saved;

            saved =  update();

            if (saved)
            {
                int gols_casa = Int32.Parse(gols_equipe_casa.Text);
                int gols_fora = Int32.Parse(gols_equipe_fora.Text);

                Models.Jogo jogo = controller().edit(Int32.Parse(jogo_id));

                if (gols_casa > gols_fora)
                {
                    EquipeCampeonatoHelper.addPontuacao(jogo.id_equipe_casa, jogo.id_campeonato, 3, gols_casa, gols_fora);
                    EquipeCampeonatoHelper.addPontuacao(jogo.id_equipe_visitante, jogo.id_campeonato, 0, gols_fora, gols_casa);
                }
                else if(gols_fora > gols_casa)
                {
                    EquipeCampeonatoHelper.addPontuacao(jogo.id_equipe_visitante, jogo.id_campeonato, 3, gols_fora, gols_casa);
                    EquipeCampeonatoHelper.addPontuacao(jogo.id_equipe_casa, jogo.id_campeonato, 0, gols_casa, gols_fora);
                }
                else
                {
                    EquipeCampeonatoHelper.addPontuacao(jogo.id_equipe_casa, jogo.id_campeonato, 1, gols_casa, gols_fora);
                    EquipeCampeonatoHelper.addPontuacao(jogo.id_equipe_visitante, jogo.id_campeonato, 1, gols_fora, gols_casa);
                }

                Session["flash_message"] = "Placar salvo com sucesso";
                Response.Redirect("Form.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o placar, tente novamente.";
            }
        }

        private bool update()
        {
            int jogo_id = Int32.Parse(id.Value);
            return controller().update(jogo_id, Int32.Parse(gols_equipe_casa.Text), Int32.Parse(gols_equipe_fora.Text));
        }

        private JogoController controller()
        {
            return new JogoController();
        }
    }
}
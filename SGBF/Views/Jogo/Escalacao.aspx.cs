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
    public partial class Escalacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String jogo_id = Request.QueryString["id"];

                if (jogo_id != null)
                {
                    Models.Jogo jogo = jogoController().edit(Int32.Parse(jogo_id));

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

                        JogadorHelper.populate(titularesCasa, jogo.Equipe.id);
                        JogadorHelper.populate(reservasCasa, jogo.Equipe.id);

                        JogadorHelper.populate(titularesFora, jogo.Equipe1.id);
                        JogadorHelper.populate(reservasFora, jogo.Equipe1.id);
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {

            if (countJogadores(titularesCasa) == 11 && countJogadores(titularesFora) == 11)
            {
                if (countJogadores(reservasCasa) <= 5 && countJogadores(reservasFora) <= 5)
                {
                    if(verificarJogador(titularesCasa) && verificarJogador(titularesFora) && verificarJogador(reservasCasa) && verificarJogador(reservasFora))
                    {
                        escalarJogadores(titularesCasa, true);
                        escalarJogadores(titularesFora, true);

                        escalarJogadores(reservasCasa, false);
                        escalarJogadores(reservasFora, false);

                        Session["flash_message"] = "Jogadores escalados com sucesso";
                        Response.Redirect("Form.aspx");
                    }        
                }
                else
                {
                    Session["error_message"] = "Reservas so podem ter no maximo 5 jogadores escalados";
                }
            }
            else
            {
                Session["error_message"] = "Titulares precisa de 11 jogadores escalados";
            }
        }

        protected bool verificarJogador(CheckBoxList jogadores)
        {
            List<Models.Escalacao> partidasJogador;
            Models.Escalacao ultimoEsc;
            bool res = true;
            List<string> nomesAmarelo = new List<string>();
            List<string> nomesVermelho = new List<string>();
            foreach (ListItem item in jogadores.Items)
            {
                if (item.Selected)
                {
                    partidasJogador = escalacaoController().find_by_jogador(Int32.Parse(item.Value));
                    ultimoEsc = partidasJogador.Last();
                    if(ultimoEsc != null)
                    {
                        if (ultimoEsc.nr_cartao_amarelo == 2)
                        {
                            nomesAmarelo.Add(ultimoEsc.Jogador.nome);
                            res = false;
                        }
                        else if (ultimoEsc.nr_cartao_vermelho == 1)
                        {
                            nomesVermelho.Add(ultimoEsc.Jogador.nome);
                            res = false;
                        }
                    }
                    
                }
            }
            String jogadoresAmarelos = "";
            String jogadoresVermelhos = "";

            foreach (String nome in nomesAmarelo)
            {
                jogadoresAmarelos = jogadoresAmarelos + " " + nome;
            }

            foreach (String nome in nomesVermelho)
            {
                jogadoresVermelhos = jogadoresVermelhos + " " + nome;
            }
            Session["error_message"] = "Jogadores com 2 amarelos: " + jogadoresAmarelos + " Jogadores com vermelho: " + jogadoresVermelhos;
            return res;
        }

        private int countJogadores(CheckBoxList jogadores)
        {
            int quant = 0;
            foreach (ListItem item in jogadores.Items)
            {
                if (item.Selected)
                {
                    quant++;
                }
            }
            return quant;
        }

        private void escalarJogadores(CheckBoxList jogadores, bool titular)
        {
            foreach (ListItem item in jogadores.Items)
            {
                if (item.Selected)
                {
                    escalacaoController().create(Int32.Parse(item.Value), Int32.Parse(id.Value) , titular);
                }
            }
        }

        private JogoController jogoController()
        {
            return new JogoController();
        }

        private EscalacaoController escalacaoController()
        {
            return new EscalacaoController();
        }
    }
}
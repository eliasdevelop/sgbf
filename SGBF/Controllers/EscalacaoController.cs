using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class EscalacaoController : ApplicationController
    {

        public List<Escalacao> find_by_jogador(int id_jogador)
        {
            var con = db();

            return con.Escalacao.Where(Escalacao => Escalacao.id_jogador == id_jogador).ToList();
        }

        public bool create(int id_jogador, int id_jogo, bool titular)
        {
            var con = db();

            Escalacao escalacao = new Escalacao();
            escalacao.id_jogador = id_jogador;
            escalacao.id_jogo = id_jogo;
            escalacao.fl_titular = titular;
            escalacao.nr_cartao_amarelo = 0;
            escalacao.nr_cartao_vermelho = 0;


            con.Escalacao.Add(escalacao);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool update(int id_jogador, int id_jogo, int nr_cartao_amarelo, int nr_cartao_vermelho)
        {
            var con = db();

            Escalacao escalacao =  con.Escalacao.Find(id_jogador, id_jogo);
            escalacao.nr_cartao_amarelo = nr_cartao_amarelo;
            escalacao.nr_cartao_vermelho = nr_cartao_vermelho;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}
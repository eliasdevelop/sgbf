using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class JogadorController : ApplicationController
    {

        public List<Jogador> index()
        {
            var con = db();

            return con.Jogador.ToList();
        }


        public bool create(String cpf, String apelido, String nome, int num_camisa, String posicao,
                           String nacionalidade, DateTime data_nasc, String email )
        {
            var con = db();

            Jogador jogador = new Jogador();
            jogador.cpf = cpf;
            jogador.apelido = apelido;
            jogador.nome = nome;
            jogador.num_camisa = num_camisa;
            jogador.posicao = posicao;
            jogador.nacionalidade = nacionalidade;
            jogador.data_nasc = data_nasc;
            jogador.email = email;
            //jogador.foto = foto;
            con.Jogador.Add(jogador);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Jogador edit(int id)
        {
            var con = db();

            return con.Jogador.Find(id);
        }

        public bool update(int id, String cpf, String apelido, String nome, int num_camisa,
                           String posicao, String nacionalidade, DateTime data_nasc, String email)
        {
            var con = db();

            Jogador jogador = con.Jogador.Find(id);
            jogador.cpf = cpf;
            jogador.apelido = apelido;
            jogador.nome = nome;
            jogador.num_camisa = num_camisa;
            jogador.posicao = posicao;
            jogador.nacionalidade = nacionalidade;
            jogador.data_nasc = data_nasc;
            jogador.email = email;
            //jogador.foto = foto;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();

            Jogador jogador = con.Jogador.Find(id);
            con.Jogador.Remove(jogador);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}
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
            //return con.Jogador.SqlQuery("SELECT id, cpf, apelido, nome, num_camisa, posicao, nacionalidade," + 
            //                            "data_nasc, email, foto, id_equipe, FLOOR(DATEDIFF(DAY, data_nasc, GETDATE()) / 365.25) as idade FROM Jogador").ToList();
        }

        public List<Jogador> find_by(String nome, String apelido, String equipe)
        {
            var con = db();

            if(nome == "" && apelido == "" && equipe == "")
            {
                return con.Jogador.ToList();
            }
            else
            {
                return con.Jogador.Where(Jogador => Jogador.nome.Contains(nome) && Jogador.apelido.Contains(apelido) 
                                                                                && Jogador.Equipe.nome.Contains(equipe)).ToList();
            }           
        }


        public bool create(String cpf, String apelido, String nome, int num_camisa, String posicao,
                           String nacionalidade, DateTime data_nasc, String email, String id_equipe )
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
            if(id_equipe == "")
            {
                jogador.id_equipe = null;
            }
            else
            {
                jogador.id_equipe = Int32.Parse(id_equipe);
            }
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
                           String posicao, String nacionalidade, DateTime data_nasc, String email, String id_equipe)
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
            if(id_equipe == "")
            {
                jogador.id_equipe = null;
            }
            else
            {
                jogador.id_equipe = Int32.Parse(id_equipe);
            }

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
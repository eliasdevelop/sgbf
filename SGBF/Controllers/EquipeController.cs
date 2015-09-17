using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class EquipeController : ApplicationController
    {
        public List<Equipe> index()
        {
            var con = db();

            return con.Equipe.ToList();
        }

        public bool create(String nome, String nome_completo, DateTime data_fundacao, String id_estadio)
        {
            var con = db();

            Equipe equipe = new Equipe();
            equipe.nome = nome;
            equipe.nome_completo = nome_completo;
            equipe.data_fundacao = data_fundacao;
            //equipe.escudo = escudo;
            if (id_estadio == "")
            {
                equipe.id_estadio = null;
            }
            else
            {
                equipe.id_estadio = Int32.Parse(id_estadio);
            }

            con.Equipe.Add(equipe);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Equipe edit(int id)
        {
            var con = db();

            return con.Equipe.Find(id);
        }

        public bool update(int id, String nome, String nome_completo, DateTime data_fundacao, String id_estadio)
        {
            var con = db();

            Equipe equipe = con.Equipe.Find(id);
            equipe.nome = nome;
            equipe.nome_completo = nome_completo;
            equipe.data_fundacao = data_fundacao;
            //equipe.escudo = escudo;
            if (id_estadio == "")
            {
                equipe.id_estadio = null;
            }
            else
            {
                equipe.id_estadio = Int32.Parse(id_estadio);
            }

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();
            int rows = 0;

            try
            {
                Equipe equipe = con.Equipe.Find(id);
                con.Equipe.Remove(equipe);

                rows = con.SaveChanges();
            }
            catch(Exception ex)
            {

            }
          
            return rows.Equals(1);
        }
    }
}
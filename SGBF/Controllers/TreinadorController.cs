using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class TreinadorController : ApplicationController
    {
        public List<Treinador> index()
        {
            var con = db();

            return con.Treinador.ToList();
        }

        public bool create(String nome, float salario)
        {
            var con = db();

            Treinador treinador = new Treinador();
            treinador.nome = nome;
            treinador.salario = salario;

            con.Treinador.Add(treinador);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Treinador edit(int id)
        {
            var con = db();

            return con.Treinador.Find(id);
        }

        public bool update(int id, String nome, float salario)
        {
            var con = db();

            Treinador treinador = con.Treinador.Find(id);
            treinador.nome = nome;
            treinador.salario = salario;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();

            Treinador treinador = con.Treinador.Find(id);
            con.Treinador.Remove(treinador);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}
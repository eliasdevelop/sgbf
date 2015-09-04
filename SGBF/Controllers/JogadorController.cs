using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class JogadorController : ApplicationController
    {
        public bool create(String nome)
        {
            var con = db();

            jogador jogador = new jogador();
            jogador.nome = nome;
            con.jogadors.Add(jogador);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}
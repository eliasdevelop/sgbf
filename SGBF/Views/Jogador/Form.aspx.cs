﻿using System;
using SGBF.Controllers;
using SGBF.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGBF.Views.Jogador
{
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateDropDown();

            if (!IsPostBack)
            {
                String jogador_id = Request.QueryString["id"];

                if (jogador_id != null)
                {
                    Models.Jogador jogador = controller().edit(Int32.Parse(jogador_id));

                    if (jogador == null)
                    {
                        Session["error_message"] = "Jogador não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = jogador_id;
                        nome.Text = jogador.nome;
                        apelido.Text = jogador.apelido;
                        cpf.Text = jogador.cpf;
                        posicao.Text = jogador.posicao;
                        num_camisa.Text = jogador.num_camisa.ToString();
                        nacionalidade.Text = jogador.nacionalidade;
                        data_nasc.Text = jogador.data_nasc.ToString("dd/MM/yyyy");
                        email.Text = jogador.email;
                        equipe.Text = jogador.id_equipe.ToString();

                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String jogador_id = id.Value;
            bool saved;

            saved = jogador_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Jogador salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o jogador, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(cpf.Text, apelido.Text, nome.Text, Int32.Parse(num_camisa.Text), posicao.Text,
                                       nacionalidade.Text, DateTime.Parse(data_nasc.Text), email.Text, equipe.Text);
        }

        private bool update()
        {
            int jogador_id = Int32.Parse(id.Value);
            return controller().update(jogador_id, cpf.Text, apelido.Text, nome.Text, Int32.Parse(num_camisa.Text), posicao.Text,
                                       nacionalidade.Text, DateTime.Parse(data_nasc.Text), email.Text, equipe.Text);
        }

        private JogadorController controller()
        {
            return new JogadorController();
        }

        private void populateDropDown()
        {
            EquipeHelper.populate(equipe);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Modelo
{
    public class Usuario
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string usuario;

        public string Usuario1
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private DateTime? dataDeNascimento;

        public DateTime? DataDeNascimento
        {
            get { return dataDeNascimento; }
            set { dataDeNascimento = value; }
        }
        private string enderecoFoto;

        public string EnderecoFoto
        {
            get { return enderecoFoto; }
            set { enderecoFoto = value; }
        }

        public Usuario()
        {
            this.id = null;
            this.usuario = "";
            this.email = "";
            this.senha = "";
            this.nome = "";
            this.dataDeNascimento = null;
            this.enderecoFoto = "";
        }

        public Usuario(string aid, string ausuario, string aemail, string asenha, string anome, DateTime? adataDeNascimento, string aenderecoFoto)
        {
            this.id = aid;
            this.usuario = ausuario;
            this.email = aemail;
            this.senha = asenha;
            this.nome = anome;
            this.dataDeNascimento = adataDeNascimento;
            this.enderecoFoto = aenderecoFoto;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Modelo
{
    public class Tarefa
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public bool cumprida { get; set; }
        public bool prioritaria { get; set; }
        public DateTime horarioDeEnvio { get; set; }
        public string usuario_id { get; set; }

        public Tarefa()
        {
            this.id = 0;
            this.descricao = "";
            this.cumprida = false;
            this.prioritaria = false;
            this.horarioDeEnvio = DateTime.Now;
            this.usuario_id = "";
        }

        public Tarefa(int aid, string adescricao, bool acumprida, bool aprioritaria, DateTime ahorarioDeEnvio, string ausuario_id)
        {
            this.id = aid;   // ------------- DateTime ahorarioDeEnvio,
            this.descricao = adescricao;
            this.cumprida = acumprida;
            this.prioritaria = aprioritaria;
            this.horarioDeEnvio = ahorarioDeEnvio;
            this.usuario_id = ausuario_id;
        }
        public Tarefa(string adescricao, bool acumprida, bool aprioritaria, string ausuario_id)
        {
            this.descricao = adescricao;
            this.cumprida = acumprida;
            this.prioritaria = aprioritaria;
            this.usuario_id = ausuario_id;
        }
        public Tarefa(int aid)
        {
            this.id = aid;
        }
        public Tarefa(int aid, string adescricao)//, DateTime ahorarioDeEnvio)
        {
            this.id = aid;
            this.descricao = adescricao;
          //  this.horarioDeEnvio = ahorarioDeEnvio;
        }
        public Tarefa(int aid, string adescricao, DateTime ahorarioDeEnvio)
        {
            this.id = aid;
            this.descricao = adescricao;
            this.horarioDeEnvio = ahorarioDeEnvio;
        }
    }
}
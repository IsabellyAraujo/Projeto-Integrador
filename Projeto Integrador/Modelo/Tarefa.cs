using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Modelo
{
    public class Tarefa
    {
        public string id { get; set; }
        public string descricao { get; set; }
        public bool cumprida { get; set; }
        public bool prioritaria { get; set; }
        public DateTime horarioDeEnvio { get; set; }
        public string usuario_id { get; set; }

        public Tarefa()
        {
            this.id = "";
            this.descricao = "";
            this.cumprida = false;
            this.prioritaria = false;
            this.horarioDeEnvio = DateTime.MinValue;
            this.usuario_id = "";
        }

        public Tarefa(string aid, string adescricao, bool acumprida, bool aprioritaria, DateTime ahorarioDeEnvio, string ausuario_id)
        {
            this.id = aid;
            this.descricao = adescricao;
            this.cumprida = acumprida;
            this.prioritaria = aprioritaria;
            this.horarioDeEnvio = ahorarioDeEnvio;
            this.usuario_id = ausuario_id;
        }
    }
}
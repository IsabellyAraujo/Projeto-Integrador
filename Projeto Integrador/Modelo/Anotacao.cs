using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Modelo
{
    public class Anotacao
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public bool favorito { get; set; }
        public DateTime horarioDeEnvio { get; set; }
        public string usuario_id { get; set; }

        public Anotacao()
        {
            this.id = "";
            this.titulo = "";
            this.descricao = "";
            this.favorito = false;
            this.horarioDeEnvio = DateTime.MinValue;
            this.usuario_id = "";
        }

        public Anotacao(string aid, string atitulo, string adescricao, bool afavorito, DateTime ahorarioDeEnvio, string ausuario_id)
        {
            this.id = aid;
            this.titulo = atitulo;
            this.descricao = adescricao;
            this.favorito = afavorito;
            this.horarioDeEnvio = ahorarioDeEnvio;
            this.usuario_id = ausuario_id;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Modelo
{
    public class Mochila
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string endereco { get; set; }
        public string tamanhoArquivo { get; set; }
        public string usuario_id { get; set; }

        public Mochila()
        {
            this.id = 0;
            this.descricao = "";
            this.endereco = "";
            this.tamanhoArquivo = "";
            this.usuario_id = "";
        }

        public Mochila(int aid, string adescricao, string aendereco, string atamanhoArquivo, string ausuario_id)
        {
            this.id = aid;
            this.descricao = adescricao;
            this.endereco = aendereco;
            this.tamanhoArquivo = atamanhoArquivo;
            this.usuario_id = ausuario_id;
        }
    }
}
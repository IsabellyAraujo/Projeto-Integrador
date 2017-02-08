using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Modelo
{
    public class Mochila
    {
 
        public int id;

        public string descricao; 

        public string endereco;
        public string tamanhoArquivo;



        public string usuario_id;

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
        public Mochila(string adescricao, string aendereco, string atamanhoArquivo, string ausuario_id)
        {
            this.descricao = adescricao;
            this.endereco = aendereco;
            this.tamanhoArquivo = atamanhoArquivo;
            this.usuario_id = ausuario_id;
        }
    }
}
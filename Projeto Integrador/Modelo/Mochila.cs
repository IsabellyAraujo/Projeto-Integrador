using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Modelo
{
    public class Mochila
    {
 
        public int id;
        public string descricao
        { get; set; }
        public string endereco
        { get; set; }
        public string tamanhoArquivo;
        public DateTime horarioDeEnvio { get; set; }
        public Guid usuario_id
        { get; set; }    

        public Mochila()
        {
            this.id = 0;
            this.descricao = "";
            this.endereco = "";
            this.tamanhoArquivo = "";
            this.horarioDeEnvio = DateTime.Now;
            this.usuario_id = Guid.NewGuid(); 
        }

        public Mochila(int aid, string adescricao, string aendereco, string atamanhoArquivo, DateTime ahorarioDeEnvio, Guid ausuario_id)
        {
            this.id = aid;
            this.descricao = adescricao;
            this.endereco = aendereco;
            this.tamanhoArquivo = atamanhoArquivo;
            this.horarioDeEnvio = ahorarioDeEnvio;
            this.usuario_id = ausuario_id;
        }
        public Mochila(int aid, string adescricao, string aendereco, string atamanhoArquivo, Guid ausuario_id)
        {
            this.id = aid;
            this.descricao = adescricao;
            this.endereco = aendereco;
            this.tamanhoArquivo = atamanhoArquivo;
            this.usuario_id = ausuario_id;
        }
        public Mochila(string adescricao, string aendereco, string atamanhoArquivo, Guid ausuario_id)
        {
            this.descricao = adescricao;
            this.endereco = aendereco;
            this.tamanhoArquivo = atamanhoArquivo;
            this.usuario_id = ausuario_id;
        }
        public Mochila(int aid, string adescricao, string aendereco, string atamanhoArquivo)
        {
            this.id = aid;
            this.descricao = adescricao;
            this.endereco = aendereco;
            this.tamanhoArquivo = atamanhoArquivo;
        }
        public Mochila(int aid, string adescricao)
        {
            this.id = aid;
            this.descricao = adescricao;
        }
        public Mochila(int aid, string adescricao, DateTime ahorarioDeEnvio)
        {
            this.id = aid;
            this.descricao = adescricao;
            this.horarioDeEnvio = ahorarioDeEnvio;
        }
        public Mochila(int aid)
        {
            this.id = aid;
        }
    }
}
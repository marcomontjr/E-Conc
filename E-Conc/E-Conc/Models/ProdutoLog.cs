using System;

namespace E_Conc.Models
{
    public class ProdutoLog : BaseModel
    {
        public Produto Produto { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataLog { get; set; }

        public ProdutoLog() { }

        public ProdutoLog(Produto produto, string mensagem, DateTime dataLog)
        {
            Produto = produto;
            Mensagem = mensagem;
            DataLog = dataLog;
        }
    }
}
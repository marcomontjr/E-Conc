using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Curso : BaseModel
    {
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public List<Usuario> Usuarios { get; private set; } 
        public List<Produto> Produtos { get; private set; }        
    }
}
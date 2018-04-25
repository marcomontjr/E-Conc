using E_Conc.Enum;
using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Orientador : Usuario
    {        
        public List<Produto> Produtos { get; private set; }
        public TipoUsuario tipoUsuario = TipoUsuario.Orientador;
        public TipoUsuario TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }
        }
    }
}
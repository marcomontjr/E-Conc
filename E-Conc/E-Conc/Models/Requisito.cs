using E_Conc.Enum;

namespace E_Conc.Models
{
    public class Requisito: BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Produto Produto { get; set; }
    }
}

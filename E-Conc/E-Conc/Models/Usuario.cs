namespace E_Conc.Models
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Instituicao { get; private set; }
        public string InstituicaoSigla { get; private set; }
    }
}

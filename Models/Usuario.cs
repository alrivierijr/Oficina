namespace Oficina.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public DateTime InclusaoData {  get; set; } = DateTime.Now;
        public int InclusaoUsuarioId { get; set; }
        public DateTime AlteracaoData { get; set; }
        public int AlteracaoUsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int Nivel { get; set; } = 0;
        public bool Ativo { get; set; } = false;

    }
}

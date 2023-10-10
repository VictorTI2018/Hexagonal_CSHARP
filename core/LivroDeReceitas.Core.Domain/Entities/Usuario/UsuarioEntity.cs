namespace LivroDeReceitas.Core.Domain.Entities.Usuario
{
    public class UsuarioEntity : BaseEntity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Senha { get; set; }

        public UsuarioEntity(string nome, string email, string telefone, string senha)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Senha = senha;
        }

        public UsuarioEntity(int id, string nome, string email, string telefone, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Senha = senha;
        }
    }
}

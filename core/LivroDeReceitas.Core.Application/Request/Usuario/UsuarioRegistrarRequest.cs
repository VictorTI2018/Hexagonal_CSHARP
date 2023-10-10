namespace LivroDeReceitas.Core.Application.Request.Usuario
{
    public class UsuarioRegistrarRequest
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Senha { get; set; }
    }
}

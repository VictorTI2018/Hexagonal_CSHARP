namespace LivroDeReceitas.Core.Application.Response
{
    public abstract class ResponseBase
    {
        public List<string> Messages { get; set; } = new List<string>();

        public object? Data { get; set; }

        public bool Status { get; set; }

    }
}

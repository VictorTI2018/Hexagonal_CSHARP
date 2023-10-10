namespace LivroDeReceitas.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime? Update_At { get; set; }

        public void CreateAudit()
        {
            Created_At = DateTime.Now;
        }

        public void UpdateAudit()
        {
            Update_At = DateTime.Now;
        }
    }
}

namespace Survivor.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } // Birincil anahtar
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime ModifiedDate { get; set; } = DateTime.Now; // Güncellenme tarihi
        public bool IsDeleted { get; set; } = false; // Silinme durumu
    }
}

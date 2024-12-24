namespace Survivor.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // İlişkili Competitor listesi
        public ICollection<Competitor> Competitors { get; set; }
    }
}

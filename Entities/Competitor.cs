namespace Survivor.Entities
{
    public class Competitor : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId { get; set; }

        // İlişkili Category
        public Category Category { get; set; }
    }
}

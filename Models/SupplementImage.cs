namespace Report_API.Models
{
    public class SupplementImage
    {
        public int Id { get; set; }
        public int SupplementId { get; set; }
        public string ImageUrl { get; set; }

        public Supplement Supplement { get; set; }
    }
}

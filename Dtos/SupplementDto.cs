namespace Report_API.Dtos
{
    public class SupplementDto
        //БАД
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public string PurchaseLink { get; set; }
    }
}

namespace Report_API.Models
{
    public class Supplement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PurchaseLink { get; set; }

        public List<SupplementImage> Images { get; set; }

        public List<NutritionAssessmentSupplement> NutritionAssessmentSupplements { get; set; }
    }

}

namespace Report_API.Models
{
    public class NutritionAssessmentSupplement
    {
        public int NutritionAssessmentId { get; set; }
        public NutritionAssessment NutritionAssessment { get; set; }
        public int SupplementId { get; set; }
        public Supplement Supplement { get; set; }
    }

}

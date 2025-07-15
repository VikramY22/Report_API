namespace Report_API.Models
{
    public class NutritionAssessment
    {
        public int Id { get; set; }
        public DateTime CompletedAt { get; set; }
        public List<NutrientIntake> NutrientIntakes { get; set; }
        public List<NutritionAssessmentSupplement> NutritionAssessmentSupplements { get; set; } 
    }
}

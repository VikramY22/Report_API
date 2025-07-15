namespace Report_API.Models
{
    public class NutrientIntake
    {
        public int Id { get; set; }
        public int NutrientId { get; set; }
        public int NutritionAssessmentId { get; set; }
        public double FoodIntake { get; set; }
        public double SupplementIntake { get; set; }
        public NutritionAssessment NutritionAssessment { get; set; }

        public Nutrient Nutrient { get; set; }
    }

}

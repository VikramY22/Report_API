namespace Report_API.Dtos
{
    public class NutrientBlockDto
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Norm { get; set; } 
        public double FoodIntake { get; set; } 
        public double SupplementIntake { get; set; }
    }

}

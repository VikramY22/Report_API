namespace Report_API.Models
{
    public class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Norm { get; set; }

        public List<NutrientIntake> NutrientIntakes { get; set; }
    }
}

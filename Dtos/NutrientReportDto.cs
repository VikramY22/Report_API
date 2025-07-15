namespace Report_API.Dtos
{
    public class NutrientReportDto
    {
        public DateTime CompletedAt { get; set; }
        public List<NutrientBlockDto> CurrentIntake { get; set; }
        public List<NutrientBlockDto> AdjustedIntake { get; set; }
        public List<SupplementDto> PersonalizedSupplements { get; set; }
        public List<string> SupplementBenefits { get; set; }

        public string GroupPurchaseLink { get; set; }
    }


}

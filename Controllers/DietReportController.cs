using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Report_API.Dtos;

namespace Report_API.Controllers
{
    [ApiController]
    [Route("api/nutritionreport")]
    public class DietReportController : ControllerBase
    {
        private readonly DietDbContext _context;

        public DietReportController(DietDbContext context)
        {
            _context = context;
        }

        [HttpGet("latest")]
        public ActionResult<NutrientReportDto> GetLatestReport()
        {
            // Получаем последнюю оценку по дате
            var assessment = _context.NutritionAssessments
                .Include(a => a.NutrientIntakes)
                    .ThenInclude(ni => ni.Nutrient)
                .Include(a => a.NutritionAssessmentSupplements)
                    .ThenInclude(nas => nas.Supplement)
                        .ThenInclude(s => s.Images) 
                .OrderByDescending(a => a.CompletedAt)
                .FirstOrDefault();

            if (assessment == null)
                return NotFound();

            // Фактическое потребление (из пищи и добавок)
            var currentIntake = assessment.NutrientIntakes
                .Select(ni => new NutrientBlockDto
                {
                    Name = ni.Nutrient.Name,
                    Unit = ni.Nutrient.Unit,
                    Norm = ni.Nutrient.Norm,
                    FoodIntake = ni.FoodIntake,
                    SupplementIntake = ni.SupplementIntake
                })
                .ToList();

            // Скорректированное потребление (условное повторение текущего, но может потребоваться при необходимости можно поменять логику)
            var adjustedIntake = assessment.NutrientIntakes
                .Select(ni => new NutrientBlockDto
                {
                    Name = ni.Nutrient.Name,
                    Unit = ni.Nutrient.Unit,
                    Norm = ni.Nutrient.Norm,
                    FoodIntake = ni.FoodIntake,
                    SupplementIntake = ni.SupplementIntake
                })
                .ToList();

            var supplements = assessment.NutritionAssessmentSupplements
                .Select(nas => nas.Supplement)
                .Distinct()
                .Select(s => new SupplementDto
                {
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrls = s.Images?.Select(img => img.ImageUrl).ToList() ?? new List<string>(),
                    PurchaseLink = s.PurchaseLink
                })
                .ToList();

            //Статический список преимуществ приема БАДов
            //Решил оставить в коде, потому что блок не выглядит, будто его нужно будет часто изменять
            var supplementBenefits = new List<string>
            {
                "Устраняют витаминно-минеральный дефицит",
                "Улучшают усвоение полезных веществ из пищи",
                "Компенсируют несбалансированное питание",
                "Обеспечивают организм жизненно-важными элементами",
                "Повышают функциональные резервы организма"
            };

            //Ссылка для кнопки приобрести в списке бад
            var groupPurchaseLink = "https://example.com/buy-all";

            var report = new NutrientReportDto
            {
                CompletedAt = assessment.CompletedAt,
                CurrentIntake = currentIntake,
                AdjustedIntake = adjustedIntake,
                PersonalizedSupplements = supplements,
                SupplementBenefits = supplementBenefits,
                GroupPurchaseLink = groupPurchaseLink
            };

            return Ok(report);
        }
    }
}

//using Microsoft.EntityFrameworkCore;
//using Report_API.Models;

//обычный сидер, расскоментируйте если надо

//namespace Report_API.Controllers
//{
//    public static class DbInitializer
//    {
//        public static void Seed(DietDbContext context) 
//        {
//            if (context.NutritionAssessments.Any())
//                return; 

//            var iron = new Nutrient { Name = "Железо", Unit = "мг", Norm = 18 };
//            var vitaminC = new Nutrient { Name = "Витамин C", Unit = "мг", Norm = 90 };
//            context.Nutrients.AddRange(iron, vitaminC);

//            var supp1 = new Supplement
//            {
//                Name = "Мультивитамины A-Z",
//                Description = "Комплекс витаминов и минералов",
//                PurchaseLink = "https://example.com/buy"
//            };
//            context.Supplements.Add(supp1);
//            context.SaveChanges(); 

//            if (!context.SupplementImages.Any(img => img.SupplementId == supp1.Id))
//            {
//                var images = new List<SupplementImage>
//                {
//                    new SupplementImage { SupplementId = supp1.Id, ImageUrl = "https://example.com/image1.jpg" },
//                    new SupplementImage { SupplementId = supp1.Id, ImageUrl = "https://example.com/image2.jpg" },
//                    new SupplementImage { SupplementId = supp1.Id, ImageUrl = "https://example.com/image3.jpg" },
//                };
//                context.SupplementImages.AddRange(images);
//            }

//            var assessment = new NutritionAssessment
//            {
//                CompletedAt = DateTime.UtcNow,
//                NutrientIntakes = new List<NutrientIntake>
//                {
//                    new NutrientIntake
//                    {
//                        Nutrient = iron,
//                        FoodIntake = 10,
//                        SupplementIntake = 0
//                    },
//                    new NutrientIntake
//                    {
//                        Nutrient = vitaminC,
//                        FoodIntake = 60,
//                        SupplementIntake = 0
//                    }
//                },
//                NutritionAssessmentSupplements = new List<NutritionAssessmentSupplement>
//                {
//                    new NutritionAssessmentSupplement
//                    {
//                        Supplement = supp1
//                    }
//                }
//            };

//            context.NutritionAssessments.Add(assessment);
//            context.SaveChanges();
//        }
//    }
//}

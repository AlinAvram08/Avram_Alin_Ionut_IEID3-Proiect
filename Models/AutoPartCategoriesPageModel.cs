using Microsoft.AspNetCore.Mvc.RazorPages;
using Avram_Alin_Proiect.Data;



namespace Avram_Alin_Proiect.Models
{
    public class AutoPartCategoriesPageModel:PageModel
    {

        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Avram_Alin_ProiectContext context,
        AutoPart autopart)
        {
            var allCategories = context.Category;
            var autopartCategories = new HashSet<int>(
            autopart.AutoPartCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = autopartCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateAutoPartCategories(Avram_Alin_ProiectContext context,
        string[] selectedCategories, AutoPart autopartToUpdate)
        {
            if (selectedCategories == null)
            {
                autopartToUpdate.AutoPartCategories = new List<AutoPartCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var autopartCategories = new HashSet<int>
            ( autopartToUpdate.AutoPartCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!autopartCategories.Contains(cat.ID))
                    {
                        autopartToUpdate.AutoPartCategories.Add(
                        new AutoPartCategory
                        {
                            AutoPartID = autopartToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (autopartCategories.Contains(cat.ID))
                    {
                        AutoPartCategory courseToRemove
                        = autopartToUpdate
                        .AutoPartCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;
using VueCookApi.Data;
using VueCookApi.Models;

namespace VueCookApi.Services
{
    public class RecipeService
    {
        private readonly VueCookContext _context;

        public RecipeService(VueCookContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(Guid id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<bool> UpdateRecipeAsync(Guid id, Recipe updatedRecipe)
        {
            if (id != updatedRecipe.Id)
                return false;

            _context.Entry(updatedRecipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchRecipeAsync(Guid id, RecipeUpdateDto updates)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return false;

            var recipeType = typeof(Recipe);
            var updateType = typeof(RecipeUpdateDto);

            foreach (var property in updateType.GetProperties())
            {
                var updateValue = property.GetValue(updates);
                if (updateValue is not null)
                {
                    var recipeProperty = recipeType.GetProperty(property.Name);
                    if (recipeProperty != null && recipeProperty.CanWrite)
                    {
                        recipeProperty.SetValue(recipe, updateValue);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRecipeAsync(Guid id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return false;

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
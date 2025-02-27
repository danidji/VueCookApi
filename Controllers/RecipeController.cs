using Microsoft.AspNetCore.Mvc;
using VueCookApi.Models;
using VueCookApi.Services;

namespace VueCookApi.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipesController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _recipeService.GetRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(Guid id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null) return NotFound();
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            var newRecipe = await _recipeService.CreateRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetRecipe), new { id = newRecipe.Id }, newRecipe);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchRecipe(Guid id, [FromBody] RecipeUpdateDto updates)
        {
            var success = await _recipeService.PatchRecipeAsync(id, updates);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(Guid id, Recipe recipe)
        {
            var success = await _recipeService.UpdateRecipeAsync(id, recipe);
            if (!success) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            var success = await _recipeService.DeleteRecipeAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
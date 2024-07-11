	[Route("api/[controller]")]
		[ApiController]
		public class RecipeController : ControllerBase
		{
		    private readonly AppDbContext _context;
		
		    public RecipeController(AppDbContext context)
		    {
		        _context = context;
		    }
		
		    [HttpGet]
		    public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
		    {
		        return _context.Recipes.Include(r => r.Ingredients).ToList();
		    }
		
		    [HttpGet("{id}")]
		    public ActionResult<Recipe> GetRecipeById(int id)
	    {
		        var recipe = _context.Recipes.Include(r => r.Ingredients).FirstOrDefault(r => r.RecipeId == id);
		        if (recipe == null)
		        {
		            return NotFound();
		        }
		        return recipe;
		    }
		
		    [HttpPost]
		    public ActionResult<Recipe> CreateRecipe(Recipe recipe)
		    {
		        _context.Recipes.Add(recipe);
		        _context.SaveChanges();
		        return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, recipe);
		    }
		
		    [HttpPut("{id}")]
		    public IActionResult UpdateRecipe(int id, Recipe recipe)
	    {
		        if (id != recipe.RecipeId)
		        {
	            return BadRequest();
		        }
		
		        _context.Entry(recipe).State = EntityState.Modified;
		        _context.SaveChanges();
		        return NoContent();
		    }
		
		    [HttpDelete("{id}")]
		    public IActionResult DeleteRecipe(int id)
		    {
		        var recipe = _context.Recipes.Find(id);
		        if (recipe == null)
		        {
		            return NotFound();
		        }
		
		        _context.Recipes.Remove(recipe);
		        _context.SaveChanges();
		        return NoContent();
		    }
	}
		
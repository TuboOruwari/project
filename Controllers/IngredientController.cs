[Route("api/[controller]")]
		[ApiController]
		public class IngredientController : ControllerBase
		{
		    private readonly AppDbContext _context;
		
		    public IngredientController(AppDbContext context)
		    {
	        _context = context;
		    }
		
		    [HttpGet]
		    public ActionResult<IEnumerable<Ingredient>> GetAllIngredients()
		    {
		        return _context.Ingredients.ToList();
		    }
		
		    [HttpGet("{id}")]
		    public ActionResult<Ingredient> GetIngredientById(int id)
		    {
		        var ingredient = _context.Ingredients.Find(id);
		        if (ingredient == null)
		        {
		            return NotFound();
		        }
		        return ingredient;
		    }
		
		    [HttpPost]
		    public ActionResult<Ingredient> CreateIngredient(Ingredient ingredient)
		    {
		        _context.Ingredients.Add(ingredient);
		        _context.SaveChanges();
		        return CreatedAtAction(nameof(GetIngredientById), new { id = ingredient.IngredientId }, ingredient);
		    }
		
		    [HttpPut("{id}")]
		    public IActionResult UpdateIngredient(int id, Ingredient ingredient)
		    {
		        if (id != ingredient.IngredientId)
		        {
		            return BadRequest();
		        }
	
		        _context.Entry(ingredient).State = EntityState.Modified;
		        _context.SaveChanges();
		        return NoContent();
		    }
		
		    [HttpDelete("{id}")]
		    public IActionResult DeleteIngredient(int id)
		    {
		        var ingredient = _context.Ingredients.Find(id);
		        if (ingredient == null)
		        {
		            return NotFound();
		        }
		
		        _context.Ingredients.Remove(ingredient);
		        _context.SaveChanges();
		        return NoContent();
		    }
		}
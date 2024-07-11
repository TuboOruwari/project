 public class Recipe
	{
	  public int RecipeId { get; set; }
	  public string Name { get; set; }
	  public string Description { get; set; }
	 public string Instructions { get; 
    
        public string Category { get; set; }
	    public List<Ingredient> Ingredients { get; set; }
	}
	
		public class AppDbContext : DbContext
		{
		    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		
		    public DbSet<Recipe> Recipes { get; set; }
		    public DbSet<Ingredient> Ingredients { get; set; }
		
		    protected override void OnModelCreating(ModelBuilder modelBuilder)
		    {
		        base.OnModelCreating(modelBuilder);
		        modelBuilder.Entity<Recipe>().HasData(
		            new Recipe { RecipeId = 1, Name = "Pasta", Description = "Delicious pasta recipe", Instructions = "Boil pasta, add sauce", Category = "Italian" },
		            new Recipe { RecipeId = 2, Name = "Salad", Description = "Healthy salad recipe", Instructions = "Mix vegetables", Category = "Vegetarian" }
		        );
		
		        modelBuilder.Entity<Ingredient>().HasData(
		            new Ingredient { IngredientId = 1, Name = "Pasta", Quantity = "200", Unit = "grams", RecipeId = 1 },
		            new Ingredient { IngredientId = 2, Name = "Tomato Sauce", Quantity = "100", Unit = "ml", RecipeId = 1 },
		            new Ingredient { IngredientId = 3, Name = "Lettuce", Quantity = "1", Unit = "head", RecipeId = 2 },
		            new Ingredient { IngredientId = 4, Name = "Tomato", Quantity = "2", Unit = "pieces", RecipeId = 2 }
		        );
		    }
		}
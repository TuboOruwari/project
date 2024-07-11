﻿public void ConfigureServices(IServiceCollection services)
		{
		    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("RecipeDB"));
		    services.AddControllers();
		    services.AddEndpointsApiExplorer();
		    services.AddSwaggerGen();
		}
		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
		    if (env.IsDevelopment())
		    {
		        app.UseDeveloperExceptionPage();
		        app.UseSwagger();
		        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recipe API v1"));
		    }
		
		    app.UseHttpsRedirection();
		    app.UseRouting();
		    app.UseAuthorization();
		    app.UseEndpoints(endpoints =>
		    {
		        endpoints.MapControllers();
		    });
		}
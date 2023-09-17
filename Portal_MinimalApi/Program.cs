using Portal_MinimalApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowReactApp", builder =>
  {
    builder.AllowAnyOrigin() //WithOrigins("http://localhost:5173")
           .AllowAnyHeader()
           .AllowAnyMethod();
  });
});

builder.Services.AddTransient<IQueries, Queries>();
var app = builder.Build();

app.MapGet("/GetReferenceSites", async (IQueries queries) => await queries.GetReferenceSites());
app.MapGet("/GetThemes/{referenceSiteId}", async (int referenceSiteId, IQueries queries) => await queries.GetThemes(referenceSiteId));
app.MapGet("/GetArticles/{themeId}", async (int themeId, IQueries queries) => await queries.GetArticles(themeId));
app.MapGet("/GetArticleById/{articleId}", async (int articleId, IQueries queries) => await queries.GetArticleById(articleId));

app.UseCors("AllowReactApp");
app.Run();

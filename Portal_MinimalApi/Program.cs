using Portal_MinimalApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IQueries, Queries>();
var app = builder.Build();

app.MapGet("/GetReferenceSites", async (IQueries queries) => await queries.GetReferenceSites());
app.MapGet("/GetThemes/{referenceSiteId}", async (int referenceSiteId, IQueries queries) => await queries.GetThemes(referenceSiteId));
app.MapGet("/GetArticles/{themeId}", async (int themeId, IQueries queries) => await queries.GetArticles(themeId));
app.MapGet("/GetArticlesById/{articleId}", async (int articleId, IQueries queries) => await queries.GetArticlesById(articleId));

app.Run();

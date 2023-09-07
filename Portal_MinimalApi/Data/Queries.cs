using Portal_MinimalApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace Portal_MinimalApi.Data
{
  public class Queries : Connection, IQueries
  {
    public Queries(IConfiguration configuration) : base(configuration)
    { }

    public async Task<List<ReferenceSites>> GetReferenceSites()
    {
      try
      {
        DataTable dataTable;
        List<ReferenceSites> sites = new();
        dataTable = await ExecuteQuery("[dbo].[ReferenceSites_GET]", new List<SqlParameter>());
        foreach (DataRow row in dataTable.Rows)
        {
          sites.Add(new ReferenceSites()
          {
            Id = Convert.ToInt32(row["Id"]),
            Name = Convert.ToString(row["Name"]),
            Url = Convert.ToString(row["Url"]),
          });
        }
        return sites;
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Error: " + ex.Message);
      }
    }

    public async Task<List<Themes>> GetThemes(int referenceSiteId)
    {
      try
      {
        DataTable dataTable;
        List<Themes> themes = new();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter()
        {
          Direction = ParameterDirection.Input,
          ParameterName = "@ReferenceSiteId",
          SqlDbType = SqlDbType.Int,
          Value = referenceSiteId
        });
        dataTable = await ExecuteQuery("[dbo].[Themes_GET]", parameters);
        foreach (DataRow row in dataTable.Rows)
        {
          themes.Add(new Themes()
          {
            Id = Convert.ToInt32(row["Id"]),
            ReferenceSiteId = Convert.ToInt32(row["ReferenceSiteId"]),
            Title = Convert.ToString(row["Title"]),
            Url = Convert.ToString(row["Url"]),
          });
        }
        return themes;
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Error: " + ex.Message);
      }
    }

    public async Task<List<Articles>> GetArticles(int themeId)
    {
      try
      {
        DataTable dataTable;
        List<Articles> articles = new();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter()
        {
          Direction = ParameterDirection.Input,
          ParameterName = "@ThemeId",
          SqlDbType = SqlDbType.Int,
          Value = themeId
        });
        dataTable = await ExecuteQuery("[dbo].[Articles_GET]", parameters);
        foreach (DataRow row in dataTable.Rows)
        {
          articles.Add(new Articles()
          {
            Id = Convert.ToInt32(row["Id"]),
            ThemeId = Convert.ToInt32(row["ThemeId"]),
            Title = Convert.ToString(row["Title"]),
            Body = Convert.ToString(row["Body"]),
            Url = Convert.ToString(row["Url"]),
          });
        }
        return articles;
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Error: " + ex.Message);
      }
    }

    public async Task<Articles> GetArticlesById(int articleId)
    {
      try
      {
        DataTable dataTable;
        DataRow row;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter()
        {
          Direction = ParameterDirection.Input,
          ParameterName = "@ArticleId",
          SqlDbType = SqlDbType.Int,
          Value = articleId
        });
        dataTable = await ExecuteQuery("[dbo].[Articles_GET]", parameters);
        row = dataTable.Rows[0];
        return new Articles()
        {
          Id = Convert.ToInt32(row["Id"]),
          ThemeId = Convert.ToInt32(row["ThemeId"]),
          Title = Convert.ToString(row["Title"]),
          Body = Convert.ToString(row["Body"]),
          Url = Convert.ToString(row["Url"]),
        };
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Error: " + ex.Message);
      }
    }
  }
}

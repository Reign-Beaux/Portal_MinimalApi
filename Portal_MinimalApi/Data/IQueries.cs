﻿using Portal_MinimalApi.DTOs;
using Portal_MinimalApi.Models;

namespace Portal_MinimalApi.Data
{
  public interface IQueries
  {
    Task<List<CollapseDTO>> GetReferenceSites();
    Task<List<Themes>> GetThemes(int referenceSiteId);
    Task<List<Articles>> GetArticles(int themeId);
    Task<Articles> GetArticleById(int articleId);
  }
}

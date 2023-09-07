namespace Portal_MinimalApi.Models
{
  public class Articles : GenericModel
  {
    public int ThemeId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
  }
}

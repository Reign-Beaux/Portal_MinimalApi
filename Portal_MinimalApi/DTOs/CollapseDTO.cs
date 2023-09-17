namespace Portal_MinimalApi.DTOs
{
  public class CollapseData
  {
    public int Id { get; set; }
    public string Text { get; set; }
  }

  public class CollapseDTO
  {
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsExpanded { get; set; } = false;
    public List<CollapseData> Datas { get; set; }
  }
}

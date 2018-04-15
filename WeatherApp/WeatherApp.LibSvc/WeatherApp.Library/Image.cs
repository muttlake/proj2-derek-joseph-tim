namespace WeatherApp.Library
{
  public class Image
  {
    // required
    public string Url { get; set; }

    // all optional
    public string Title { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Album { get; set; }
  }
}
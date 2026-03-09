using System.Text.Json.Serialization;

namespace BingDailyWallpaper.Models;

public class BingWallpaperResponse
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }
    [JsonPropertyName("startdate")]
    public required string StatDate { get; set; }
    [JsonPropertyName("fullstartdate")]
    public required string FullStartDate { get; set; }
    [JsonPropertyName("enddate")]
    public required string EndDate { get; set; }
}

public class BingResponse
{
    [JsonPropertyName("images")]
    public BingWallpaperResponse[]? Images { get; set; }
}
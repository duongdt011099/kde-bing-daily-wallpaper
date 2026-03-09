namespace BingDailyWallpaper.Abstractions;

public interface IBingWallpaperDownloader
{
    Task<string?> DownloadWallpaperAsync(int idx = 0);
}
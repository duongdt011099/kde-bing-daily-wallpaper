using System.Diagnostics;
using BingDailyWallpaper.Abstractions;

namespace BingDailyWallpaper.DesktopEnvironments;

public class XfceEnvironment : IDesktopEnvironment
{
    public void SetWallpaper(string imagePath)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        psi.ArgumentList.Add("-c");
        psi.ArgumentList.Add("xfconf-query -c xfce4-desktop -l | grep last-image");

        using var monitorProcess = Process.Start(psi);

        if (monitorProcess != null)
        {
            string output = monitorProcess.StandardOutput.ReadToEnd();
            monitorProcess.WaitForExit();

            if (!string.IsNullOrEmpty(output))
            {
                var correctMonitor = output.Split('\n').First();

                if (!string.IsNullOrEmpty(correctMonitor))
                {
                    psi.ArgumentList.Clear();
                    psi.ArgumentList.Add("-c");
                    psi.ArgumentList.Add($"xfconf-query -c xfce4-desktop -p {correctMonitor} -s \"{imagePath}\"");

                    using var process = Process.Start(psi);
                    process?.WaitForExit();
                }
            }
        }
    }
}
using System.Diagnostics;
using System.IO;
using NativeZipTools.Core.Interfaces;

namespace NativeZipTools.Engine.SevenZip;

/// <summary>
/// V1 Compression Engine utilizing the 7-Zip CLI binary interface.
/// </summary>
public class SevenZipEngine : ICompressionEngine
{
    private readonly string _sevenZipPath;

    public SevenZipEngine(string? customSevenZipPath = null)
    {
        // Default to a local binaries folder or system path
        _sevenZipPath = customSevenZipPath ?? Path.Combine(AppContext.BaseDirectory, "binaries", "7z.exe");
    }

    public void Compress(string sourcePath, string outputPath, string? password = null)
    {
        if (!Directory.Exists(sourcePath) && !File.Exists(sourcePath))
            throw new DirectoryNotFoundException($"Source path not found: {sourcePath}");

        // 7-Zip arguments: a (add), -tzip (zip format), -p (password if applied)
        string arguments = $"a \"{outputPath}\" \"{sourcePath}\" -tzip";
        
        if (!string.IsNullOrEmpty(password))
        {
            arguments += $" -p\"{password}\"";
        }

        ExecuteProcess(arguments);
    }

    public void Decompress(string sourcePath, string outputPath, string? password = null)
    {
        if (!File.Exists(sourcePath))
            throw new FileNotFoundException($"Archive target not found: {sourcePath}");

        // 7-Zip arguments: x (extract with full paths), -o (output directory)
        string arguments = $"x \"{sourcePath}\" -o\"{outputPath}\" -y";

        if (!string.IsNullOrEmpty(password))
        {
            arguments += $" -p\"{password}\"";
        }

        ExecuteProcess(arguments);
    }

    private void ExecuteProcess(string arguments)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = _sevenZipPath,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = startInfo };
        
        process.Start();
        
        // Read technical logs in English for standard software telemetry
        string errors = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            throw new Exception($"7-Zip execution failed with exit code {process.ExitCode}. Technical error: {errors}");
        }
    }
}
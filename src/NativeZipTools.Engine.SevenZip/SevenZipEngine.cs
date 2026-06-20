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

    public void Compress(
        IEnumerable<string> sourcePaths,
        string outputPath,
        string? password = null)
    {
        if (sourcePaths is null || !sourcePaths.Any())
            throw new ArgumentException(
                "At least one input path must be specified.");

        foreach (string sourcePath in sourcePaths)
        {
            if (!File.Exists(sourcePath) &&
                !Directory.Exists(sourcePath))
            {
                throw new FileNotFoundException(
                    $"Input path not found: {sourcePath}");
            }
        }

        string inputArguments = string.Join(
            " ",
            sourcePaths.Select(path => $"\"{path}\""));

        string arguments =
            $"a \"{outputPath}\" {inputArguments} -t7z";

        if (!string.IsNullOrWhiteSpace(password))
        {
            arguments += $" -p\"{password}\" -mhe=on";
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

    public bool VerifyIntegrity(
        string archivePath,
        string? password = null)
    {
        string arguments = $"t \"{archivePath}\"";

        if (!string.IsNullOrWhiteSpace(password))
        {
            arguments += $" -p\"{password}\"";
        }

        return ExecuteProcessWithResult(arguments);
    }

    private bool ExecuteProcessWithResult(
        string arguments)
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

        using var process = new Process
        {
            StartInfo = startInfo
        };

        process.Start();

        process.WaitForExit();

        return process.ExitCode == 0;
    }

    public IReadOnlyList<string> ListContents(
        string archivePath,
        string? password = null)
    {
        string arguments = $"l \"{archivePath}\"";

        if (!string.IsNullOrWhiteSpace(password))
        {
            arguments += $" -p\"{password}\"";
        }

        string output = ExecuteProcessAndCaptureOutput(arguments);

        return output
            .Split(Environment.NewLine)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();
    }

    private string ExecuteProcessAndCaptureOutput(
        string arguments)
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

        using var process = new Process
        {
            StartInfo = startInfo
        };

        process.Start();

        string output =
            process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return output;
    }

    public ArchiveMetadata GetMetadata(
        string archivePath,
        string? password = null)
    {
        var fileInfo = new FileInfo(archivePath);

        return new ArchiveMetadata
        {
            Name = fileInfo.Name,
            Format = fileInfo.Extension,
            CompressedSize = fileInfo.Length,
            CreatedAt = fileInfo.CreationTime
        };
    }
}
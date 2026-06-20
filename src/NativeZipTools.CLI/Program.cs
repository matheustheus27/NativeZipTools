using System.Globalization;
using System.Threading;
using NativeZipTools.Core.Interfaces;
using NativeZipTools.Core.Resources;
using NativeZipTools.Engine.SevenZip;

// Automatically detects Operating System language (or respects environment variables)
// If the OS is in Portuguese, it targets pt-BR. Otherwise, it falls back to English (default).
CultureInfo userCulture = CultureInfo.CurrentCulture;
Thread.CurrentThread.CurrentCulture = userCulture;
Thread.CurrentThread.CurrentUICulture = userCulture;

// Core Engine Initialization (V1 using 7-Zip)
ICompressionEngine engine = new SevenZipEngine();

try
{
    // Localization using compiled .resx files
    Console.WriteLine(Messages.ProcessStarted); 
    
    // Example path execution
    engine.Compress("./source-folder", "./output.zip");
    
    Console.WriteLine(Messages.ProcessCompleted);
}
catch (Exception ex)
{
    // Technical log remains strictly in English for professional debugging standards
    Console.Error.WriteLine($"[FATAL ERROR] Engine execution failed: {ex.Message}");
}
using System.Globalization;
using System.Threading;
using NativeZipTools.CLI;
using NativeZipTools.Core.Interfaces;
using NativeZipTools.Engine.SevenZip;

CultureInfo detectedCulture =
    CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "pt"
        ? new CultureInfo("pt-BR")
        : new CultureInfo("en-US");

Thread.CurrentThread.CurrentCulture = detectedCulture;
Thread.CurrentThread.CurrentUICulture = detectedCulture;

IArchiveEngine engine = new SevenZipEngine();

var dispatcher = new CommandDispatcher(engine);

dispatcher.Execute(args);
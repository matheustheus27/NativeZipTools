namespace NativeZipTools.Archive
{
    public class NipHeader
    {
        public string Version { get; set; } = "1.0";

        public string Compression { get; set; } = "Optimal";

        public bool Encrypted { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
namespace InExTrack.Common
{
    public abstract class DataFile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Url { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
    }
}

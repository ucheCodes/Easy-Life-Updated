namespace HKBlog.UI.Data
{
    public class Slides
    {
        public string FilePath { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string Desc { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}

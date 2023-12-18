namespace WordCloudApplication.Data.Entities
{
    public enum Format
    {
        PNG,
        JPEG,
        SVG
    }

    public enum GenerationMethod
    {
        CSV,
        AI,
        TYPED
    }

    public class WordCloud
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public Format Format { get; set; }
        public GenerationMethod GenerationMethod { get; set; }
        public string? Image { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public WordCloud()
        {
        }
    }
}

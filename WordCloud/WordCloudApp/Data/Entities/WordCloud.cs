namespace WordCloudApp.Data.Entities
{
    public class WordCloud
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public virtual User? User { get; set; }

        public WordCloud()
        {
        }
    }
}

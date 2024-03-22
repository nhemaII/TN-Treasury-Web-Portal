namespace TN_Treasury_Web_Portal.Models
{
    public class GuideSection
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int GuideId { get; set; }

        public Guide Guide { get; set; } = null!;

    }
}

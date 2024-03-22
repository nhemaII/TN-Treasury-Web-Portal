namespace TN_Treasury_Web_Portal.Models
{
    public class Guide
    {

        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Guide> Guides { get; set; } = new List<Guide>();
    }
}

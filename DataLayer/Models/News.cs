namespace DataLayer.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public virtual Category Category { get; set; }

        public void Update(News obj)
        {
            Name = obj.Name;
            Description = obj.Description;
            Content = obj.Content;
            Image = obj.Image;
        }
    }
}

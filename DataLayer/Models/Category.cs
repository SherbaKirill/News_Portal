using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string CategoryName { get; set; }
        public List<News> News { get; set; }

        public void Update(Category obj)
        {
            DisplayName = obj.DisplayName;
            CategoryName = obj.CategoryName;
        }
    }
}

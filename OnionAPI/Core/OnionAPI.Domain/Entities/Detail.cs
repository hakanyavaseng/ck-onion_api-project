using OnionAPI.Domain.Entities.Common;

namespace OnionAPI.Domain.Entities
{
    public class Detail : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Detail()
        {

        }
        public Detail(string title, string description, int categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }
    }
}

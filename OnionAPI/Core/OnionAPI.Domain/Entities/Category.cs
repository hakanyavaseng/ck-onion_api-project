using OnionAPI.Domain.Entities.Common;

namespace OnionAPI.Domain.Entities
{
    public class Category : EntityBase
    {
        public int ParentId { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {

        }
        public Category(int parentId, int priority, string name)
        {
            ParentId = parentId;
            Priority = priority;
            Name = name;
        }
    }
}

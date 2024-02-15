using OnionAPI.Domain.Entities.Common;

namespace OnionAPI.Domain.Entities
{
    public class Brand : EntityBase
    {
        public required string Name { get; set; }

        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }
    }
}

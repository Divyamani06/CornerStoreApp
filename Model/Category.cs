using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}

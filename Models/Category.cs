using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}

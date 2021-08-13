using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchandising.Management.Data.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }
        public bool IsAlive { get; set; }
        [InverseProperty("Category")]
        public ICollection<Product> Products { get; set; }
    }
}

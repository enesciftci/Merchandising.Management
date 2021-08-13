using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchandising.Management.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAlive { get; set; }
        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public Category Category { get; set; }
    }
}

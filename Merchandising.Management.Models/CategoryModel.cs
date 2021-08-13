using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchandising.Management.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }
        [NotMapped]
        public List<ProductModel> Products { get; set; }
    }
}

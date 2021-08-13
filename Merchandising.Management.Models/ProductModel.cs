namespace Merchandising.Management.Models
{
    public class ProductModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAlive { get; set; }
        public CategoryModel Category { get; set; }
    }
}

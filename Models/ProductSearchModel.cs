using _2Good2EatBackendStore.Enums;

namespace _2Good2EatBackendStore.Models
{
    public class ProductSearchModel
    {
        public ProductSearchModel()
        {
            ShowOutOfStock = false;
            ShowDeleted = false;
            ShowInvisible = false;
            ProductTypes = [ProductTypeEnum.CrochetItem, ProductTypeEnum.WaxMelt, ProductTypeEnum.Candle];
        }
        public bool ShowOutOfStock { get; set; }
        public bool ShowDeleted { get; set; }
        public bool ShowInvisible { get; set; }
        public List<ProductTypeEnum> ProductTypes { get; set; }

    }
}

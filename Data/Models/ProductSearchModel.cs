using _2Good2EatStore.Data.Enums;

namespace _2Good2EatBackendStore.Data.Models
{
    public class ProductSearchModel
    {
        public ProductSearchModel()
        {
            ShowDeleted = false;
            ShowInvisible = false;
            ProductTypes = [ProductTypeEnum.CrochetItem, ProductTypeEnum.WaxMelt, ProductTypeEnum.Candle];
        }
        public bool ShowDeleted { get; set; }
        public bool ShowInvisible { get; set; }
        public List<ProductTypeEnum> ProductTypes { get; set; }

    }
}

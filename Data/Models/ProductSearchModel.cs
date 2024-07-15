using _2Good2EatStore.Data.Enums;

namespace _2Good2EatBackendStore.Data.Models
{
    public class ProductSearchModel
    {
        public bool showDeleted { get; set; }
        public bool showInvisible { get; set; }
        public List<ProductTypeEnum> ProductTypes { get; set; }

    }
}

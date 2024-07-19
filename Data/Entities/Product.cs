using _2Good2EatBackendStore.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Good2EatBackendStore.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ProductTypeEnum ProductType { get; set; }

        public required string ProductImageURL { get; set; }

        [DataType(DataType.Currency)]
        [Precision(19, 4)]
        public required decimal WholesalePrice { get; set; }

        [DataType(DataType.Currency)]
        [Precision(19, 4)]
        public required decimal RetailPrice { get; set; }

        public required int Inventory { get; set; }

        public required bool IsVisible { get; set; }

        public required bool IsDeleted { get; set; }
    }
}

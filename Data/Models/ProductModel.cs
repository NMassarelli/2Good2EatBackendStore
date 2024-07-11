using _2Good2EatStore.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using _2Good2EatBackendStore.Data.Entities;

namespace _2Good2EatBackendStore.Data.Models
{
    public class ProductModel
    {

        public string? Id { get; internal set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public string ProductImageURL { get; set; }
        public string WholesalePrice { get; set; }
        public string RetailPrice { get; set; }
        public int Inventory { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }

    }

    public static class ProductExtensionMethods
    {

        public static List<Product> MapToEntityList(this List<ProductModel> modelist)
        {
            return modelist.Select(x => x.MapToEntity()).ToList();
        }

        public static List<ProductModel> MapToModelList(this List<Product> entityList)
        {
            return entityList.Select(x => x.MapToModel()).ToList();
        }
        public static Product MapToEntity(this ProductModel model)
        {
            return new Product
            {
                Id = model.Id == null ? null : int.Parse(model.Id),
                Name = model.Name,
                Description = model.Description,
                ProductType = model.ProductType,
                ProductImageURL = model.ProductImageURL,
                Inventory = model.Inventory,
                RetailPrice = decimal.Parse(model.RetailPrice),
                WholesalePrice = decimal.Parse(model.WholesalePrice),
                IsDeleted = model.IsDeleted,
                IsVisible = model.IsVisible,

            };
        }

        public static ProductModel MapToModel(this Product entity)
        {
            return new ProductModel
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Description = entity.Description,
                ProductType = entity.ProductType,
                ProductImageURL = entity.ProductImageURL,
                Inventory = entity.Inventory,
                RetailPrice = entity.RetailPrice.ToString(),
                WholesalePrice = entity.WholesalePrice.ToString(),
                IsDeleted = entity.IsDeleted,
                IsVisible = entity.IsVisible,

            };
        }
    }

    public class ProductModelFluentValidator : AbstractValidator<ProductModel>
    {
        public ProductModelFluentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.ProductType)
                .NotEmpty();

            RuleFor(x => x.WholesalePrice).NotEmpty();

            RuleFor(x => x.RetailPrice).NotEmpty();

            RuleFor(x => x.WholesalePrice)
                .LessThan(x => x.RetailPrice).WithMessage("Wholesale price should be lower than retail price wtf?");



        }

    }



}

using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductCreators
{
    public class DbProductCreator : IProductCreator
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbProductCreator(MVVMShopContextFactory dbContextFactory) => _dbContextFactory = dbContextFactory;

        public void CreateProduct(Product product)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var productDto = ToProductDto(product);

            context.Products.Add(productDto);
            context.SaveChanges();
            product.Id = productDto.Id;
        }

        public static ProductDTO ToProductDto(Product product) => new()
        {
            Availability = product.Availability,
            Points = product.Points,
            Image = "",
            Price = product.Price,
            ProductName = product.ProductName
        };
    }
}
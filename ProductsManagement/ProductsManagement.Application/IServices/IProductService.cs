using ProductsManagement.Application.Base;
using ProductsManagement.Domain.DTOs;
using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Application.IServices
{
    public interface IProductService: IEntityService<Product>
    {
        IEnumerable<ProductDto> GetProducts();
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task CreateProduct(ProductDto productDto);
        Task UpdateProduct(ProductDto productDto, Product product);
        Task DeleteProduct(Product product);
    }
}

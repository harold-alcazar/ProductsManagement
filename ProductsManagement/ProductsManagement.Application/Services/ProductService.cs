using AutoMapper;
using ProductsManagement.Application.Base;
using ProductsManagement.Application.IRepositories;
using ProductsManagement.Application.IServices;
using ProductsManagement.Domain.DTOs;
using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Application.Services
{
    public class ProductService : EntityService<Product>, IProductService
    {
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var products = _mapper.Map<IEnumerable<ProductDto>>(GetAll());
            return products;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = await GetById(productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await Add(product);
            await SaveChanges();
        }

        public async Task UpdateProduct(ProductDto productDto, Product product)
        {
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Category = productDto.Category;
            product.InitialQuantity = productDto.InitialQuantity;
            Update(product);
            await SaveChanges();
        }

        public async Task DeleteProduct(Product product)
        {
            Delete(product);
            await SaveChanges();
        }
    }
}

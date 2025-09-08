using CRUD.BL.Repositories;
using CRUD.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BL.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> CreateProduct(ProductModel productModel);
        Task<ProductModel> GetProduct(int id);
        Task<bool> ProductModelExists(int id);
        Task UpdateProduct(ProductModel productModel);
        Task DeleteProduct(int id);
    }
    public class ProductServices(IProductRepository productRepository) : IProductService
    {
        public Task<ProductModel> CreateProduct(ProductModel productModel)
        {
            return productRepository.CreateProduct(productModel);
        }

        public Task<ProductModel> GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }

        public Task<List<ProductModel>> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public Task<bool> ProductModelExists(int id)
        {
            return productRepository.ProductModelExists(id);
        }


        public Task UpdateProduct(ProductModel productModel)
        {
            return productRepository.UpdateProduct(productModel);
        }
        public Task DeleteProduct(int id)
        {
            return productRepository.DeleteProduct(id);
        }   
    }
}

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
    } 
    public class ProductServices(IProductRepository productRepository) : IProductService
    {
        public Task<List<ProductModel>> GetProducts()
        {
            return productRepository.GetProducts();
        }
    }
}

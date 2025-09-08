using CRUD.Database.Data;
using CRUD.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BL.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> CreateProduct(ProductModel productModel);
        Task<ProductModel> GetProduct(int id);
        Task<bool> ProductModelExists(int id);
        Task UpdateProduct(ProductModel productModel);
        Task DeleteProduct(int id);
    }
    public class ProductRepository(CRUDDbContext dbContext) : IProductRepository
    {
        public async Task<ProductModel> CreateProduct(ProductModel productModel)
        {
            dbContext.Products.Add(productModel);
            await dbContext.SaveChangesAsync();
            return productModel;
        }

        public Task<ProductModel> GetProduct(int id)
        {
            return dbContext.Products.FirstOrDefaultAsync(n => n.ID == id);
        }

        public Task<List<ProductModel>> GetProducts()
        {
            return dbContext.Products.ToListAsync();
        }

        public Task<bool> ProductModelExists(int id)
        {
            return dbContext.Products.AnyAsync(e => e.ID == id);
        }

        public async Task UpdateProduct(ProductModel productModel)
        {
            dbContext.Entry(productModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var product = dbContext.Products.FirstOrDefault(n=>n.ID==id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();  
        }
    }
}

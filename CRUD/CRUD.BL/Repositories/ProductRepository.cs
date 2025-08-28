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
    }
    public class ProductRepository(CRUDDbContext dbContext) : IProductRepository
    {
        public Task<List<ProductModel>> GetProducts()
        {
            return dbContext.Products.ToListAsync();
        }
    }
}

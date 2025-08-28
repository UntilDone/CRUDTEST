using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD.Model.Entities;

namespace CRUD.Database.Data
{
    public class CRUDDbContext : DbContext
    {
        public CRUDDbContext(DbContextOptions<CRUDDbContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<ProductModel> Products { get; set; }
    }   
}

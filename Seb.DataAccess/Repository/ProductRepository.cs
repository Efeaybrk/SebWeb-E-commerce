using Seb.DataAccess.Data;
using Seb.DataAccess.Repository.IRepository;
using Seb.Models;
using Seb.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Seb.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u=>u.ProductID == obj.ProductID);
            if (obj != null)
            {
                objFromDb.ProductName = obj.ProductName;
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.CategoryID = obj.CategoryID;
                objFromDb.Description = obj.Description;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}

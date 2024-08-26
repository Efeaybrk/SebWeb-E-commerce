using Seb.DataAccess.Data;
using Seb.DataAccess.Repository.IRepository;
using Seb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Seb.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}

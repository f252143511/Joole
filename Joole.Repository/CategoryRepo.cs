using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Dal;

namespace Joole.Repository
{

    public interface ICategoryRepo : IRepository<Category>
    {

    }
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        public CategoryRepo(DbContext context) : base(context)
        {

        }
    }
}

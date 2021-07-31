using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Dal;

namespace Joole.Repository
{

    public interface ISubCategoryRepo : IRepository<SubCategory>
    {

    }
    public class SubCategoryRepo : Repository<SubCategory>, ISubCategoryRepo
    {
        public SubCategoryRepo(DbContext context) : base(context)
        {

        }
    }
}

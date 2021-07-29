using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.Dal;

namespace Joole.Repository
{

    public interface IProductRepo : IRepository<Product>
    {

    }
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(DbContext context) : base(context)
        {

        }
    }
}

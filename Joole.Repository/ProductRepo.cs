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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Dal;

namespace Joole.Repository
{

    public interface IPropertyRepo : IRepository<Property>
    {

    }
    public class PropertyRepo : Repository<Property>, IPropertyRepo
    {
        public PropertyRepo(DbContext context) : base(context)
        {

        }
    }
}

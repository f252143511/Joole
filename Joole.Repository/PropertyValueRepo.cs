using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Dal;

namespace Joole.Repository
{

    public interface IPropertyValueRepo : IRepository<PropertyValue>
    {

    }
    public class PropertyValueRepo : Repository<PropertyValue>, IPropertyValueRepo
    {
        public PropertyValueRepo(DbContext context) : base(context)
        {

        }
    }
}

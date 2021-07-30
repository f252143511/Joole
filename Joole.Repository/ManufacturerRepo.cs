using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.Dal;

namespace Joole.Repository
{


    public interface IManufacturerRepo : IRepository<Manufacturer>
    {

    }
    public class ManufacturerRepo : Repository<Manufacturer>, IManufacturerRepo
    {
        public ManufacturerRepo(DbContext context): base(context)
        {

        }
    }
}

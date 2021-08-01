using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Joole.Service
{
    public class SearchModel
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int SubCategory_ID { get; set; }
        public string SubCategoryName { get; set; }
    }
}

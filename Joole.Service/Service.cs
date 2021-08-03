using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.Dal;
using Joole.Repository;

namespace Joole.Service
{
    public class Service
    {
        public static readonly JooleDbEntities context = new JooleDbEntities();
        UnitOfWork UOW = new UnitOfWork(context);
        private Repository<User> userRepository;
        public Service()
        {
            userRepository = new Repository<User>(context);
        }
        public ProductDetailsModel GetProductDetails(int ID)
        {
            var products = UOW.product.GetAll();
            var properties = UOW.property.GetAll();
            var propertyValues = UOW.propertyvalue.GetAll();
            var manufacturers = UOW.manufacturer.GetAll();

            var query = from propertyvalue in propertyValues
                        join property in properties on propertyvalue.Property_ID equals property.Property_ID
                        join product in products on propertyvalue.Product_ID equals product.Product_ID
                        join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
                        where product.Product_ID == ID
                        select new { product.Product_ID, product.Model, product.Series, propertyvalue.Value, manufacturer.Name, property.Property_Name };


            var result = new ProductDetailsModel();

            result.Product_ID = query.First().Product_ID;
            result.Series = query.First().Series;
            result.Manufacture = query.First().Name;
            result.Model = query.First().Model;
            foreach (var property in query)
            {
                switch (property.Property_Name)
                {
                    case "Use Type":
                        result.UseType = property.Value;
                        break;
                    case "Application":
                        result.Application = property.Value;
                        break;
                    case "Mounting Location":
                        result.MountingLocation = property.Value;
                        break;
                    case "Accessories":
                        result.Accessories = property.Value;
                        break;
                    case "Air Flow":
                        result.AirFlow = property.Value;
                        break;
                    case "Model Year":
                        result.ModelYear = property.Value;
                        break;
                    case "Power_Min":
                        result.PowerMin = property.Value;
                        break;
                    case "Power_Max":
                        result.PowerMax = property.Value;
                        break;
                    case "Operating Voltage_Min":
                        result.OperatingVoltageMin = property.Value;
                        break;
                    case "Operating Voltage_Max":
                        result.OperatingVoltageMax = property.Value;
                        break;
                    case "Fan speed_Min":
                        result.FanSpeedMin = property.Value;
                        break;
                    case "Fan speed_Max":
                        result.FanSpeedMax = property.Value;
                        break;
                    case "Number of fan speeds":
                        result.NumberOfFanSpeed = property.Value;
                        break;
                    case "Sound at max speed":
                        result.SoundAtMaxSpeed = property.Value;
                        break;
                    case "Fan sweep diameter":
                        result.FanSweepDiameter = property.Value;
                        break;
                    case "Height_Min":
                        result.HeightMin = property.Value;
                        break;
                    case "Height_Max":
                        result.HeightMax = property.Value;
                        break;
                    case "Weight":
                        result.Weight = property.Value;
                        break;


                }
            }
            return result;
        }
        public List<UserModel> GetUsers()
        {
            List<UserModel> NewUsers = new List<UserModel>();
            var result = UOW.user.GetAll();
            foreach (var item in result)
            {
                UserModel us = new UserModel();
                us.User_ID = item.User_ID;
                us.Password = item.Password;
                us.Username = item.Username;
                us.Email = item.Email;
                us.Image = item.Image;
                NewUsers.Add(us);
            }
            return NewUsers;
        }

        public Boolean ValidateUser(String useremail, String password)
        {
            var result = UOW.user.GetAll();
            var query = from u in result where u.Email == useremail && u.Password == password select u;
            if(query.Count() != 0)
            {
                return true;
            }
            var query2 = from u in result where u.Username == useremail && u.Password == password select u;
            if(query2.Count() != 0)
            {
                return true;
            }
            return false;
        }
        public void CreateUser(User u)
        {
            var users = UOW.user.GetAll();
            var query = users.OrderBy(user => user.User_ID);
            var result = query.Last().User_ID;
            var UserId = result+1;
            u.User_ID = UserId;
            userRepository.Insert(u);
        }

        public ProductModel GetProductByID(int ID)
        {
            var products = UOW.product.GetAll();
            var properties = UOW.property.GetAll();
            var propertyValues = UOW.propertyvalue.GetAll();
            var manufacturers = UOW.manufacturer.GetAll();

            var query = from propertyvalue in propertyValues
                        join property in properties on propertyvalue.Property_ID equals property.Property_ID
                        join product in products on propertyvalue.Product_ID equals product.Product_ID
                        join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
                        where product.Product_ID == ID
                        select new { product.Product_ID,product.Product_Image, product.Model, product.Series, propertyvalue.Value, manufacturer.Name, property.Property_Name };


            var result = new ProductModel();
            if (query.Count() == 0) {
                return null;
            }
            result.Product_ID = query.First().Product_ID;
            result.Series = query.First().Series;
            result.Manufacturer = query.First().Name;
            result.Model = query.First().Model;
            result.Image = query.First().Product_Image;
            foreach (var property in query)
            {
                switch (property.Property_Name)
                {
                    case "Use Type":
                        result.UseType = property.Value;
                        break;
                    case "Application":
                        result.Application = property.Value;
                        break;
                    case "Mounting Location":
                        result.MountingLocation = property.Value;
                        break;
                    case "Accessories":
                        result.Accessories = property.Value;
                        break;
                    case "Air Flow":
                        result.AirFlow = property.Value;
                        break;
                    case "Model Year":
                        result.ModelYear = property.Value;
                        break;
                    case "Power_Min":
                        result.PowerMin = property.Value;
                        break;
                    case "Power_Max":
                        result.PowerMax = property.Value;
                        break;
                    case "Operating Voltage_Min":
                        result.OperatingVoltageMin = property.Value;
                        break;
                    case "Operating Voltage_Max":
                        result.OperatingVoltageMax = property.Value;
                        break;
                    case "Fan speed_Min":
                        result.FanSpeedMin = property.Value;
                        break;
                    case "Fan speed_Max":
                        result.FanSpeedMax = property.Value;
                        break;
                    case "Number of fan speeds":
                        result.NumberOfFanSpeed = property.Value;
                        break;
                    case "Sound at max speed":
                        result.SoundAtMaxSpeed = property.Value;
                        break;
                    case "Fan sweep diameter":
                        result.FanSweepDiameter = property.Value;
                        break;
                    case "Height_Min":
                        result.HeightMin = property.Value;
                        break;
                    case "Height_Max":
                        result.HeightMax = property.Value;
                        break;
                    case "Weight":
                        result.Weight = property.Value;
                        break;


                }
            }
            return result;
        }
        public List<ProductModel> GetProducts(string Subcategory, int beginningYear, int endingYear,
            int airflowMinAmount, int airflowMaxAmount)
        {
            var products = UOW.product.GetAll();
            var properties = UOW.property.GetAll();
            var propertyValues = UOW.propertyvalue.GetAll();
            var manufacturers = UOW.manufacturer.GetAll();
            var subcategories = UOW.subcategory.GetAll();

            var query = from product in products
                        //join subcategory in subcategories on product.Subcategory_ID equals subcategory.SubCategory_ID
                        //where subcategory.SubCategoryName == Subcategory
                        select new {product.Product_ID};
            List<ProductModel> result = new List<ProductModel>();
            

            foreach (var product in query)
            {
                var test = product.Product_ID;
                ProductModel m = GetProductByID(product.Product_ID);
                if (m is null)
                {
                    continue;
                }
                result.Add(m);
            }

            var filter = from product in result
                              where int.Parse(product.ModelYear) >= beginningYear && int.Parse(product.ModelYear) <= endingYear
                              && int.Parse(product.AirFlow) >= airflowMinAmount && int.Parse(product.AirFlow) <= airflowMaxAmount
                         select product;

            
            return filter.ToList();
        }

        //public List<ProductModel> GetProducts(string Subcategory, int beginningYear, int endingYear, 
        //    int airflowMinAmount, int airflowMaxAmount)
        //{
        //    var products = UOW.product.GetAll();
        //    var properties = UOW.property.GetAll();
        //    var propertyValues = UOW.propertyvalue.GetAll();
        //    var manufacturers = UOW.manufacturer.GetAll();
        //    var categories = UOW.category.GetAll();
        //    var subcategories = UOW.subcategory.GetAll();

        //    var query =  from product in products
        //                 join subcategory in subcategories on product.Subcategory_ID equals subcategory.SubCategory_ID
        //                 join category in categories on subcategory.Category_ID equals category.Category_ID
        //                 join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
        //                 join propertyvalue in propertyValues on product.Product_ID equals propertyvalue.Product_ID
        //                 join property in properties on propertyvalue.Property_ID equals property.Property_ID
        //                 where subcategory.SubCategoryName == Subcategory 
        //                 select new { product.Product_ID, product.Product_Image, subcategory.SubCategoryName, category.Category_Name, product.Model, product.Series, propertyvalue.Value, manufacturer.Name, property.Property_Name };


        //    var filterQuery = query.Where(product => product.Property_Name == "Model Year"
        //                        && int.Parse(product.Value) >= beginningYear
        //                        && int.Parse(product.Value) <= endingYear);
        //    /*filterQuery.Concat(query.Where(product => product.Property_Name == "Air Flow"
        //                        && int.Parse(product.Value) <= airflowMinAmount
        //                        && int.Parse(product.Value) >= airflowMaxAmount));*/

        //    var uniqueQuery = from p in filterQuery
        //                      group p by new { p.Product_ID }
        //                       into mygroup
        //                       select mygroup.FirstOrDefault();

        //    List < ProductModel > result = new List<ProductModel>();
        //    if (uniqueQuery.Count() == 0)
        //    {
        //        ProductModel pr = new ProductModel();

        //        pr.Category = "Mechanical";
        //        pr.SubCategory = Subcategory;
        //        result.Add(pr);
        //    }
        //    else
        //    {
        //        foreach (var property in uniqueQuery)
        //        {
        //            ProductModel pr = new ProductModel();
        //            pr.Image = property.Product_Image;
        //            pr.Category = uniqueQuery.First().Category_Name;
        //            pr.SubCategory = uniqueQuery.First().SubCategoryName;
        //            pr.Product_ID = property.Product_ID;
        //            pr.Series = property.Series;
        //            pr.Manufacturer = property.Name;
        //            pr.Model = property.Model;
        //            foreach (var prop in query)
        //            {
        //                if (prop.Product_ID == property.Product_ID)
        //                {
        //                    switch (prop.Property_Name)
        //                    {
        //                        case "Model Year":
        //                                pr.ModelYear = prop.Value;
        //                            break;
        //                        case "Air Flow":
        //                            pr.AirFlow = prop.Value;
        //                            break;
        //                        case "Power_Max":
        //                            pr.PowerMax = prop.Value;
        //                            break;
        //                        case "Sound at max speed":
        //                            pr.SoundAtMaxSpeed = prop.Value;
        //                            break;
        //                        case "Fan sweep diameter":
        //                            pr.FanSweepDiameter = prop.Value;
        //                            break;
        //                    }
        //                }

        //            }
        //            result.Add(pr);
        //        }       
        //    }
        //    return result;
        //}
        public List<ProductModel> GetComparison(int id1, int id2, int id3)
        {
            List<ProductModel> Products = new List<ProductModel>();
            var result = UOW.product.GetAll();

            foreach (var item in result)
            {
                ProductModel pr = new ProductModel();
                pr.Model = item.Model;
                pr.Series = item.Series;
                Products.Add(pr);
            }
            return Products;
        }

        public List<SearchModel> GetCategoryListAll()
        {
            List<SearchModel> categories = new List<SearchModel>();
            var result = UOW.category.GetAll();
            foreach (var item in result)
            {
                SearchModel sm = new SearchModel();
                sm.Category_ID = item.Category_ID;
                sm.Category_Name = item.Category_Name;
                categories.Add(sm);
            }
            return categories;
        }

        public List<SearchModel> GetSubCategoryListAll()
        {
            List<SearchModel> subcategories = new List<SearchModel>();
            var result = UOW.subcategory.GetAll();
            foreach (var item in result)
            {
                SearchModel sm = new SearchModel();
                sm.Category_ID = (int)item.Category_ID;
                sm.SubCategory_ID = item.SubCategory_ID;
                sm.SubCategoryName = item.SubCategoryName;
                subcategories.Add(sm);
            }
            return subcategories;
        }

        public List<SearchModel> GetSubCategoryList(int Category_ID)
        {
            List<SearchModel> subcategories = new List<SearchModel>();
            var result = UOW.subcategory.GetAll();
            if (Category_ID != -1)
            {
                foreach (var item in result)
                {
                    if (item.Category_ID == Category_ID)
                    {
                        SearchModel sm = new SearchModel();
                        sm.SubCategory_ID = item.SubCategory_ID;
                        sm.SubCategoryName = item.SubCategoryName;
                        subcategories.Add(sm);
                    }
                }
            }
            else
            {
                return GetSubCategoryListAll();
            }
            return subcategories;
        }

        public int GetSubcategoryId(String SubCategoryName)
        {
            var result = UOW.subcategory.GetAll();
            String name = "";
            if (SubCategoryName != null)
            {
                name = SubCategoryName.ToLower();
            }
            foreach (var item in result)
            {
                Boolean match = true;
                int strLen = item.SubCategoryName.Length;
                for (int i = 0; i < strLen - 1; i++)
                {
                    if (name[i] != item.SubCategoryName.ToLower()[i])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return item.SubCategory_ID;
                }
            }
            return -1;
        }
    }
}

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
        public Service()
        {

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

        public List<ProductModel> GetProducts(string Subcategory)
        {
            var products = UOW.product.GetAll();
            var properties = UOW.property.GetAll();
            var propertyValues = UOW.propertyvalue.GetAll();
            var manufacturers = UOW.manufacturer.GetAll();
            var categories = UOW.category.GetAll();
            var subcategories = UOW.subcategory.GetAll();

            var query = (from product in products
                         join subcategory in subcategories on product.Subcategory_ID equals subcategory.SubCategory_ID
                         join category in categories on subcategory.Category_ID equals category.Category_ID
                         join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
                         join propertyvalue in propertyValues on product.Product_ID equals propertyvalue.Product_ID
                         join property in properties on propertyvalue.Property_ID equals property.Property_ID
                         where subcategory.SubCategoryName == Subcategory
                         select new { product.Product_ID, product.Product_Image, subcategory.SubCategoryName, category.Category_Name, product.Model, product.Series, propertyvalue.Value, manufacturer.Name, property.Property_Name });
            
            var uniqueQuery = from p in query
                               group p by new { p.Product_ID }
                               into mygroup
                               select mygroup.FirstOrDefault();

            List<ProductModel> result = new List<ProductModel>();

            foreach (var property in uniqueQuery)
            {
                ProductModel pr = new ProductModel();
                pr.Image = property.Product_Image;
                pr.Category = uniqueQuery.First().Category_Name;
                pr.SubCategory = uniqueQuery.First().SubCategoryName;
                pr.Product_ID = property.Product_ID;
                pr.Series = property.Series;
                pr.Manufacturer = property.Name;
                pr.Model = property.Model;
               /* foreach (var prop in propertyValues)
                {
                    if (prop.Property_ID == 6)
                    {
                        pr.AirFlow = prop.Value;
                    }
                    if (prop.Property_ID == 8)
                    {
                        pr.PowerMax = prop.Value; //8
                    }
                    if (prop.Property_ID == 14)
                    {
                        pr.SoundAtMaxSpeed = prop.Value; //14
                    }
                    if (prop.Property_ID == 15)
                    {
                        pr.FanSweepDiameter = prop.Value; //15
                    }
                }*/
                /*switch (property.Property_Name)
                {
                    case "Use Type":
                        pr.UseType = property.Value;
                        break;
                    case "Application":
                        pr.Application = property.Value;
                        break;
                    case "Mounting Location":
                        pr.MountingLocation = property.Value;
                        break;
                    case "Accessories":
                        pr.Accessories = property.Value;
                        break;
                    case "Air Flow":
                        pr.AirFlow = property.Value;
                        break;
                    case "Model Year":
                        pr.ModelYear = property.Value;
                        break;
                    case "Power_Min":
                        pr.PowerMin = property.Value;
                        break;
                    case "Power_Max":
                        pr.PowerMax = property.Value;
                        break;
                    case "Operating Voltage_Min":
                        pr.OperatingVoltageMin = property.Value;
                        break;
                    case "Operating Voltage_Max":
                        pr.OperatingVoltageMax = property.Value;
                        break;
                    case "Fan speed_Min":
                        pr.FanSpeedMin = property.Value;
                        break;
                    case "Fan speed_Max":
                        pr.FanSpeedMax = property.Value;
                        break;
                    case "Number of fan speeds":
                        pr.NumberOfFanSpeed = property.Value;
                        break;
                    case "Sound at max speed":
                        pr.SoundAtMaxSpeed = property.Value;
                        break;
                    case "Fan sweep diameter":
                        pr.FanSweepDiameter = property.Value;
                        break;
                    case "Height_Min":
                        pr.HeightMin = property.Value;
                        break;
                    case "Height_Max":
                        pr.HeightMax = property.Value;
                        break;
                    case "Weight":
                        pr.Weight = property.Value;
                        break;
                }*/
                result.Add(pr);
            }
            return result;
        }
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
    }
}
        /*List<ProductModel> NewProducts = new List<ProductModel>();
            var result = UOW.product.GetAll();

            foreach (var item in result)
            {
                ProductModel pr = new ProductModel();
                pr.Product_ID = item.Product_ID;
                var propertyValue = UOW.propertyvalue.GetAll();
                pr.Manufacturer = item.Product_ID.ToString(); //get manufacturer from table
                foreach (var prop in propertyValue)
                {
                    if (prop.Property_ID == 6)
                    {
                        pr.AirFlow = prop.Value;
                    }
                    if (prop.Property_ID == 8)
                    {
                        pr.PowerMax = prop.Value; //8
                    }
                    if (prop.Property_ID == 14)
                    {
                        pr.SoundAtMaxSpeed = prop.Value; //14
                    }
                    if (prop.Property_ID == 15)
                    {
                        pr.FanSweepDiameter = prop.Value; //15
                    }
                }
                pr.Series = item.Series;
                pr.Model = item.Model;
                //pr.UseType = item.UseType;
                NewProducts.Add(pr);
            }
            return NewProducts;
        }

    }*/

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
                int strLen = item.SubCategoryName.Length;
                String strName = item.SubCategoryName.ToLower().Substring(0, strLen - 1);
                if (name.Equals(strName))
                {
                    return item.SubCategory_ID;
                }
            }
            return -1;
        }

    }
}

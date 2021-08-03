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
            List<ProductModel> ProductModel = new List<ProductModel>();
            var products = UOW.product.GetAll();
            var properties = UOW.property.GetAll();
            var propertyValues = UOW.propertyvalue.GetAll();
            var manufacturers = UOW.manufacturer.GetAll();

            var query1 = from propertyvalue in propertyValues
                         join property in properties on propertyvalue.Property_ID equals property.Property_ID
                         join product in products on propertyvalue.Product_ID equals product.Product_ID
                         join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
                         where product.Product_ID == id1
                         select new { product.Product_Image, product.Product_ID, product.Model, product.Series, propertyvalue.Value, manufacturer.Name, property.Property_Name };

            var query2 = from propertyvalue in propertyValues
                         join property in properties on propertyvalue.Property_ID equals property.Property_ID
                         join product in products on propertyvalue.Product_ID equals product.Product_ID
                         join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
                         where product.Product_ID == id2
                         select new { product.Product_Image, product.Product_ID, product.Model, product.Series, propertyvalue.Value, manufacturer.Name, property.Property_Name };

            var query3 = from propertyvalue in propertyValues
                         join property in properties on propertyvalue.Property_ID equals property.Property_ID
                         join product in products on propertyvalue.Product_ID equals product.Product_ID
                         join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
                         where product.Product_ID == id3
                         select new { product.Product_Image, product.Product_ID, product.Model, product.Series, propertyvalue.Value, manufacturer.Name, property.Property_Name };



            foreach (var item in products)
            {
                ProductModel pv1 = new ProductModel();
                if (pv1.Product_ID == item.Product_ID)
                {
                    pv1.Image = item.Product_Image;
                    pv1.Series = item.Series;
                    pv1.Manufacturer = item.Manufacturer.ToString();
                    pv1.Model = item.Model;
                }

                ProductModel pv2 = new ProductModel();
                if (pv2.Product_ID == item.Product_ID)
                {
                    pv2.Image = item.Product_Image;
                    pv2.Series = item.Series;
                    pv2.Manufacturer = item.Manufacturer.ToString();
                    pv2.Model = item.Model;
                }

                ProductModel pv3 = new ProductModel();
                if (pv3.Product_ID == item.Product_ID)
                {
                    pv3.Image = item.Product_Image;
                    pv3.Series = item.Series;
                    pv3.Manufacturer = item.Manufacturer.ToString();
                    pv3.Model = item.Model;
                }


                pv1.Image = query1.First().Product_Image;
                pv1.Product_ID = query1.First().Product_ID;
                pv1.Series = query1.First().Series;
                pv1.Manufacturer = query1.First().Name;
                pv1.Model = query1.First().Model;
                pv2.Image = query2.First().Product_Image;
                pv2.Product_ID = query2.First().Product_ID;
                pv2.Series = query2.First().Series;
                pv2.Manufacturer = query2.First().Name;
                pv2.Model = query2.First().Model;
                pv3.Image = query3.First().Product_Image;
                pv3.Product_ID = query3.First().Product_ID;
                pv3.Series = query3.First().Series;
                pv3.Manufacturer = query3.First().Name;
                pv3.Model = query3.First().Model;
                foreach (var property in query1)
                {
                    if (property.Product_ID == item.Product_ID)
                    {
                        switch (property.Property_Name)
                        {
                            case "Use Type":
                                pv1.UseType = property.Value;
                                break;
                            case "Application":
                                pv1.Application = property.Value;
                                break;
                            case "Mounting Location":
                                pv1.MountingLocation = property.Value;
                                break;
                            case "Accessories":
                                pv1.Accessories = property.Value;
                                break;
                            case "Air Flow":
                                pv1.AirFlow = property.Value;
                                break;
                            case "Model Year":
                                pv1.ModelYear = property.Value;
                                break;
                            case "Power_Min":
                                pv1.PowerMin = property.Value;
                                break;
                            case "Power_Max":
                                pv1.PowerMax = property.Value;
                                break;
                            case "Operating Voltage_Min":
                                pv1.OperatingVoltageMin = property.Value;
                                break;
                            case "Operating Voltage_Max":
                                pv1.OperatingVoltageMax = property.Value;
                                break;
                            case "Fan speed_Min":
                                pv1.FanSpeedMin = property.Value;
                                break;
                            case "Fan speed_Max":
                                pv1.FanSpeedMax = property.Value;
                                break;
                            case "Number of fan speeds":
                                pv1.NumberOfFanSpeed = property.Value;
                                break;
                            case "Sound at max speed":
                                pv1.SoundAtMaxSpeed = property.Value;
                                break;
                            case "Fan sweep diameter":
                                pv1.FanSweepDiameter = property.Value;
                                break;
                            case "Height_Min":
                                pv1.HeightMin = property.Value;
                                break;
                            case "Height_Max":
                                pv1.HeightMax = property.Value;
                                break;
                            case "Weight":
                                pv1.Weight = property.Value;
                                break;
                        }
                    }
                }
                foreach (var property in query2)
                {
                    if (property.Product_ID == item.Product_ID)
                    {
                        switch (property.Property_Name)
                        {
                            case "Use Type":
                                pv2.UseType = property.Value;
                                break;
                            case "Application":
                                pv2.Application = property.Value;
                                break;
                            case "Mounting Location":
                                pv2.MountingLocation = property.Value;
                                break;
                            case "Accessories":
                                pv2.Accessories = property.Value;
                                break;
                            case "Air Flow":
                                pv2.AirFlow = property.Value;
                                break;
                            case "Model Year":
                                pv2.ModelYear = property.Value;
                                break;
                            case "Power_Min":
                                pv2.PowerMin = property.Value;
                                break;
                            case "Power_Max":
                                pv2.PowerMax = property.Value;
                                break;
                            case "Operating Voltage_Min":
                                pv2.OperatingVoltageMin = property.Value;
                                break;
                            case "Operating Voltage_Max":
                                pv2.OperatingVoltageMax = property.Value;
                                break;
                            case "Fan speed_Min":
                                pv2.FanSpeedMin = property.Value;
                                break;
                            case "Fan speed_Max":
                                pv2.FanSpeedMax = property.Value;
                                break;
                            case "Number of fan speeds":
                                pv2.NumberOfFanSpeed = property.Value;
                                break;
                            case "Sound at max speed":
                                pv2.SoundAtMaxSpeed = property.Value;
                                break;
                            case "Fan sweep diameter":
                                pv2.FanSweepDiameter = property.Value;
                                break;
                            case "Height_Min":
                                pv2.HeightMin = property.Value;
                                break;
                            case "Height_Max":
                                pv2.HeightMax = property.Value;
                                break;
                            case "Weight":
                                pv2.Weight = property.Value;
                                break;
                        }
                    }
                }
                foreach (var property in query3)
                {
                    if (property.Product_ID == item.Product_ID)
                    {
                        switch (property.Property_Name)
                        {
                            case "Use Type":
                                pv3.UseType = property.Value;
                                break;
                            case "Application":
                                pv3.Application = property.Value;
                                break;
                            case "Mounting Location":
                                pv3.MountingLocation = property.Value;
                                break;
                            case "Accessories":
                                pv3.Accessories = property.Value;
                                break;
                            case "Air Flow":
                                pv3.AirFlow = property.Value;
                                break;
                            case "Model Year":
                                pv3.ModelYear = property.Value;
                                break;
                            case "Power_Min":
                                pv3.PowerMin = property.Value;
                                break;
                            case "Power_Max":
                                pv3.PowerMax = property.Value;
                                break;
                            case "Operating Voltage_Min":
                                pv3.OperatingVoltageMin = property.Value;
                                break;
                            case "Operating Voltage_Max":
                                pv3.OperatingVoltageMax = property.Value;
                                break;
                            case "Fan speed_Min":
                                pv3.FanSpeedMin = property.Value;
                                break;
                            case "Fan speed_Max":
                                pv3.FanSpeedMax = property.Value;
                                break;
                            case "Number of fan speeds":
                                pv3.NumberOfFanSpeed = property.Value;
                                break;
                            case "Sound at max speed":
                                pv3.SoundAtMaxSpeed = property.Value;
                                break;
                            case "Fan sweep diameter":
                                pv3.FanSweepDiameter = property.Value;
                                break;
                            case "Height_Min":
                                pv3.HeightMin = property.Value;
                                break;
                            case "Height_Max":
                                pv3.HeightMax = property.Value;
                                break;
                            case "Weight":
                                pv3.Weight = property.Value;
                                break;
                        }
                    }
                }
                ProductModel.Add(pv1);
                ProductModel.Add(pv2);
                ProductModel.Add(pv3);
            }
            return ProductModel;
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

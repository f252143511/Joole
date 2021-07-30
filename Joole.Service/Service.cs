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
                        join product in products  on  propertyvalue.Product_ID equals product.Product_ID
                        join manufacturer in manufacturers on product.Manufacturer_ID equals manufacturer.Manufacturer_ID
                        where product.Product_ID == ID
                        select new { product.Product_ID, product.Model,product.Series,propertyvalue.Value,manufacturer.Name,property.Property_Name };


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

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> NewProducts = new List<ProductModel>();
            var result = UOW.product.GetAll();

            foreach (var item in result)
            {
                ProductModel pr = new ProductModel();
                pr.Product_ID = item.Product_ID;
                var propertyValue = UOW.propertyValue.GetAll();
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

    }
}

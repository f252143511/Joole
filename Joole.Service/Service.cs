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

﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Repository
{
    public class UnitOfWork : IDisposable
    {
        DbContext Context;
        public IUserRepo user;
        public IProductRepo product;
        public IPropertyRepo property;
        public IPropertyValueRepo propertyValue;

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
            user = new UserRepo(context);
            product = new ProductRepo(context);
            property = new PropertyRepo(context);
            propertyValue = new PropertyValueRepo(context);
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

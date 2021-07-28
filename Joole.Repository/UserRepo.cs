﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.Dal;

namespace Joole.Repository
{


    public interface IUserRepo: IRepository<User>
    {

    }
    public class UserRepo:Repository<User>,IUserRepo
    {
        public UserRepo(DbContext context): base(context)
        {

        }
    }
}

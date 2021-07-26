﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Dal;
using Joole.Repository;

namespace Joole.Service
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;
        //private IRepository<UserProfile> userProfileRepository;

        /*public UserService(IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }*/

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            return userRepository.GetById(id);
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            //UserProfile userProfile = userProfileRepository.Get(id);
            //userProfileRepository.Remove(userProfile);
            User user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }
    }
}

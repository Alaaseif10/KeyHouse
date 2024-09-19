﻿using KeyHouse.container;
using KeyHouse.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse.Services
{
    
    public class UserRepository : IUserRepository
    {
        KeyHouseDB context = new KeyHouseDB();

        public List<Users> GetAllUsers()
        {
            List<Users> users = context.Users.ToList();
            return users;
        }
        public Users GetUserById(int id)
        {
            return context.Users.SingleOrDefault(s=>s.Id == id);
        }

        public Users ValidateUserByEmail(string email, string password)
        {
            return context.Users.SingleOrDefault(s => s.Uesr_Email == email && s.User_Password== password);
        }

        public int InsertUser(Users user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }

        public int UpdateUser(int id, Users user)
         {
            Users oldUser = context.Users.SingleOrDefault(s => s.Id == id);
            oldUser.User_Name = user.User_Name;
            oldUser.Uesr_Email = user.Uesr_Email;
            oldUser.User_Password = user.User_Password;
            oldUser.User_Phone = user.User_Phone;
            oldUser.User_Type = user.User_Type;
            //oldUser.Creation_date = user.Creation_date;
            oldUser.status = user.status;

            return context.SaveChanges();
         }

        public int DeleteUser(int id)
        {
            Users oldUser = context.Users.SingleOrDefault(s => s.Id == id);
            context.Users.Remove(oldUser);
            return context.SaveChanges();
        }

    }
}

﻿using KeyHouse.container;
using KeyHouse.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse.Services
{
    
    public interface IUserRepository
    {
        public List<Users> GetAllUsers();
        public Users GetUserById(string id);

        public Users ValidateUserByEmail(string email, string password);

        public Users ValidateAgencyByStatus(int agency_Status);

        public int InsertUser(Users user);

        public int UpdateUser(string id, Users user);

        public int DeleteUser(string id);


    }
}

using KeyHouse.container;
using KeyHouse.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse.Services
{
    
    public interface IUserRepository
    {
        public List<Users> GetAllUsers();
        public Users GetUserById(int id);

        public Users ValidateUserByEmail(string email, string password);

        public int InsertUser(Users user);

        public int UpdateUser(int id, Users user);

        public int DeleteUser(int id);

    }
}

using KeyHouse.container;
using KeyHouse.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse.Services
{

    public class UserRepository : IUserRepository
    {
        KeyHouseDB context; //= new KeyHouseDB();

        public UserRepository(KeyHouseDB _context)
        {
            context = _context;
        }
        public List<Users> GetAllUsers()
        {
            List<Users> users = context.Users.Include(a=>a.Agencies).Where(u => u.User_Type != 3).ToList();
            return users;
        }
        public Users GetUserById(int id)
        {
            return context.Users.Include(s => s.Agencies).SingleOrDefault(s => s.Id == id);
        }

        public Users ValidateUserByEmail(string email, string password)
        {
            return context.Users.Include(s => s.Agencies).SingleOrDefault(s => s.Email == email && s.PasswordHash == password);
        }

        public Users ValidateAgencyByStatus(int agency_Status)
        {
            return context.Users.Include(s => s.Agencies).SingleOrDefault(s => s.Agencies.AgencyStatus == agency_Status);
        }

        public int InsertUser(Users user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }

        public int UpdateUser(int id, Users user)
        {
            Users oldUser = context.Users.Include(s => s.Agencies).SingleOrDefault(s => s.Id == id);
            oldUser.UserName = user.UserName;
            oldUser.Email = user.Email;
            oldUser.PasswordHash = user.PasswordHash;
            oldUser.PhoneNumber = user.PhoneNumber;
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

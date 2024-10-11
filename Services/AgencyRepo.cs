using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using Microsoft.EntityFrameworkCore;
namespace KeyHouse.services
{
    public class AgencyRepo
    {
        //KeyHouseDB context = new KeyHouseDB();
        //Start - After Change 
        KeyHouseDB context;
        public AgencyRepo(KeyHouseDB _context)
        {
            context = _context;
        }
        //End
        public List<Agencies> GetAllAgencies()
        {
            return context.Agencies.ToList();
        }
        public List<Agencies> GetFilteredAgencies(int status)
        {
            return context.Agencies.Where(a => a.AgencyStatus == status).ToList();
        }
        public Agencies GetAgencyById(string agencyId)
        {
            return context.Agencies.Include(a => a.Contracts).SingleOrDefault(a => a.Id == agencyId);
        }
        public void InsertAgencyAndUser(AgencyUserModelView agencyData)
        { // DEFAULT INSERTION IN AGENCY TABLE ONLY
            var Agency = new Agencies
            {
                AgencyName = agencyData.Agency_Name,
                AgencyDescription = agencyData.Agency_Description,
                Email = agencyData.AgencyContactEmail,
                PhoneNumber = agencyData.AgencyContactPhone,
                NumCompany = agencyData.NumCompany,
                //logo = agencyData.logo,
                AgencyStatus = 1
            };
            var user = new Users
            {
                Email = agencyData.AgencyUesrEmail,
                PasswordHash = agencyData.AgencyUserPassword,
                UserName = agencyData.Agency_Name,
                PhoneNumber = agencyData.AgencyContactPhone,
                //TO-DO
               // User_Type = 2,
                status = 2,
                Creation_date = DateTime.Now
            };
            context.Agencies.Add(Agency);
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void DeleteAgency(String agencyId)
        {
            Agencies AgecnyData = context.Agencies.SingleOrDefault(a => a.Id == agencyId);
            context.Remove(AgecnyData);
            context.SaveChanges();
        }
        public void EditAgencyData(String agencyId, Agencies newData)
        {
            Agencies olddata = context.Agencies.SingleOrDefault(a => a.Id == agencyId);
            olddata.AgencyDescription = newData.AgencyDescription;
            olddata.Email = newData.Email;
            olddata.AgencyName = newData.AgencyName;
            olddata.PhoneNumber = newData.PhoneNumber;
            olddata.NumCompany = newData.NumCompany;
            //olddata.logo = newData.logo;
            context.SaveChanges();
        }
        public void EditAgencyStatus(String agencyId ,int AgencyStatus)
        {
            Agencies olddata = context.Agencies.SingleOrDefault(a => a.Id == agencyId);
            olddata.AgencyStatus = AgencyStatus;
            context.SaveChanges();
        }
    }
}

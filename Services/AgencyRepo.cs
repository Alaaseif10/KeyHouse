using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using Microsoft.EntityFrameworkCore;
namespace KeyHouse.services
{
    public class AgencyRepo
    {
       KeyHouseDB context = new KeyHouseDB();

        public List<Agencies> GetAllAgencies()
        {
            return context.Agencies.ToList();
        }
        public List<Agencies> GetFilteredAgencies(int status)
        {
            return context.Agencies.Where(a => a.Agency_Status == status).ToList();
        }
        public Agencies GetAgencyById(int agencyId) 
        {
            return context.Agencies.SingleOrDefault(a => a.Id == agencyId);
        }
        public void InsertAgencyAndUser(AgencyUserModelView agencyData)
        { // DEFAULT INSERTION IN AGENCY TABLE ONLY
            var Agency = new Agencies 
            {
                Agency_Name = agencyData.Agency_Name,
                Agency_Description = agencyData.Agency_Description,
                AgencyContactEmail = agencyData.AgencyContactEmail,
                AgencyContactPhone = agencyData.AgencyContactPhone,
                NumCompany = agencyData.NumCompany,
                logo = agencyData.logo,
                Agency_Status = 1 
            };
            var user = new Users
            {
                 Uesr_Email= agencyData.AgencyUesrEmail,
                 User_Password = agencyData.AgencyUserPassword,
                 User_Name = agencyData.Agency_Name,
                 User_Phone = agencyData.AgencyContactPhone,
                 User_Type = 2,
                 status = 2,
                 Creation_date = DateTime.Now
            };
            context.Agencies.Add(Agency);
            context.Users.Add(user);
            context.SaveChanges();  
        }
        public void DeleteAgency(int agencyId)
        {
            Agencies AgecnyData = context.Agencies.SingleOrDefault(a => a.Id == agencyId);
            context.Remove(AgecnyData);
            context.SaveChanges();
        }
        public void EditAgencyData(int agencyId, Agencies newData) {
            Agencies olddata = context.Agencies.SingleOrDefault(a => a.Id == agencyId);
            olddata.Agency_Description = newData.Agency_Description;
            olddata.AgencyContactEmail = newData.AgencyContactEmail;
            olddata.Agency_Name = newData.Agency_Name;
            olddata.AgencyContactPhone = newData.AgencyContactPhone;
            olddata.NumCompany = newData.NumCompany;
            olddata.logo = newData.logo;
            context.SaveChanges();
        }
        public void EditAgencyStatus(int agencyId)
        {
            Agencies olddata = context.Agencies.SingleOrDefault(a => a.Id == agencyId);
            olddata.Agency_Status = 3;
            context.SaveChanges();
        }


    }
}

using KeyHouse.container;
using KeyHouse.Migrations;
using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static KeyHouse.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace KeyHouse.Services
{
    public class UnitRepo
    {
        KeyHouseDB context;
        public UnitRepo(KeyHouseDB _context)
        {
            context = _context;
        }

        // agencyDashboard Part
        public void InsertUnits(UnitsDetailsModelView Unit, Agencies Agency)
        {

            // add in unit table
            var InsertedUnit = new Units
            {
                Images = new List<Images>(),
                Type_Unit = Unit.Type_Unit,
                Unit_Title = Unit.Unit_Title,
                Type_Rent = Unit.Type_Rent,
                Unit_Description = Unit.Unit_Description,
                Under_constracting_Status = Unit.Under_constracting_Status,
                Num_Rooms = Unit.Num_Rooms,
                Num_Bathrooms = Unit.Num_Bathrooms,
                Area = Unit.Area,
                Price = Unit.Price,
                Furnishing = Unit.Furnishing,
                Added_Date = DateTime.Now,
                Status = 1,
                Blocks = context.Blocks.SingleOrDefault(s => s.Id == Unit.BlockId)
            };

            // add in benefitserviceswunit

            if (Unit.SelectedServices != null)
            {
                foreach (var serviceId in Unit.SelectedServices)
                {
                    var service = context.BenefitsServices.Find(serviceId);
                    InsertedUnit.BenefitsServices.Add(service);

                }
            }

            if (Unit.Images != null)
            {
                foreach (var Img in Unit.Images)
                {
                    var fileName = $"{Guid.NewGuid()}_{Img.FileName}";
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/unitImages", fileName);
                    //// Save the file to the path
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        Img.CopyToAsync(stream);
                    }

                    InsertedUnit.Images.Add(new Images
                    { Img_Path = $"{fileName}", Units = InsertedUnit });
                }
            }

            InsertedUnit.Agencies = Agency;
            context.Units.Add(InsertedUnit);
            context.SaveChanges();

        }
        public void EditUnits(UnitsEditDetailsModelView units)
        {
            Units Ounits = context.Units.Include(b => b.BenefitsServices).SingleOrDefault(u => u.Id == units.UnitId);
            var result = Ounits.BenefitsServices.Select(s => s.Id).ToList();
            Ounits.Unit_Title = units.Unit_Title;
            Ounits.Type_Rent = units.Type_Rent;
            Ounits.Type_Unit = units.Type_Unit;
            Ounits.Unit_Description = units.Unit_Description;
            Ounits.Num_Rooms = units.Num_Rooms;
            Ounits.Num_Bathrooms = units.Num_Bathrooms;
            Ounits.Area = units.Area;
            Ounits.Price = units.Price;
            Ounits.Under_constracting_Status = units.Under_constracting_Status;
            Ounits.Furnishing = units.Furnishing;
            Ounits.Blocks = context.Blocks.SingleOrDefault(s => s.Id == units.BlockId);

            foreach (var serviceId in units.SelectedServices)
            {
                if (result.Contains(serviceId))
                { }
                else
                {
                    var service = context.BenefitsServices.Find(serviceId);
                    Ounits.BenefitsServices.Add(service);

                }

            }
            if (units.Images != null)
            {
                foreach (var Img in units.Images)
                {
                    var fileName = $"{Guid.NewGuid()}_{Img.FileName}"; ;
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/unitImages", fileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        Img.CopyToAsync(stream);
                    }
                    Ounits.Images.Add(new Images
                    { Img_Path = $"{fileName}", Units = Ounits });
                }
            }
            context.SaveChanges();
        }
        public void DeleteUnits(int id)
        {
            var result = context.Units.Include(i => i.Images).Include(b => b.BenefitsServices).Include(s => s.Interests).SingleOrDefault(u => u.Id == id);
            var images = context.Images.Include(u => u.Units).Where(i => i.Units.Id == id);
            foreach (var item in images)
            {
                context.Remove(item);

            }
            context.Remove(result);
            context.SaveChanges();
        }
        public List<AgencyDashboardViewModel> getAllUnitsByAgency(string AgencyId)
        {
            var units = context.Units.Include(i => i.Images).Include(b => b.BenefitsServices)
                       .Include(t => t.Interests).Include(s => s.Agencies)
                        .Where(u => u.Agencies.Id == AgencyId).Select(p => new AgencyDashboardViewModel
                        {
                            id = p.Id,
                            title = ((PropertyType)p.Unit_Title).ToString(),
                            saleType = ((PropertySellType)p.Type_Rent).ToString(),
                            location = (p.Blocks.Cities.Governments.Government_Name) + ", " + (p.Blocks.Cities.City_Name) + ", " + (p.Blocks.Block_Name),
                            price = p.Price,
                            status = p.Status,
                            InterestedUsers = p.Interests.Select(l => l.Users).ToList()
                        }).ToList();
            return units;
        }
        public void UpdateUnitStatus(int propId, int updatedStatus)
        {
            var oldUnit = context.Units.SingleOrDefault(d => d.Id == propId);
            if (oldUnit != null)
            {
                oldUnit.Status = updatedStatus;
            }
            context.SaveChanges();
        }
        public void deleteImg(string path)
        {
            var result = context.Images.SingleOrDefault(i => i.Img_Path == path);
            context.Remove(result);
            context.SaveChanges();
        }
        public UnitsEditDetailsModelView GetUnitByIdDashboard(int id)
        {
            var oldProp = context.Units.Include(b => b.Blocks).Include(i => i.Images).Include(b => b.BenefitsServices).SingleOrDefault(u => u.Id == id);

            var PropDetails = new UnitsEditDetailsModelView
            {
                UnitId = id,
                Unit_Title = oldProp.Unit_Title,
                Type_Rent = oldProp.Type_Rent,
                Type_Unit = oldProp.Type_Unit,
                Under_constracting_Status = oldProp.Under_constracting_Status,
                Unit_Description = oldProp.Unit_Description,
                Num_Rooms = oldProp.Num_Rooms,
                Num_Bathrooms = oldProp.Num_Bathrooms,
                Price = oldProp.Price,
                Area = oldProp.Area,
                Furnishing = oldProp.Furnishing,
                BlockId = oldProp.Blocks.Id,
                CityId = context.Blocks.Include(c => c.Cities).Where(b => b.Id == oldProp.Blocks.Id)
               .Select(b => b.Cities.Id).SingleOrDefault(),
                GovernmentId = context.Blocks.Include(c => c.Cities).ThenInclude(g => g.Governments).Where(b => b.Id == oldProp.Blocks.Id)
                .Select(b => b.Cities.Governments.Id).SingleOrDefault(),
                SelectedServices = oldProp.BenefitsServices.Select(b => b.Id).ToList(),
                ExistingImages = oldProp.Images.Select(i => i.Img_Path).ToList()
            };
            return PropDetails;

        }


        //--------------------------------------

        public Units GetUnitById(int id)
        {
            /*return context.Units.SingleOrDefault(u => u.Id == id ).;
            List<Units> units = context.Units.Include(a => a.Images).Include(u => u.Blocks).ToList();
*/
            return context.Units.Include(a => a.Images).Include(b => b.BenefitsServices).Include(b => b.Blocks).Include(a => a.Agencies).SingleOrDefault(u => u.Id == id);



        }

        public void SetInterest(int unitId, Users users)
        {
            var Interest = new Interest
            {
                UnitsId =unitId ,
                UsersId = users.Id ,
                SuccessfulContact = true ,
                Interest_AddedDate = DateTime.Now,

            };

            context.Interest.Add(Interest);
            context.SaveChanges();


        }

        public Boolean IsUserInterestedBefore(string userId, int unitId)
        {
            var result = context.Interest.SingleOrDefault(i=>i.UsersId == userId && i.UnitsId==unitId) ;
            return result == null;

        }


        /// <summary>
        /// GET ALL UNITS
        /// </summary>
        /// <returns></returns>
        public List<Units> GetAllUnits()
        {
            List<Units> units = context.Units.Include(a => a.Images).Include(u => u.Blocks).ToList();
            return units;
        }
        public List<Units> GetFilteredUnits(string category, string type, int area1 ,int area2, int price1,int price2)
        {
            var query = context.Units.AsQueryable();

           
            if (!string.IsNullOrEmpty(category))
            {
                var propertyCategory = (PropertyCategory)Enum.Parse(typeof(PropertyCategory), category);
                query = query.Where(u => u.Type_Unit == propertyCategory);
            }

            if (!string.IsNullOrEmpty(type))
            {
                var propertyType = (PropertyType)Enum.Parse(typeof(PropertyType), type);
                query = query.Where(u => u.Unit_Title == propertyType);
            }
            if (area1 > 0 && area2>0 )
            {
                query = query.Where(u => u.Area >= area1 && u.Area <= area2 );
            }
            
            if (price1 > 0 && price2 >0)
            {

                query = query.Where(u => u.Price >= price1 && u.Area <= price2);
            }
          


            return query.ToList();
        }


        
    }
}

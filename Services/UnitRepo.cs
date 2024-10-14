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
        #region IED

        /// <summary>
        /// Insert Unit
        /// </summary>
        /// <param name="units"></param>
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
                    var fileName = Img.FileName;
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/unitImages", fileName);
                    //// Save the file to the path
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        Img.CopyToAsync(stream);
                    }

                    InsertedUnit.Images.Add(new Images 
                    { Img_Path = $"/unitImages/{fileName}", Units = InsertedUnit });
                }
            }

            InsertedUnit.Agencies = Agency;
            context.Units.Add(InsertedUnit);
            context.SaveChanges();
            
        }
        /// <summary>
        ///  Edit Unit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="units"></param>
        public void EditUnits(int id , Units units)
        {
            Units Ounits = context.Units.SingleOrDefault(u => u.Id == id);
            Ounits.Unit_Title = units.Unit_Title;
            Ounits.Type_Rent = units.Type_Rent;
            Ounits.Type_Unit = units.Type_Unit;
            Ounits.Unit_Description = units.Unit_Description;
            Ounits.Status = units.Status;
            Ounits.Num_Rooms = units.Num_Rooms;
            Ounits.Num_Bathrooms = units.Num_Bathrooms;
            Ounits.Area = units.Area;
            Ounits.Price = units.Price;
            Ounits.Under_constracting_Status = units.Under_constracting_Status;
            Ounits.Furnishing = units.Furnishing;
            Ounits.Added_Date = units.Added_Date;
            context.Units.Update(Ounits);
            context.SaveChanges();
        }
        /// <summary>
        /// Delete Unit
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUnits(int id)
        {
            context.Remove(context.Units.Single(u => u.Id == id));
            context.SaveChanges();
        }
        #endregion

        //--------------------------------------

        #region Searching

        /// <summary>
        /// retun One Unit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Units GetUnitById(int id)
        {
            /*return context.Units.SingleOrDefault(u => u.Id == id ).;
            List<Units> units = context.Units.Include(a => a.Images).Include(u => u.Blocks).ToList();
*/
            return context.Units.Include(a => a.Images).Include(b => b.BenefitsServices).Include(b => b.Blocks).Include(a => a.Agencies).SingleOrDefault(u => u.Id == id);



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


        #endregion
    }
}

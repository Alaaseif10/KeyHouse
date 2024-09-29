using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse.Services
{
    public class UnitRepo
    {
        KeyHouseDB context = new KeyHouseDB();

        #region IED

        /// <summary>
        /// Insert Unit
        /// </summary>
        /// <param name="units"></param>
        public void InsertUnits(Units units)
        { 
            context.Units.Add(units);
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
        public Units GetUnitById(int id )
        {
            return context.Units.SingleOrDefault(u => u.Id == id  && u.Status==1 && u.Agencies
            .Any(a => a.Contracts.Any(c => c.End_date > u.Added_Date)));

        }
        /// <summary>
        ///  Get All Unit By Fiter
        /// </summary>
        /// <param name="Funits"></param>
        /// <returns></returns>
        public List<Units> GetAllUnits(Units F_units)
        {
              List<Units> units = context.Units
              .Where(u =>  u.Equals(F_units) &&
               u.Agencies.Any(a => a.Contracts.Any(c => c.End_date > u.Added_Date)))
              .ToList();
            return units;
        }

        #endregion
    }
}

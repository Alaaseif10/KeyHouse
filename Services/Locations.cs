using KeyHouse.container;
using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace KeyHouse.Services
{
    public class Locations : Controller
    {
        KeyHouseDB context = new KeyHouseDB();

        public List<Governments> GetGovernments()
        {
            return context.Governments.ToList();
        }

        public object getcity(int govid) {

            var result = context.Cities.Where(s => s.Governments.Id == govid).Select(s => new { s.Id, s.City_Name }).ToList();
            return result;
        }

        public object getblock(int cityid) {

            var result = context.Blocks.Where(b => b.Cities.Id == cityid).Select(s => new { s.Id, s.Block_Name }).ToList();
            return result;

        }


    }
}

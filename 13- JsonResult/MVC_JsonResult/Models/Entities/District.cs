using System.Collections.Generic;

namespace MVC_JsonResult.Models.Entities
{
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }

        public int CityId { get; set; }
        public City  City { get; set; }

        public List<Town> Towns { get; set; }
    }
}
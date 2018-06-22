using System.Collections.Generic;

namespace MVC_JsonResult.Models.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<District> Districts { get; set; }
    }
}
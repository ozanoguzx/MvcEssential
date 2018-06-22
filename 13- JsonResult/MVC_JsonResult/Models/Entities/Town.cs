namespace MVC_JsonResult.Models.Entities
{
    public class Town
    {
        public int TownId { get; set; }
        public string TownName { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
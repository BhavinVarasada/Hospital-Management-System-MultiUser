namespace Hospital_Management_System.Areas.Building.Models
{
    public class BuildingModel
    {
        public int BuildingID { get; set; }
        public string BuildingNumber { get; set; }
        public int TotalFloor { get; set; }
    }

    public class Building_DropDownModel
    {
        public int BuildingID { get; set; }
        public string BuildingNumber { get; set; }
        public int TotalFloor { get; set; }
    }
}

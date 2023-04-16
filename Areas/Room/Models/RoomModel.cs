namespace Hospital_Management_System.Areas.Room.Models
{
    public class RoomModel
    {
        public int? RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public decimal RoomRate { get; set; }
        public string RoomNumber { get; set; }
        public int BuildingID { get; set; }
        public string BedNumber { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }
    }

    public class Room_DropDownModel
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string BedNumber { get; set; }


    }
}

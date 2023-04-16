namespace Hospital_Management_System.Areas.IPD.Models
{
    public class IPDModel
    {
        public int? IPDID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int RoomID { get; set; }
        public int BuildingID { get; set; }
        public string Problem { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

    }
}

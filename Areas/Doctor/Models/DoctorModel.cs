namespace Hospital_Management_System.Areas.Doctor.Models
{
    public class DoctorModel
    {
        public int? DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public int SpecialityID { get; set; }
        public string Education { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }
    }

    public class Doctor_DropDownModel
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
    }
}

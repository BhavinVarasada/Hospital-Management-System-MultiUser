namespace Hospital_Management_System.Areas.Patient.Models
{
    public class PatientModel
    {
        public int? PatientID { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BloodGroupID { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }
    }

    public class Patient_DropDownModel
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }

    }
}

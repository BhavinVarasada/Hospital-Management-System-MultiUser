using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Areas.Appointment.Models
{
    public class AppointmentModel
    {
        public int? AppointmentID {get; set;}
        public int PatientID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int DoctorID { get; set; }
        public string Problem { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }

    }
}

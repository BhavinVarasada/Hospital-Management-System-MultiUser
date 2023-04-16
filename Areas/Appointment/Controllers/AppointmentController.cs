using Hospital_Management_System.Areas.Appointment.Models;
using Hospital_Management_System.Areas.Doctor.Models;
using Hospital_Management_System.Areas.Patient.Models;
using Hospital_Management_System.BAL;
using Hospital_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Management_System.Areas.Appointment.Controllers
{
    [CheckAccess]
    [Area("Appointment")]
    [Route("Appointment/[controller]/[action]")]
    public class AppointmentController : Controller
    {
        string MyConnectionString = DALHelper.MyConnectionString;

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

        #region SelectAll
        public IActionResult Index()
        {
            Appointment_DAL dalAppointment = new Appointment_DAL();
            DataTable dtAppointment = dalAppointment.PR_Appointment_SelectAll();
            return View("AppointmentList", dtAppointment);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int AppointmentID)
        {
            Appointment_DAL dalAppointment = new Appointment_DAL();
            DataTable dtAppointment = dalAppointment.PR_Appointment_DeleteByPK(AppointmentID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert

        [HttpPost]
        public IActionResult Save(AppointmentModel modelAppointment)
        {
            Appointment_DAL dalAppointment = new Appointment_DAL();

            if (modelAppointment.AppointmentID == null)
            {
                DataTable AppointmentInsertdt = dalAppointment.PR_Appointment_Insert(modelAppointment);
            }
            else
            {
                DataTable AppointmentUpdatedt = dalAppointment.PR_Appointment_UpdateByPK(modelAppointment);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? AppointmentID)
        {
            #region Patient Dropdown

            DataTable dtPatientSelect = new DataTable();
            SqlConnection conn1 = new SqlConnection(MyConnectionString);
            conn1.Open();

            SqlCommand cmdPatientDropDown = conn1.CreateCommand();
            cmdPatientDropDown.CommandType = CommandType.StoredProcedure;
            cmdPatientDropDown.CommandText = "PR_Patient_SelectForDropDown";
            SqlDataReader sdrPatientDropDown = cmdPatientDropDown.ExecuteReader();
            dtPatientSelect.Load(sdrPatientDropDown);
            conn1.Close();

            List<Patient_DropDownModel> PatientDropDownlist = new List<Patient_DropDownModel>();
            foreach (DataRow dr in dtPatientSelect.Rows)
            {
                Patient_DropDownModel vlstPatient = new Patient_DropDownModel();
                vlstPatient.PatientID = Convert.ToInt32(dr["PatientID"]);
                vlstPatient.PatientName = dr["PatientName"].ToString();
                PatientDropDownlist.Add(vlstPatient);
            }
            ViewBag.PatientList = PatientDropDownlist;

            #endregion

            #region Doctor Dropdown

            DataTable dtDoctorSelect = new DataTable();
            SqlConnection conn2 = new SqlConnection(MyConnectionString);
            conn2.Open();

            SqlCommand cmdDoctorDropDown = conn2.CreateCommand();
            cmdDoctorDropDown.CommandType = CommandType.StoredProcedure;
            cmdDoctorDropDown.CommandText = "PR_Doctor_SelectForDropDown";
            SqlDataReader sdrDoctorDropDown = cmdDoctorDropDown.ExecuteReader();
            dtDoctorSelect.Load(sdrDoctorDropDown);
            conn2.Close();

            List<Doctor_DropDownModel> DoctorDropDownlist = new List<Doctor_DropDownModel>();
            foreach (DataRow dr in dtDoctorSelect.Rows)
            {
                Doctor_DropDownModel vlstDoctor = new Doctor_DropDownModel();
                vlstDoctor.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                vlstDoctor.DoctorName = dr["DoctorName"].ToString();
                DoctorDropDownlist.Add(vlstDoctor);
            }
            ViewBag.DoctorList = DoctorDropDownlist;

            #endregion


            if (AppointmentID != null)
            {
                Appointment_DAL dalAppointment = new Appointment_DAL();
                DataTable AppointmentSelectdt = dalAppointment.PR_Appointment_SelectByPK((int)AppointmentID);

                AppointmentModel modelAppointment = new AppointmentModel();
                foreach (DataRow dr in AppointmentSelectdt.Rows)
                {
                    modelAppointment.PatientID = Convert.ToInt32(dr["PatientID"]);
                    modelAppointment.AppointmentDate = (DateTime)dr["AppointmentDate"];
                    modelAppointment.AppointmentTime = (DateTime)dr["AppointmentTime"];
                    modelAppointment.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                    modelAppointment.Problem = dr["Problem"].ToString();
                    modelAppointment.CreationDate = (DateTime)dr["CreationDate"];
                    modelAppointment.ModificationDate = (DateTime)dr["ModificationDate"];
                }
                return View("AppointmentAddEdit", modelAppointment);
            }
            return View("AppointmentAddEdit");
        }

        #endregion
    }
}

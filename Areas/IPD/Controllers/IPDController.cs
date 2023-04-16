using Hospital_Management_System.Areas.Building.Models;
using Hospital_Management_System.Areas.Department.Models;
using Hospital_Management_System.Areas.Designation.Models;
using Hospital_Management_System.Areas.Doctor.Models;
using Hospital_Management_System.Areas.IPD.Models;
using Hospital_Management_System.Areas.Patient.Models;
using Hospital_Management_System.Areas.Room.Models;
using Hospital_Management_System.Areas.Speciality.Models;
using Hospital_Management_System.BAL;
using Hospital_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Management_System.Areas.IPD.Controllers
{
    [CheckAccess]
    [Area("IPD")]
    [Route("IPD/[controller]/[action]")]
    public class IPDController : Controller
    {
        string MyConnectionString = DALHelper.MyConnectionString;
        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

        #region SelectAll
        public IActionResult Index()
        {
            IPD_DAL dalIPD = new IPD_DAL();
            DataTable dtIPD = dalIPD.PR_IPD_SelectAll();
            return View("IPDList", dtIPD);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int IPDID)
        {
            IPD_DAL dalIPD = new IPD_DAL();
            DataTable dtIPD = dalIPD.PR_IPD_DeleteByPK(IPDID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert

        [HttpPost]
        public IActionResult Save(IPDModel modelIPD)
        {
            IPD_DAL dalIPD = new IPD_DAL();

            if (modelIPD.IPDID == null)
            {
                DataTable IPDInsertdt = dalIPD.PR_IPD_Insert(modelIPD);
            }
            else
            {
                DataTable IPDUpdatedt = dalIPD.PR_IPD_UpdateByPK(modelIPD);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? IPDID)
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

            #region Room Dropdown

            DataTable dtRoomSelect = new DataTable();
            SqlConnection conn3 = new SqlConnection(MyConnectionString);
            conn3.Open();

            SqlCommand cmdRoomDropDown = conn3.CreateCommand();
            cmdRoomDropDown.CommandType = CommandType.StoredProcedure;
            cmdRoomDropDown.CommandText = "PR_Room_SelectForDropDown";
            SqlDataReader sdrRoomDropDown = cmdRoomDropDown.ExecuteReader();
            dtRoomSelect.Load(sdrRoomDropDown);
            conn3.Close();

            List<Room_DropDownModel> RoomDropDownlist = new List<Room_DropDownModel>();
            foreach (DataRow dr in dtRoomSelect.Rows)
            {
                Room_DropDownModel vlstRoom = new Room_DropDownModel();
                vlstRoom.RoomID = Convert.ToInt32(dr["RoomID"]);
                vlstRoom.RoomNumber = dr["RoomNumber"].ToString();
                RoomDropDownlist.Add(vlstRoom);
            }
            ViewBag.RoomList = RoomDropDownlist;

            #endregion

            #region Building Dropdown

            DataTable dtBuildingSelect = new DataTable();
            SqlConnection conn4 = new SqlConnection(MyConnectionString);
            conn4.Open();

            SqlCommand cmdBuildingDropDown = conn4.CreateCommand();
            cmdBuildingDropDown.CommandType = CommandType.StoredProcedure;
            cmdBuildingDropDown.CommandText = "PR_Building_SelectForDropDown";
            SqlDataReader sdrBuildingDropDown = cmdBuildingDropDown.ExecuteReader();
            dtBuildingSelect.Load(sdrBuildingDropDown);
            conn4.Close();

            List<Building_DropDownModel> BuildingDropDownlist = new List<Building_DropDownModel>();
            foreach (DataRow dr in dtBuildingSelect.Rows)
            {
                Building_DropDownModel vlstBuilding = new Building_DropDownModel();
                vlstBuilding.BuildingID = Convert.ToInt32(dr["BuildingID"]);
                vlstBuilding.BuildingNumber = dr["BuildingNumber"].ToString();
                BuildingDropDownlist.Add(vlstBuilding);
            }
            ViewBag.BuildingList = BuildingDropDownlist;

            #endregion


            if (IPDID != null)
            {
                IPD_DAL dalIPD = new IPD_DAL();
                DataTable IPDSelectdt = dalIPD.PR_IPD_SelectByPK((int)IPDID);

                IPDModel modelIPD = new IPDModel();
                foreach (DataRow dr in IPDSelectdt.Rows)
                {
                    modelIPD.PatientID = Convert.ToInt32(dr["PatientID"]);
                    modelIPD.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                    modelIPD.RoomID = Convert.ToInt32(dr["RoomID"]);
                    modelIPD.BuildingID = Convert.ToInt32(dr["BuildingID"]);
                    modelIPD.Problem = dr["Problem"].ToString();
                    modelIPD.CreationDate = (DateTime)dr["CreationDate"];
                    modelIPD.ModificationDate = (DateTime)dr["ModificationDate"];
                }
                return View("IPDAddEdit", modelIPD);
            }
            return View("IPDAddEdit");
        }

        #endregion
    }
}
